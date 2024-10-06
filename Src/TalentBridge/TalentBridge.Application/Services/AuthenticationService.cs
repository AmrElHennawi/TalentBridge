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

        
        public async Task<string> login(LoginDTO loginData)
        {
            var user = await _userManager.FindByEmailAsync(loginData.Email);
            if (user != null && await _userManager.CheckPasswordAsync(user, loginData.Password))
            {
                var tokenString = await _tokenService.GenerateToken(user, loginData.RememberMe);
                return tokenString;
            }
            throw new UnauthorizedAccessException("Invalid login credentials.");
        }

        public async Task<string> register(RegisterationDTO registerData)
        {
	        var user = new AppUser()
	        {
		        FirstName = registerData.FirstName,
		        LastName = registerData.LastName,
		        Email = registerData.Email,
		        PasswordHash = registerData.Password,
		        PhoneNumber = registerData.PhoneNumber,
		        UserName = registerData.Username,
				ResumePath = " "
	        };

	        var result = await _userManager.CreateAsync(user, registerData.Password);
	        if (!result.Succeeded)
	        {
		        throw new Exception("Registration failed: " + string.Join(", ", result.Errors.Select(e => e.Description)));
	        }

	        await _userManager.AddToRoleAsync(user, "User");

	        var newUserData = new LoginDTO()
			{
		        Email = registerData.Email,
		        Password = registerData.Password,
		        RememberMe = true
	        };

	        return await login(newUserData);
		}
    }
}
