using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
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

		public string createToken()
		{
			return _jwtSettings.SecretKey;
		}
	}
}
