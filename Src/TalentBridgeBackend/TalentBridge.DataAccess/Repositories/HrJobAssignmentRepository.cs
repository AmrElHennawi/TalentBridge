using Microsoft.EntityFrameworkCore;
using TalentBridge.DataContext;

namespace TalentBridge.DataAccess.Repositories
{
    public class HrJobAssignmentRepository : BaseRepository<Entities.Models.HrJobAssignment>, Interfaces.IHrJobAssignmentRepository
    {
        public HrJobAssignmentRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<bool> IsHrAssignedToJob(int jobId, string userId)
        {
            var result = await _context.HrJobAssignments.FirstOrDefaultAsync(x => x.JobId == jobId && x.HrId == userId);
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }

}
