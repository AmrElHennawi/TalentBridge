
using TalentBridge.Entities.Models;

namespace TalentBridge.DataAccess.Interfaces
{
    public interface IAddedSetionsRepository : IBaseRepository<Entities.Models.AddedSections>
    {
        Task<List<AddedSections>> getAddedSectionsByJobId(int JobId);
    }
}
