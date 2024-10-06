using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using TalentBridge.Application.DTOs;
using TalentBridge.Application.Services;
using TalentBridge.Entities;

namespace TalentBride.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
        private readonly AuthenticationService _authenticationService;


        public AuthenticationController(AuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;

		}

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginDTO loginData)
        {
            try
            {
                var token = await _authenticationService.login(loginData);
                return Ok(token);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
	            return BadRequest(ex.Message);
            }
		}

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterationDTO registerData)
        {
	        try
	        {
		        var token = await _authenticationService.register(registerData);
		        return Ok(token);
	        }
	        catch (Exception ex)
	        {
		        return BadRequest(ex.Message);
	        }
		}
	}
}
