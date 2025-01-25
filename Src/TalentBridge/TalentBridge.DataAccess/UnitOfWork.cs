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
        public IBaseRepository<Job> Jobs { get; private set; }
        public IBaseRepository<ExtraData> ExtraData { get; private set; }
        public IBaseRepository<Entities.Models.Application> Applications { get; private set; }

        public IBaseRepository<HrJobAssignment> HrJobAssignments { get; private set; }

        public IBaseRepository<AddedSections> AddedSections { get; private set; }

        public IHrRepository Hrs { get; private set; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            Jobs = new BaseRepository<Job>(_context);
            Jobs = new BaseRepository<Job>(_context);
            ExtraData = new BaseRepository<ExtraData>(_context);
            Applications = new BaseRepository<Entities.Models.Application>(_context);
            HrJobAssignments = new BaseRepository<HrJobAssignment>(_context);
            AddedSections = new BaseRepository<AddedSections>(_context);
        }

        public void Dispose()
        {
            _context.Dispose();
        }


        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
