using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using WebInterface.Areas.UserManagement.Models;
using WebInterface.DataAcess.UserDBContext.Models;
using WebInterface.Services.Common;
using WebInterface.Services.UserManagement.Helper;
using WebInterface.Services.UserManagement.Interfaces;
using WebInterface.Services.UserManagement.Model;

namespace WebInterface.Services.UserManagement.Implementations
{
	public class UserManagementService : IUserManagementService
	{
		private readonly ApplicationUserManager applicationUserManager;
		private readonly ApplicationSignInManager applicationSignInManager;
		private readonly UserMapper userMapper;

		public UserManagementService(ApplicationUserManager applicationUserManager, ApplicationSignInManager applicationSignInManager, UserMapper userMapper)
		{
			this.applicationUserManager = applicationUserManager;
			this.applicationSignInManager = applicationSignInManager;
			this.userMapper = userMapper;
		}

		public UserDetail GetUserById(string userId)
		{
			return userMapper.MapToDetail(applicationUserManager.FindById(userId));
		}

		public ErrorCollection UpdateUser(UserDetail detail)
		{
			var rv = new ErrorCollection();

			var user = applicationUserManager.FindById(detail.Id);

			if (user == null)
			{
				rv.Errors.Add("Invalid user id");
				return rv;
			}

			userMapper.MapToModel(detail, user);

			applicationUserManager.Update(user);

			return rv;
		}
	}
}