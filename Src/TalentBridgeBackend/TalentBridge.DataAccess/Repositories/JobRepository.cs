using Microsoft.EntityFrameworkCore;
using TalentBridge.DataAccess.Interfaces;
using TalentBridge.DataContext;
using TalentBridge.Entities.Models;

namespace TalentBridge.DataAccess.Repositories
{
    public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        public JobRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Job>> GetJobsByHrId(string hrId)
        {
            return await _context.HrJobAssignments
                .Where(x => x.HrId == hrId)
                .Include(x => x.Job)
                .ThenInclude(j => j.AddedSections)
                .Select(x => x.Job)
                .ToListAsync();
        }

        public async Task<IEnumerable<Job>> GetAllJobs()
        {
            return await _context.Jobs
                .Include(j => j.AddedSections)
                .ToListAsync();
        }
    }
}