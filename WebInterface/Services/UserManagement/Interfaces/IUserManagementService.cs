using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using WebInterface.DataAcess.UserDBContext.Models;
using WebInterface.Services.Common;
using WebInterface.Services.UserManagement.Model;

namespace WebInterface.Services.UserManagement.Interfaces
{
	public interface IUserManagementService
	{
		UserDetail GetUserById(string userId);
		ErrorCollection UpdateUser(UserDetail detail);
	}
}