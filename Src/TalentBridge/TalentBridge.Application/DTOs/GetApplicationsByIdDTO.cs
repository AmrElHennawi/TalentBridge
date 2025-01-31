

using System.ComponentModel.DataAnnotations;
using TalentBridge.Entities.Enums;

namespace TalentBridge.Application.DTOs
{
    public class GetApplicationsByIdDTO
    {
        public int ApplicationId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Resume { get; set; }

        public string? LinkedIn { get; set; }

        public MilitaryStatusTypes MilitaryStatus { get; set; }

        public int JobId { get; set; }

        public List<GetApplicationExtraDataByIdDTO> ExtraData { get; set; }
    }
}
