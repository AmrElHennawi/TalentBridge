using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TalentBridge.Application.DTOs;
using TalentBridge.Entities;

namespace TalentBridge.Application.Services
{
	public class AuthenticationService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenService;
        public AuthenticationService(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, TokenService tokenService)
		{
			_userManager = userManager;
			_signInManager = signInManager;
            _tokenService = tokenService;
		}

        
        public async Task<string> Login(LoginDTO loginData)
        {
            var user = await _userManager.FindByEmailAsync(loginData.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginData.Password))
            {
                var tokenString = await _tokenService.GenerateToken(user, loginData.RemeberMe);
                return tokenString;
            }
            throw new UnauthorizedAccessException("Invalid login credentials.");
        }

    }
}
