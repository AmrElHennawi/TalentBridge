using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TalentBridge.Entities;

namespace TalentBridge.DataContext
{
	public class AppDbContext : IdentityDbContext<Entities.AppUser>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

        public DbSet<Job> Jobs { get; set; }
		public DbSet<HrJobAssignment> HrJobAssignments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HrJobAssignment>()
                .HasKey(hrJobAssignment => new { hrJobAssignment.HrId, hrJobAssignment.JobId });

            modelBuilder.Entity<HrJobAssignment>()
                .HasOne(hrJobAssignment => hrJobAssignment.Hr)
                .WithMany(hrUser => hrUser.HrJobsAssignments)
                .HasForeignKey(hrJobAssignment => hrJobAssignment.HrId);

            modelBuilder.Entity<HrJobAssignment>()
                .HasOne(hrJobAssignment => hrJobAssignment.Job)
                .WithMany(job => job.HrJobsAssignments)
                .HasForeignKey(hrJobAssignment => hrJobAssignment.JobId);

            modelBuilder.Entity<IdentityRole>().HasData(
				new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
				new IdentityRole { Id = "2", Name = "Hr", NormalizedName = "HR" },
				new IdentityRole { Id = "3", Name = "User", NormalizedName = "USER" }
			);
		}
	}
}