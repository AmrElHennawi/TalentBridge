using TalentBridge.Entities.Enums;
using TalentBridge.Entities.Models;

namespace TalentBridge.DataAccess.Interfaces
{
	public interface IApplicationRepository : IBaseRepository<Entities.Models.Application>
	{
		Task<IEnumerable<Entities.Models.Application>> GetApplicationsByJobIdAndStatus(int jobId, ApplicationStatus status);

		Task<int> GetHiredCount(int jobId);
	}
}

