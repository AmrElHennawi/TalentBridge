using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalentBridge.Application.DTOs;
using TalentBridge.Application.Services;

namespace TalentBride.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class HrController : ControllerBase
	{
		private readonly HrService _hrService;

		public HrController(HrService hrService)
		{
			_hrService = hrService;
		}

		[HttpGet("GetAllHrs")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetAllHrs()
		{
			var Hrs = await _hrService.getAllHrs();
			return Ok(Hrs);
		}

		[HttpGet("GetHr/{id}")]
		[Authorize(Roles = "Hr,Admin")]
		public async Task<IActionResult> GetHr(string id)
		{
			var userRole = User.FindFirstValue(ClaimTypes.Role);
			if (userRole == "Hr" && (User.FindFirstValue(ClaimTypes.NameIdentifier) != id))
			{
				return Forbid();
			}

			var Hr = await _hrService.getHr(id);
			return Ok(Hr);
		}

		[HttpPost("AddHr")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> AddHr(RegisterationDTO hr)
		{
			var result = await _hrService.addHr(hr);
			if (!result)
			{
				return BadRequest("Failed to add HR.");
			}
			return Ok("HR added successfully.");

		}


		[HttpPut("UpdateHr/{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> UpdateHr(string id, UpdateInfoDTO hr)
		{

			var result = await _hrService.updateHr(id, hr);
			if (!result)
			{
				return BadRequest("Failed to update HR.");
			}
			return Ok("HR updated successfully.");

		}

		[HttpDelete("RemoveHr/{id}")]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> RemoveHr(string id)
		{

				var result = await _hrService.removeHr(id);
			if (!result)
			{
				return BadRequest("Failed to delete HR.");
			}
			return Ok("HR deleted successfully.");


		}
	}
}
