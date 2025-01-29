using Microsoft.AspNetCore.Http.HttpResults;
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
        [HttpGet("GetJobs")]
        public async Task<IActionResult> GetJobs()
        {
            var jobs = await _jobService.GetJobs();
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
            var result = await _jobService.UpdateJob(id, updateJobDto);
            if (!result)
            {
                return BadRequest("Failed to update job.");
            }
            return Ok("Job updated successfully.");
        }
        [HttpDelete("DeleteJob/{id}")]
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

    }
}
