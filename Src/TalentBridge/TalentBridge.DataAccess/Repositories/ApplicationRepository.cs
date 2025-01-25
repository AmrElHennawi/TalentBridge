using TalentBridge.DataAccess.Interfaces;
using TalentBridge.DataContext;

namespace TalentBridge.DataAccess.Repositories
{
    public class ApplicationRepository : BaseRepository<Entities.Models.Application> , IApplicationRepository
    {
        public ApplicationRepository(AppDbContext context) : base(context)
        {
        }
    }

}
