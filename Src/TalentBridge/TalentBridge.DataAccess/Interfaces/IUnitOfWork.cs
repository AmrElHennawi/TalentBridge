
using TalentBridge.Entities.Models;


namespace TalentBridge.DataAccess.Interfaces

{
    public interface IUnitOfWork : IDisposable
    {
        IJobRepository Jobs { get; }
        IApplicationRepository Applications { get; }
        IAddedSetionsRepository AddedSections { get; }
        IExtraDataRepository ExtraData { get; }
        IHrJobAssignmentRepository HrJobAssignments { get; }
        IHrRepository Hrs { get; }

        Task<int> CompleteAsync();
    }
}