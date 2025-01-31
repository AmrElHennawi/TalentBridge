using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TalentBridge.Application.DTOs;
using TalentBridge.Application.Services;
using TalentBridge.Entities.Enums;

namespace TalentBride.Api.Controllers
{
    [Route("api/jobs/{jobId}/applications")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly ApplicationService _applicationService;

        public ApplicationController(ApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost("CreateApplication")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateApplication(AddApplicationDTO addApplicationDto)
        {
            var result = await _applicationService.CreateApplication(addApplicationDto);
            if (!result)
            {
                return BadRequest("Failed to add application.");
            }
            return Ok("Application added successfully.");
        }

        [HttpGet("GetJobApplicationsByStatus")]
        [Authorize(Roles = "Admin,Hr")]
        public async Task<IActionResult> GetJobApplicationsByStatus(int jobId, ApplicationStatus status)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var isHrAssignedJob = await _applicationService.IsHrAssignedToJob(jobId, userId);

            if (!isHrAssignedJob)
            {
                return Unauthorized("You are not authorized to view applications for this job.");
            }

            var applications = await _applicationService.GetJobApplicationsByStatus(jobId, status);
            return Ok(applications);
        }

        [HttpPut("AdvanceApplicationStatus/{applicationId}")]
        [Authorize(Roles = "Admin,Hr")]
        public async Task<IActionResult> AdvanceApplicationStatus(int applicationId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _applicationService.AdvanceApplicationStatus(applicationId, userId);
            if (!result)
            {
                return BadRequest("Failed to advance application status.");
            }
            return Ok("Application status advanced successfully.");
        }


        [HttpPut("RollbackApplicationStatus/{applicationId}")]
        [Authorize(Roles = "Admin,Hr")]
        public async Task<IActionResult> RollbackApplicationStatus(int applicationId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _applicationService.RollbackApplicationStatus(applicationId, userId);
            if (!result)
            {
                return BadRequest("Failed to Rollback application status.");
            }
            return Ok("Application status Rolled back successfully.");
        }

        [HttpPut("RejectApplication/{applicationId}")]
        [Authorize(Roles = "Admin,Hr")]
        public async Task<IActionResult> RejectApplication(int applicationId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _applicationService.RejectApplication(applicationId,userId);
            if (!result)
            {
                return BadRequest("Failed to reject application.");
            }
            return Ok("Application rejected successfully.");
        }

        [HttpPut("RestoreRejectedApplication/{applicationId}")]
        [Authorize(Roles = "Admin,Hr")]
        public async Task<IActionResult> RestoreRejectedApplication(int applicationId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var result = await _applicationService.RestoreRejectedApplication(applicationId,userId);
            if (!result)
            {
                return BadRequest("Failed to restore rejected application.");
            }
            return Ok("Application restore rejected successfully.");
        }

    }
}
