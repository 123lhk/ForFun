using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleInjector;
using WebInterface.DataAcess.UserDBContext;

namespace WebInterface.DataAcess
{
	public static class DbContextDI
	{
		public static void Confiure(Container container)
		{
			container.RegisterPerWebRequest<UserDbContext>();


		}
	}
}