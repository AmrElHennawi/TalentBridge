using Microsoft.AspNetCore.Identity;
using TalentBridge.DataAccess.Interfaces;
using TalentBridge.Entities;

namespace TalentBridge.DataAccess.Repositories
{
    public class HrRepository : IHrRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public HrRepository(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IdentityResult> CreateHrAsync(AppUser user, string password)
        {
            // Create the user
            var result = await _userManager.CreateAsync(user, password);
            
            // If successful, add to HR role
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync("HR"))
                {
                    await _roleManager.CreateAsync(new IdentityRole("HR"));
                }
                await _userManager.AddToRoleAsync(user, "HR");
            }
            return result;
        }

        public async Task<AppUser> GetHrByIdAsync(string userId)
        {
            return await _userManager.FindByIdAsync(userId);
        }

        public async Task<IdentityResult> UpdateHrAsync(AppUser user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteHrAsync(AppUser user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<IEnumerable<AppUser>> GetAllHrsAsync()
        {
            // Get users in HR role
            return await _userManager.GetUsersInRoleAsync("HR");
        }
    }
}