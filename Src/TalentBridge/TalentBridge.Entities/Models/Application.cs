using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TalentBridge.Entities.Enums;

namespace TalentBridge.Entities.Models
{
	public class Application
	{
		[Key]
		public int ApplicationId { get; set; }

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

		[ForeignKey("AppUser")]
		public string? JobSeekerId { get; set; }

		[ForeignKey("Job")]
        public int JobId { get; set; }


		public AppUser JobSeeker { get; set; } 

		public Job Job { get; set; } 

		public List<ExtraData> ExtraData { get; set; }
	}
}
