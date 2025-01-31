using TalentBridge.Entities.Models;

namespace TalentBridge.DataAccess.Interfaces
{
    public interface IJobRepository : IBaseRepository<Entities.Models.Job> 
    {
        Task<IEnumerable<Job>> GetJobsByHrId(string hrId);
        Task<IEnumerable<Job>> GetAllJobs();
    }
}