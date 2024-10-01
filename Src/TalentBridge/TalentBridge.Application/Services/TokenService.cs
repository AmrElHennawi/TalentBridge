using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TalentBridge.Core.Settings;
using TalentBridge.Entities;



namespace TalentBridge.Application.Services
{
	public class TokenService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly JwtSettings _jwtSettings;

		public TokenService(UserManager<AppUser> userManager, IOptions<JwtSettings> jwtSettings)
		{
			_userManager = userManager;
			_jwtSettings = jwtSettings.Value;
		}

        public async Task<string> GenerateToken(AppUser user,bool rememberMe)
        {
            var roles = await _userManager.GetRolesAsync(user);
            var roleClaims = roles.Select(role => new Claim(ClaimTypes.Role, role));

            var securityKey = _jwtSettings.SecretKey;
            int numberOfDaysToExpire = rememberMe ? 30 : 1;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var token = new JwtSecurityToken(
                claims:roleClaims,
                signingCredentials:creds,
                expires: DateTime.Now.AddDays(numberOfDaysToExpire)
                );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenString;
        }
		//public string createToken()
		//{
		//	return _jwtSettings.SecretKey;
		//}
	}
}
