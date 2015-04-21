using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using WebInterface.DataAcess.UserDBContext.Models;

namespace WebInterface.DataAcess.UserDBContext
{

	public class UserDbContext : IdentityDbContext<ApplicationUser>
	{
		public UserDbContext()
			: base("AppDB", throwIfV1Schema: false)
		{
		}

		public static UserDbContext Create()
		{
			return new UserDbContext();
		}

		public DbSet<Address> Addresses;
	}
}