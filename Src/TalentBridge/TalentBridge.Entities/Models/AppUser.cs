using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using TalentBridge.Entities.Enums;
using TalentBridge.Entities.Models;

namespace TalentBridge.Entities
{
	public class AppUser: IdentityUser
	{
		[StringLength(50)]
		public string FirstName { get; set; }

		[StringLength(50)]
		public string LastName { get; set; }

		public string ResumePath { get; set; }

		[DataType(DataType.Url)]
		public string? LinkedIn { get; set; }

		public MilitaryStatusTypes MilitaryStatus { get; set; }

		public bool State { get; set; } = true;

		public List<HrJobAssignment> HrJobsAssignments { get; set; }
		public List<Application> Applications { get; set; }

	}
}
