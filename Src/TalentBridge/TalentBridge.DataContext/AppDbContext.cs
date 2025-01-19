using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TalentBridge.Entities.Models;

namespace TalentBridge.DataContext
{
    public class AppDbContext : IdentityDbContext<Entities.AppUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Job> Jobs { get; set; }
		public DbSet<HrJobAssignment> HrJobAssignments { get; set; }
		public DbSet<Application> Applications { get; set; }
		public DbSet<AddedSections> AddedSections { get; set; }
		public DbSet<ExtraData> ExtraData { get; set; }


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
				new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
				new IdentityRole { Id = "2", Name = "Hr", NormalizedName = "HR" },
				new IdentityRole { Id = "3", Name = "User", NormalizedName = "USER" }
			);
		}
	}
}