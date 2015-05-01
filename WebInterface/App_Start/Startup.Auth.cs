using System;
using System.Security.Claims;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Linq;
using Owin;
using WebInterface.Common;
using WebInterface.DataAcess.UserDBContext.Models;
using WebInterface.Services.UserManagement.Helper;

namespace WebInterface
{
    public partial class Startup
    {
		
        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {
            // Configure the db context, user manager and signin manager to use a single instance per request
			//app.CreatePerOwinContext(ApplicationDbContext.Create);
			//app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
			//app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);
			app.CreatePerOwinContext(() => DependencyResolver.Current.GetService<ApplicationUserManager>());


            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/UserManagement/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager)),
					OnApplyRedirect = ctx =>
					{
						if (!IsApiCall(ctx.Request))
						{
							ctx.Response.Redirect(ctx.RedirectUri);
						}
					}
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

            // Uncomment the following lines to enable logging in with third party login providers
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "",
            //    clientSecret: "");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");

            //app.UseFacebookAuthentication(
            //   appId: "",
            //   appSecret: "");

			//http://stackoverflow.com/questions/17937553/get-extradata-from-mvc5-framework-oauth-owin-identity-provider-with-external-aut

			var googleOAuth2AuthenticationOptions = new GoogleOAuth2AuthenticationOptions
			{
				ClientId = "xxx",
				ClientSecret = "xxx",
				//Provider = new GoogleOAuth2AuthenticationProvider()
				//{
				//	OnAuthenticated = async context =>
				//	{
						
				//	}
				//}
			};

			//googleOAuth2AuthenticationOptions.Scope.Add("https://www.googleapis.com/auth/plus.login");
			//googleOAuth2AuthenticationOptions.Scope.Add("email");
			//googleOAuth2AuthenticationOptions.Scope.Add("openId");
			//googleOAuth2AuthenticationOptions.Scope.Add("profile");

			app.UseGoogleAuthentication(googleOAuth2AuthenticationOptions);
		
        }

		//http://stackoverflow.com/questions/20149750/unauthorised-webapi-call-returning-login-page-rather-than-401

		private static bool IsApiCall(IOwinRequest request)
		{
			var url = request.Path.ToString();
			var apiUrl = "/api";
			if (url.Length < apiUrl.Length || (url.Length == apiUrl.Length && string.Compare(url, apiUrl, StringComparison.OrdinalIgnoreCase) != 0))
			{
				return false;
			}
			else if (url.StartsWith(apiUrl, StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}

			return false;
		}
    }
}
