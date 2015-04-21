using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using WebInterface.Areas.UserManagement.Models;
using WebInterface.Services.Common;
using WebInterface.Services.UserManagement.Interfaces;
using WebInterface.Services.UserManagement.Model;

namespace WebInterface.Areas.UserManagement.Controllers
{
	[Authorize]
    public class UserManagementApiController : ApiController
	{
		private readonly IUserManagementService userManagementService;

		public UserManagementApiController(
			IUserManagementService userManagementService)
		{
			this.userManagementService = userManagementService;
		}

	    [HttpGet]
		[Route("api/user-management/user")]
		[ResponseType(typeof(UserDetail))]
		public HttpResponseMessage GetUserDetail()
	    {
		    var userDetail = userManagementService.GetUserById(User.Identity.GetUserId());

		    return Resource(userDetail);
	    }

		[HttpPost]
		[Route("api/user-management/user")]
		[ResponseType(typeof(UserDetail))]
		public HttpResponseMessage UpdateUserDetail(UserDetail detail)
		{
			var rv = userManagementService.UpdateUser(detail);

			detail.ErrorCollection = rv;

			return Resource(detail);
		}


		public HttpResponseMessage Resource(DetailBase detail)
		{
			if (detail.ErrorCollection.HasError)
			{
				return Request.CreateResponse(HttpStatusCode.BadRequest, detail);
			}

			return Request.CreateResponse(HttpStatusCode.OK, detail);
		}
	}
}
