using Microsoft.AspNetCore.Identity;
using TalentBridge.Entities;

namespace TalentBridge.DataAccess.Interfaces
{
    public interface IHrRepository
    {
        Task<IdentityResult> CreateHrAsync(AppUser user, string password);
        Task<AppUser> GetHrByIdAsync(string userId);
        Task<IdentityResult> UpdateHrAsync(AppUser user);
        Task<IdentityResult> DeleteHrAsync(AppUser user);
        Task<IEnumerable<AppUser>> GetAllHrsAsync();

    }
}