using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TalentBridge.Application.DTOs;
using TalentBridge.Entities;

namespace TalentBridge.Application.Services
{
    public class HrService
    {
        private readonly UserManager<AppUser> _userManager;
        public HrService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IEnumerable<AppUser>> getAllHrs()
        {
            var users = await _userManager.Users.ToListAsync();
            var Hrs = new List<AppUser>();

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Hr"))
                {
                    Hrs.Add(user);
                }
            }
            return Hrs;
        }

        public async Task<AppUser> getHr(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }
            var roles = await _userManager.GetRolesAsync(user);
            if (!roles.Contains("Hr"))
            {
                throw new Exception("User is not an HR.");
            }
            return user;
        }

        public async Task<AppUser> addHr(RegisterationDTO registerData)
        {
            var hr = new AppUser()
            {
                FirstName = registerData.FirstName,
                LastName = registerData.LastName,
                Email = registerData.Email,
                PhoneNumber = registerData.PhoneNumber,
                UserName = registerData.Username,
                ResumePath = " "
            };

            var createResult = await _userManager.CreateAsync(hr, registerData.Password);
            if (!createResult.Succeeded)
            {
                throw new Exception("Registration failed: " + string.Join(", ", createResult.Errors.Select(e => e.Description)));
            }


            var addRoleResult = await _userManager.AddToRoleAsync(hr, "Hr");
            if (!addRoleResult.Succeeded)
            {
                throw new Exception("Failed to add HR role to user.");
            }

            return hr;
        }

    }
}
