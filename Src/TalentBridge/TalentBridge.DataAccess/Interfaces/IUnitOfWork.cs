
using TalentBridge.Entities.Models;


namespace TalentBridge.DataAccess.Interfaces

{
    public interface IUnitOfWork : IDisposable
    {
        IBaseRepository<Job> Jobs { get; }
        IBaseRepository<Entities.Models.Application> Applications { get; }
        IBaseRepository<AddedSections> AddedSections { get; }
        IBaseRepository<ExtraData> ExtraData { get; }
        IBaseRepository<HrJobAssignment> HrJobAssignments { get; }

        int Complete();
    }
}