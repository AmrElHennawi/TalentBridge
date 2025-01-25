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

    }
}