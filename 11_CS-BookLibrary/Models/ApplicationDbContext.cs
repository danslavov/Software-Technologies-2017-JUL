using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace _11_CS_BookLibrary.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public virtual DbSet<Book> Books { get; set; }

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}