using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TalentBridge.Application.DTOs;
using TalentBridge.Application.Services;



namespace TalentBride.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private readonly JobService _jobService;
        public JobController(JobService jobService) {
            _jobService = jobService;
        }

        [HttpPost("AddJob")]
        [Authorize(Roles = "Hr,Admin")]
        public async Task<IActionResult> AddJob(AddJobDTO addJobDto)
        {
            var result = await _jobService.AddJob(addJobDto);
            if (!result)
            {
                return BadRequest("Failed to add job.");
            }
            return Ok("Job added successfully.");
        }

        [HttpGet("GetJob/{id}")]
        public async Task<IActionResult> GetJob(int id)
        {
            var job = await _jobService.GetJob(id);
            if (job == null)
            {
                return NotFound("Job not found.");
            }
            return Ok(job);
        }
        [HttpGet("GetAllJobs")]
        public async Task<IActionResult> GetAllJobs()
        {
            var jobs = await _jobService.GetAllJobs();
            return Ok(jobs);
        }
        [HttpPut("UpdateJob/{id}")]
        public async Task<IActionResult> UpdateJob(int id, UpdateJobDTO updateJobDto)
        {
            var job = await _jobService.GetJob(id);
            if (job == null)
            {
                return NotFound("Job not found.");
            }
            var result = await _jobService.UpdateJob(updateJobDto);
            if (!result)
            {
                return BadRequest("Failed to update job.");
            }
            return Ok("Job updated successfully.");
        }

        [HttpDelete("DeleteJob/{id}")]
        [Authorize(Roles = "Hr,Admin")]
        public async Task<IActionResult> DeleteJob(int id)
        {
            var job = await _jobService.GetJob(id);
            if (job == null)
            {
                return NotFound("Job not found.");
            }
            await _jobService.DeleteJob(id);
            return Ok("Job deleted successfully.");
        }

        [HttpPut("LockJob/{id}")]
        [Authorize(Roles = "Hr,Admin")]
        public async Task<IActionResult> LockJob(int id)
        {
            var result = await _jobService.LockJob(id);
            if (!result)
            {
                return BadRequest("Failed to lock job.");
            }
            return Ok("Job locked successfully.");
        }

        [HttpPut("UnlockJob/{id}")]
        [Authorize(Roles = "Hr,Admin")]
        public async Task<IActionResult> UnlockJob(int id)
        {
            var result = await _jobService.UnlockJob(id);
            if (!result)
            {
                return BadRequest("Failed to unlock job.");
            }
            return Ok("Job unlocked successfully.");
        }

        [HttpGet("GetAssignedJobsByHr/{HrId}")]
        [Authorize(Roles = "Hr,Admin")]
        public async Task<IActionResult> GetAssignedJobsById(string HrId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    
            if (string.IsNullOrEmpty(userId))
            {
                return Unauthorized("Invalid user identity");
            }

            if (!User.IsInRole("Admin") && HrId != userId)
            {
                return Forbid("HR users can only access their own assigned jobs");
            }
            var jobs = await _jobService.GetJobsByHrId(HrId);
            return Ok(jobs);
        }
    }
}
