using Microsoft.EntityFrameworkCore;
using TalentBridge.DataAccess.Interfaces;
using TalentBridge.DataContext;
using TalentBridge.Entities.Models;

namespace TalentBridge.DataAccess.Repositories
{
    public class AddedSetionsRepository : BaseRepository<Entities.Models.AddedSections>, IAddedSetionsRepository
    {
        public AddedSetionsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<AddedSections>> GetAddedSectionsByJobId(int JobId)
        {
            return await _context.AddedSections.Where(s => s.JobId == JobId).AsNoTracking().ToListAsync();
        }

        public async Task<string> GetTitleBySectionId(int SectionId)
        {
            return await _context.AddedSections.Where(s => s.AddedSectionsId == SectionId).Select(s => s.SectionTitle).FirstOrDefaultAsync();
        }
    }

}
