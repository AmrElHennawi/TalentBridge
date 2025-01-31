
using TalentBridge.DataAccess.Interfaces;
using TalentBridge.DataContext;

namespace TalentBridge.DataAccess.Repositories
{
    public class ExtraDataRepository : BaseRepository<Entities.Models.ExtraData>, IExtraDataRepository
    {
        public ExtraDataRepository(AppDbContext context) : base(context)
        {
        }
    }
}
