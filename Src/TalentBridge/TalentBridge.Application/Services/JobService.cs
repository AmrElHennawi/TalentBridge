using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TalentBridge.Application.DTOs;
using TalentBridge.DataAccess.Interfaces;
using TalentBridge.Entities;
using TalentBridge.Entities.Models;

namespace TalentBridge.Application.Services
{
    public class JobService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHrRepository _hrRepository;
        private readonly UserManager<AppUser> _userManager;

        public JobService(IUnitOfWork unitOfWork, IHrRepository hrRepository, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _hrRepository = hrRepository;
            _userManager = userManager;
        }

        public async Task<bool> AddJob(AddJobDTO addJobDto)
        {
            var addedJob = new Job()
            {
                Title = addJobDto.Title,
                Describtion = addJobDto.Describtion,
                Requirements = addJobDto.Requirements,
                Deadline = addJobDto.Deadline,
                ApplicationLimit = addJobDto.ApplicationLimit,
                Location = addJobDto.Location,
                EmploymentType = addJobDto.EmploymentType,
                NumberOfVacancies = addJobDto.NumberOfVacancies,
                JobState = addJobDto.JobState,
                AddedSections = addJobDto.AddedSections
            };
            foreach (var assignedHr in addJobDto.AssignedHrs)
            {
                if (await _userManager.IsInRoleAsync(assignedHr, "Hr"))
                {
                    addedJob.HrJobsAssignments.Add(new HrJobAssignment()
                    {
                        JobId = addedJob.Id,
                        HrId = assignedHr.Id
                    });
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<Job> GetJob(int jobId)
        {
            return await _unitOfWork.Jobs.GetByIdAsync(jobId);
        }
        public async Task<IEnumerable<Job>> GetJobs()
        {
            return await _unitOfWork.Jobs.GetAllAsync();
        }
        public async Task<bool> UpdateJob(int jobId, UpdateJobDTO updateJobDto)
        {
            var oldJob = await _unitOfWork.Jobs.GetByIdAsync(jobId);
            if (oldJob == null)
                return false;
            var updatedJob = new Job()
            {
                Id = jobId,
                Title = updateJobDto.Title,
                Describtion = updateJobDto.Describtion,
                Requirements = updateJobDto.Requirements,
                Deadline = updateJobDto.Deadline,
                ApplicationLimit = updateJobDto.ApplicationLimit,
                Location = updateJobDto.Location,
                EmploymentType = updateJobDto.EmploymentType,
                NumberOfVacancies = updateJobDto.NumberOfVacancies,
                JobState = updateJobDto.JobState,
                AddedSections = updateJobDto.AddedSections
            };
            await _unitOfWork.Jobs.UpdateAsync(updatedJob);
            return true;
        }
        public async Task<bool> DeleteJob(int jobId)
        {
            var job = await _unitOfWork.Jobs.GetByIdAsync(jobId);
            if (job == null)
                return false;
            
            await _unitOfWork.Jobs.DeleteAsync(jobId);
            return true;
        }

        
    }
}
