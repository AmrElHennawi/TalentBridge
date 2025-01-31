using TalentBridge.Application.DTOs;
using TalentBridge.DataAccess.Interfaces;
using TalentBridge.Entities;

namespace TalentBridge.Application.Services
{
    public class HrService
    {
        private readonly IUnitOfWork _unitOfWork;
        public HrService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<AppUser>> getAllHrs()
        {
            var Hrs = await _unitOfWork.Hrs.GetAllHrsAsync();
            return Hrs;
        }

        public async Task<AppUser> getHr(string id)
        {
            var user = await _unitOfWork.Hrs.GetHrByIdAsync(id);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            return user;
        }

        public async Task<bool> addHr(RegisterationDTO registerData)
        {
            var hr = new AppUser()
            {
                FirstName = registerData.FirstName,
                LastName = registerData.LastName,
                Email = registerData.Email,
                PhoneNumber = registerData.PhoneNumber,
                UserName = registerData.Username,
                ResumePath = string.Empty 
            };

            var createResult = await _unitOfWork.Hrs.CreateHrAsync(hr, registerData.Password);
            return createResult.Succeeded;
        }

        public async Task<bool> updateHr(string id, UpdateInfoDTO registerData)
        {
            bool result = false;
            var hr = await _unitOfWork.Hrs.GetHrByIdAsync(id);
            if (hr == null)
            {
                throw new Exception("User not found.");
            }

            hr.FirstName = registerData.FirstName;
            hr.LastName = registerData.LastName;
            hr.Email = registerData.Email;
            hr.PhoneNumber = registerData.PhoneNumber;
            hr.UserName = registerData.Username;

            var updateResult = await _unitOfWork.Hrs.UpdateHrAsync(hr);
            if (updateResult.Succeeded)
            {
                result = true;
            }

            return result;
        }

        public async Task<bool> removeHr(string id)
        {
            bool result = false;
            var hr = await _unitOfWork.Hrs.GetHrByIdAsync(id);
            if (hr == null)
            {
                throw new Exception("User not found.");
            }

            var deleteResult = await _unitOfWork.Hrs.DeleteHrAsync(hr);
            if (!deleteResult.Succeeded)
            {
                result = true;
            }

            return result;
        }

    }
}
