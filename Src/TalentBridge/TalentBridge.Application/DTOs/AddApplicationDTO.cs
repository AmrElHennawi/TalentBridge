using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TalentBridge.Entities.Enums;
using TalentBridge.Entities.Models;

namespace TalentBridge.Application.DTOs
{
    public class AddApplicationDTO
    {
        [MaxLength(50)]
        public string FirstName { get; set; }

        [MaxLength(50)]
        public string LastName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string Resume { get; set; }

        [DataType(DataType.Url)]
        public string? LinkedIn { get; set; }

        public MilitaryStatusTypes MilitaryStatus { get; set; }

        public ApplicationStatus Status { get; set; } = ApplicationStatus.New;

        public string? JobSeekerId { get; set; }

        public int JobId { get; set; }

        public List<ExtraDataDTO> extraData { get; set; }
    }
}
