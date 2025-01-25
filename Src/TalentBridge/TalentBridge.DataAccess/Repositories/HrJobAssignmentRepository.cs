using TalentBridge.DataContext;

namespace TalentBridge.DataAccess.Repositories
{
    public class HrJobAssignmentRepository : BaseRepository<Entities.Models.HrJobAssignment>, Interfaces.IHrJobAssignmentRepository
    {
        public HrJobAssignmentRepository(AppDbContext context) : base(context)
        {
        }
    }

}
