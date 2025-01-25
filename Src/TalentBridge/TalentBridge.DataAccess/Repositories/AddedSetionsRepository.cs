using TalentBridge.DataAccess.Interfaces;
using TalentBridge.DataContext;

namespace TalentBridge.DataAccess.Repositories
{
    public class AddedSetionsRepository : BaseRepository<Entities.Models.AddedSections>, IAddedSetionsRepository
    {
        public AddedSetionsRepository(AppDbContext context) : base(context)
        {
        }
    }

}
