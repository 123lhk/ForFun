using System;
using WebInterface.Areas.UserManagement.Models;
using WebInterface.Common.Interface;
using WebInterface.DataAcess.UserDBContext.Models;
using WebInterface.Services.UserManagement.Model;

namespace WebInterface.Services.UserManagement.Helper
{
	public class UserMapper : IViewMapper<UserDetail, ApplicationUser>
	{
		public UserDetail MapToDetail(ApplicationUser model)
		{
			var userDetail = new UserDetail()
			{
				Id = model.Id,
				UserName = model.UserName,
				FirstName = model.FirstName,
				LastName = model.LastName,
				DateOfBirth = model.DateOfBirth,
				AddressDetail = model.Address == null ? new AddressDetail() : new AddressDetail()
				{
					AddressLine1 = model.Address.AddressLine1,
					AddressLine2 = model.Address.AddressLine2,
					AddressLine3 = model.Address.AddressLine3,
					AddressLine4 = model.Address.AddressLine4,
					City = model.Address.City,
					State = model.Address.State,
					Postcode = model.Address.Postcode
				}
			};

			return userDetail;

		}

		public void MapToModel(UserDetail detail, ApplicationUser model)
		{
			model.FirstName = detail.FirstName;
			model.LastName = detail.LastName;
			model.DateOfBirth = detail.DateOfBirth;

			if (detail.AddressDetail != null)
			{
				if (model.Address == null)
				{
					model.Address = new Address();
				}

				model.Address.AddressLine1 = detail.AddressDetail.AddressLine1;
				model.Address.AddressLine2 = detail.AddressDetail.AddressLine2;
				model.Address.AddressLine3 = detail.AddressDetail.AddressLine3;
				model.Address.AddressLine4 = detail.AddressDetail.AddressLine4;
				model.Address.State = detail.AddressDetail.State;
				model.Address.City = detail.AddressDetail.City;
				model.Address.Postcode = detail.AddressDetail.Postcode;
			}
		}

	
	}
}