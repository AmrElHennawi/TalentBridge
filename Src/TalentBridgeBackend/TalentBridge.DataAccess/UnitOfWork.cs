using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using TalentBridge.DataAccess.Interfaces;
using TalentBridge.DataAccess.Repositories;
using TalentBridge.DataContext;
using TalentBridge.Entities;
using TalentBridge.Entities.Models;


namespace TalentBridge.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public IJobRepository Jobs { get; private set; }
        public IExtraDataRepository ExtraData { get; private set; }
        public IApplicationRepository Applications { get; private set; }

        public IHrJobAssignmentRepository HrJobAssignments { get; private set; }

        public IAddedSetionsRepository AddedSections { get; private set; }

        public IHrRepository Hrs { get; private set; }

        public UnitOfWork(AppDbContext context, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            Jobs = new JobRepository(_context);
            ExtraData = new ExtraDataRepository(_context);
            Applications = new ApplicationRepository(_context);
            HrJobAssignments = new HrJobAssignmentRepository(_context);
            AddedSections = new AddedSetionsRepository(_context);
            Hrs = new HrRepository(userManager, roleManager);
        }

        public async void Dispose()
        {
            await _context.DisposeAsync();
        }


        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
