using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using WebInterface.DataAcess;
using WebInterface.Services.UserManagement.DIConfigure;

namespace WebInterface
{
	public partial class Startup
	{
		internal static IDataProtectionProvider DataProtectionProvider { get; private set; }
		public void ConfigureDIContainer(IAppBuilder app)
		{
			//hacky way
			DataProtectionProvider = app.GetDataProtectionProvider();

			var container = new Container();

			
			//Register db layer context first
			DbContextDI.Confiure(container);
			
			//Register service layer services 
			UserManagementDI.Confiure(container);

			container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
			container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
			
			container.Verify();

			

			DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));

			GlobalConfiguration.Configuration.DependencyResolver =
				new SimpleInjectorWebApiDependencyResolver(container);

		}

	}

	
}