using Microsoft.EntityFrameworkCore;
using TalentBridge.DataAccess.Interfaces;
using TalentBridge.DataContext;
using TalentBridge.Entities.Enums;
using TalentBridge.Entities.Models;

namespace TalentBridge.DataAccess.Repositories
{
    public class ApplicationRepository : BaseRepository<Entities.Models.Application> , IApplicationRepository
    {
        public ApplicationRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Entities.Models.Application>> GetApplicationsByJobIdAndStatus(int jobId, ApplicationStatus status)
        {
            return await _context.Applications
                .Where(x => x.JobId == jobId && x.Status == status)
                .Include(j => j.ExtraData)
                .ToListAsync();
        }

        public async Task<int> GetHiredCount(int jobId)
        {
            return await _context.Applications
                .Where(x => x.JobId == jobId && x.Status == ApplicationStatus.Hired)
                .CountAsync();
        }
    }

}
