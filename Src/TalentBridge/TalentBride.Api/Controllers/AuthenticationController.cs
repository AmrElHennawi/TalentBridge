using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TalentBridge.Application.Services;
using TalentBridge.Entities;

namespace TalentBride.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly TokenService _tokenService;
		private readonly UserManager<AppUser> _userManager;

		public AuthenticationController(TokenService tokenService, UserManager<AppUser> userManager)
		{
			_tokenService = tokenService;
			_userManager = userManager;
		}
		//[HttpPost("login")]
		//[HttpGet]
		//[AllowAnonymous]
		//public async Task<ActionResult> Login()
		//{
            
            //return Ok(_tokenService.GenerateToken(user,true));
		//}

		
	}
}
