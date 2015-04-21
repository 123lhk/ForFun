using System;
using WebInterface.Services.Common;

namespace WebInterface.Services.UserManagement.Model
{
	public class UserDetail : DetailBase
	{

		public UserDetail()
		{
			AddressDetail = new AddressDetail();
		}

		public string Id { get; set; }

		public string UserName { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public DateTime? DateOfBirth { get; set; }

		public AddressDetail AddressDetail { get; set; }

		
	
	}

	public class AddressDetail
	{
		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string AddressLine3 { get; set; }
		public string AddressLine4 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Postcode { get; set; }

	}

	
}