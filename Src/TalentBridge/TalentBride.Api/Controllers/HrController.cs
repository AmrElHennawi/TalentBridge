﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalentBridge.Application.DTOs;
using TalentBridge.Application.Services;

namespace TalentBride.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	 
	[Authorize(Roles = "Admin")]
	public class HrController : ControllerBase
	{
		private readonly HrService _hrService;

		public HrController(HrService hrService)
		{
			_hrService = hrService;
		}

		[HttpGet("GetAllHrs")]
		public async Task<IActionResult> GetAllHrs()
		{
			var Hrs = await _hrService.getAllHrs();
			return Ok(Hrs);
		}

		[HttpGet("GetHr/{id}")]
		public async Task<IActionResult> GetHr(string id)
		{
			var Hr = await _hrService.getHr(id);
			return Ok(Hr);
		}

		[HttpPost("AddHr")]
		public async Task<IActionResult> AddHr(RegisterationDTO hr)
		{
			try
			{
				var addedHr = await _hrService.addHr(hr);
				return Ok(addedHr);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


		[HttpPut("UpdateHr/{id}")]
		public async Task<IActionResult> UpdateHr(string id, UpdateInfoDTO hr)
		{
			try
			{
				var updatedHr = await _hrService.updateHr(id, hr);
				return Ok(updatedHr);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		[HttpDelete("RemoveHr/{id}")]
		public async Task<IActionResult> RemoveHr(string id)
		{
			try
			{
				await _hrService.removeHr(id);
				return Ok("HR deleted successfully.");
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}
}
