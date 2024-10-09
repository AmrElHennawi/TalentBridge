using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TalentBridge.Entities
{
	public class AppUser: IdentityUser
	{
		[StringLength(50)]
		public string FirstName { get; set; }

		[StringLength(50)]
		public string LastName { get; set; }

		public string ResumePath { get; set; }
		
	}
}
