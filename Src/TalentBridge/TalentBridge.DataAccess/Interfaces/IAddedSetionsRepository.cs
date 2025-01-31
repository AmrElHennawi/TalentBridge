
using TalentBridge.Entities.Models;

namespace TalentBridge.DataAccess.Interfaces
{
    public interface IAddedSetionsRepository : IBaseRepository<Entities.Models.AddedSections>
    {
        Task<List<AddedSections>> GetAddedSectionsByJobId(int JobId);
        Task<string> GetTitleBySectionId(int SectionId);
    }
}
