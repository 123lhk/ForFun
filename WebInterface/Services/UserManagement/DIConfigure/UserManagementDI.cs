using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using SimpleInjector;
using SimpleInjector.Advanced;
using WebInterface.DataAcess.UserDBContext;
using WebInterface.DataAcess.UserDBContext.Models;
using WebInterface.Services.UserManagement.Helper;
using WebInterface.Services.UserManagement.Implementations;
using WebInterface.Services.UserManagement.Interfaces;

namespace WebInterface.Services.UserManagement.DIConfigure
{
	public static class UserManagementDI
	{
		public static void Confiure(Container container)
		{
			container.RegisterPerWebRequest<IUserStore<ApplicationUser>>(() =>
				new UserStore<ApplicationUser>(
					container.GetInstance<UserDbContext>()));

			container.RegisterPerWebRequest<ApplicationUserManager>();

			container.RegisterPerWebRequest<ApplicationSignInManager>();

			container.RegisterPerWebRequest<IAuthenticationManager>(
				() =>
					container.IsVerifying()
						? new OwinContext(new Dictionary<string, object>()).Authentication
						: HttpContext.Current.GetOwinContext().Authentication);

			container.RegisterSingle<IUserManagementService, UserManagementService>();

			container.RegisterSingle<UserMapper>();
		}
	}
}