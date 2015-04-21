using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebInterface.DataAcess.UserDBContext.Models
{
	public class Address
	{
		[Key]
		[ForeignKey("ApplicationUser")]
		public string ApplicationUserId { get; set; }

		public string AddressLine1 { get; set; }
		public string AddressLine2 { get; set; }
		public string AddressLine3 { get; set; }
		public string AddressLine4 { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public string Postcode { get; set; }

		public virtual ApplicationUser ApplicationUser { get; set; }

	}
}