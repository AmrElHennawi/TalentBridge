

using TalentBridge.Application.DTOs;
using TalentBridge.DataAccess.Interfaces;
using TalentBridge.Entities.Enums;
using TalentBridge.Entities.Models;

namespace TalentBridge.Application.Services
{
    public class ApplicationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApplicationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateApplication(AddApplicationDTO addApplicationDto)
        {
            var application = new Entities.Models.Application()
            {
                FirstName = addApplicationDto.FirstName,
                LastName = addApplicationDto.LastName,
                Email = addApplicationDto.Email,
                Phone = addApplicationDto.Phone,
                Resume = "test",
                LinkedIn = addApplicationDto.LinkedIn,
                MilitaryStatus = addApplicationDto.MilitaryStatus,
                Status = addApplicationDto.Status,
                JobSeekerId = addApplicationDto.JobSeekerId,
                JobId = addApplicationDto.JobId,
            };

            await _unitOfWork.Applications.AddAsync(application);
            await _unitOfWork.CompleteAsync();

            foreach (var data in addApplicationDto.extraData)
            {
                var test = new ExtraData()
                {
                    AddedSectionsId = data.AddedSectionsId,
                    Data = data.Data,
                    ApplicationId = application.ApplicationId
                };

                await _unitOfWork.ExtraData.AddAsync(test);
            }

            await _unitOfWork.CompleteAsync();

            return true;
        }


        public async Task<IEnumerable<GetApplicationsByIdDTO>> GetJobApplicationsByStatus(int jobId, ApplicationStatus status)
        {
            var applicationsByJobId = await _unitOfWork.Applications.GetApplicationsByJobIdAndStatus(jobId, status);

            var result = new List<GetApplicationsByIdDTO>();

            foreach (var application in applicationsByJobId)
            {
                var extraDataList = new List<GetApplicationExtraDataByIdDTO>();
                foreach (var extraData in application.ExtraData)
                {
                    var sectionTitle = await _unitOfWork.AddedSections.GetTitleBySectionId(extraData.ApplicationId);
                    extraDataList.Add(new GetApplicationExtraDataByIdDTO
                    {
                        Data = extraData.Data,
                        SectionTitle = sectionTitle
                    });
                }

                result.Add(new GetApplicationsByIdDTO
                {
                    ApplicationId = application.ApplicationId,
                    FirstName = application.FirstName,
                    LastName = application.LastName,
                    Email = application.Email,
                    Phone = application.Phone,
                    Resume = "test",
                    LinkedIn = application.LinkedIn,
                    MilitaryStatus = application.MilitaryStatus,
                    JobId = application.JobId,
                    ExtraData = extraDataList
                });
            }

            return result;
        }

        public async Task<bool> RejectApplication(int applicationId, string userId)
        {
            var application = await _unitOfWork.Applications.GetByIdAsync(applicationId);
            var isHrAssignedJob = await IsHrAssignedToJob(application.JobId, userId);

            if (application == null || isHrAssignedJob)
            {
                return false;
            }

            if (application.Status == ApplicationStatus.Hired)
            {
                return false;
            }
            application.Status = ApplicationStatus.Rejected;

            await _unitOfWork.Applications.UpdateAsync(application);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<bool> AdvanceApplicationStatus(int applicationId, string userId)
        {
            var application = await _unitOfWork.Applications.GetByIdAsync(applicationId);

            var isHrAssignedJob = await IsHrAssignedToJob(application.JobId, userId);

            if (application == null || isHrAssignedJob)
            {
                return false;
            }


            if (application.Status == ApplicationStatus.New)
            {
                application.Status = ApplicationStatus.Interview;
            }
            else if (application.Status == ApplicationStatus.Interview)
            {
                var job = await _unitOfWork.Jobs.GetByIdAsync(application.JobId);
                var HiredCount = await _unitOfWork.Applications.GetHiredCount(application.JobId);
                if (job.ApplicationLimit > HiredCount)
                {
                    application.Status = ApplicationStatus.Hired;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            await _unitOfWork.Applications.UpdateAsync(application);
            await _unitOfWork.CompleteAsync();

            return true;
        }

        public async Task<bool> RestoreRejectedApplication(int applicationId, string userId)
        {

            var application = await _unitOfWork.Applications.GetByIdAsync(applicationId);
            var isHrAssignedJob = await IsHrAssignedToJob(application.JobId, userId);

            if (application == null || isHrAssignedJob)
            {
                return false;
            }

            if (application.Status != ApplicationStatus.Rejected)
            {
                return false;
            }

            application.Status = ApplicationStatus.New;

            await _unitOfWork.Applications.UpdateAsync(application);
            await _unitOfWork.CompleteAsync();

            return true;

        }

        public async Task<bool> RollbackApplicationStatus(int applicationId, string userId)
        {
   
            var application = await _unitOfWork.Applications.GetByIdAsync(applicationId);
            var isHrAssignedJob = await IsHrAssignedToJob(application.JobId, userId);

            if (application == null || !isHrAssignedJob)
            {
                return false;
            }

            if (application.Status == ApplicationStatus.Hired)
            {
                application.Status = ApplicationStatus.Interview;
            }
            else if (application.Status == ApplicationStatus.Interview)
            {
                application.Status = ApplicationStatus.New;
            }
            else
            {
                return false;
            }

            await _unitOfWork.Applications.UpdateAsync(application);
            await _unitOfWork.CompleteAsync();


            return true;
        }


        public async Task<bool> IsHrAssignedToJob(int jobId, string userId)
        {
            return await _unitOfWork.HrJobAssignments.IsHrAssignedToJob(jobId, userId);
        }
    }
}
