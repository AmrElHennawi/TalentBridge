

namespace TalentBridge.DataAccess.Interfaces
{
    public interface IHrJobAssignmentRepository : IBaseRepository<Entities.Models.HrJobAssignment>
    {
        Task<bool> IsHrAssignedToJob(int jobId, string userId);
    }
}
