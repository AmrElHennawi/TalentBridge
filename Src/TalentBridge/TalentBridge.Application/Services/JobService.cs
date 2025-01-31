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
        private readonly UserManager<AppUser> _userManager;

        public JobService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<bool> AddJob(AddJobDTO addJobDto)
        {
            var job = new Job()
            {
                Title = addJobDto.Title,
                Description = addJobDto.Description,
                Requirements = addJobDto.Requirements,
                Deadline = addJobDto.Deadline,
                ApplicationLimit = addJobDto.ApplicationLimit,
                Location = addJobDto.Location,
                EmploymentType = addJobDto.EmploymentType,
                NumberOfVacancies = addJobDto.NumberOfVacancies,
                JobState = addJobDto.JobState,
            };


            await _unitOfWork.Jobs.AddAsync(job);
            await _unitOfWork.CompleteAsync();


            foreach (var addedSection in addJobDto.AddedSections)
            {
                await _unitOfWork.AddedSections.AddAsync(new AddedSections
                {
                    JobId = job.Id,
                    SectionType = addedSection.SectionType,
                    SectionTitle = addedSection.SectionTitle
                });
            }

            await _unitOfWork.CompleteAsync();



            var hrUsers = await _userManager.GetUsersInRoleAsync("Hr");
            var AdminUsers = await _userManager.GetUsersInRoleAsync("Admin");
            var validHrs = hrUsers.Where(u => addJobDto.AssignedHrIds.Contains(u.Id)).ToList();

            if (validHrs.Count != addJobDto.AssignedHrIds.Count)
                return false;

            foreach (var hr in validHrs)
            {
                await _unitOfWork.HrJobAssignments.AddAsync(new HrJobAssignment
                {
                    JobId = job.Id,
                    HrId = hr.Id
                });
            }

            foreach (var Admin in AdminUsers)
            {
                await _unitOfWork.HrJobAssignments.AddAsync(new HrJobAssignment
                {
                    JobId = job.Id,
                    HrId = Admin.Id
                });
            }

            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<Job> GetJob(int jobId)
        {
            return await _unitOfWork.Jobs.GetByIdAsync(jobId);
        }

        public async Task<IEnumerable<GetJobsByHrIdDTO>> GetAllJobs()
        {
            var jobsByHrId = await _unitOfWork.Jobs.GetAllJobs();
            IEnumerable<GetJobsByHrIdDTO> jobs = jobsByHrId.Select(j => new GetJobsByHrIdDTO
            {
                Id = j.Id,
                Title = j.Title,
                Description = j.Description,
                Requirements = j.Requirements,
                Deadline = j.Deadline,
                ApplicationLimit = j.ApplicationLimit,
                Location = j.Location,
                EmploymentType = j.EmploymentType,
                NumberOfVacancies = j.NumberOfVacancies,
                JobState = j.JobState,
                AddedSections = j.AddedSections.Select(s => new AddedSectionsDTO
                {
                    SectionType = s.SectionType,
                    SectionTitle = s.SectionTitle
                }).ToList()
            }).ToList();

            return jobs;
        }

        public async Task<bool> UpdateJob(UpdateJobDTO updateJobDto)
        {
            var oldJob = await _unitOfWork.Jobs.GetByIdAsync(updateJobDto.Id);
            if (oldJob == null)
            {
                return false;
            }

            var updatedJob = new Job()
            {
                Id = updateJobDto.Id,
                Title = updateJobDto.Title,
                Description = updateJobDto.Description,
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
            await _unitOfWork.CompleteAsync();
            return true;
        }

        public async Task<bool> DeleteJob(int jobId)
        {
            var job = await _unitOfWork.Jobs.GetByIdAsync(jobId);
            if (job == null)
                return false;

            await _unitOfWork.Jobs.DeleteAsync(jobId);
            await _unitOfWork.CompleteAsync();
            return true;
        }
        public async Task<bool> LockJob(int jobId)
        {
            var job = await _unitOfWork.Jobs.GetByIdAsync(jobId);
            if (job == null)
                return false;
            job.JobState = false;
            await _unitOfWork.Jobs.UpdateAsync(job);
            await _unitOfWork.CompleteAsync();
            return true;

        }
        public async Task<bool> UnlockJob(int jobId)
        {
            var job = await _unitOfWork.Jobs.GetByIdAsync(jobId);
            if (job == null)
                return false;
            job.JobState = true;
            await _unitOfWork.Jobs.UpdateAsync(job);
            await _unitOfWork.CompleteAsync();
            return true;

        }

        public async Task<IEnumerable<GetJobsByHrIdDTO>> GetJobsByHrId(string hrId)
        {
            var jobsByHrId = await _unitOfWork.Jobs.GetJobsByHrId(hrId);
            IEnumerable<GetJobsByHrIdDTO> jobs = jobsByHrId.Select(j => new GetJobsByHrIdDTO
            {
                Id = j.Id,
                Title = j.Title,
                Description = j.Description,
                Requirements = j.Requirements,
                Deadline = j.Deadline,
                ApplicationLimit = j.ApplicationLimit,
                Location = j.Location,
                EmploymentType = j.EmploymentType,
                NumberOfVacancies = j.NumberOfVacancies,
                JobState = j.JobState,
                AddedSections = j.AddedSections.Select(s => new AddedSectionsDTO
                {
                    SectionType = s.SectionType,
                    SectionTitle = s.SectionTitle
                }).ToList()
            }).ToList();

            return jobs;
        }

    }
}
