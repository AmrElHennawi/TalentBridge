using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace TalentBridge.Entities.Models
{
	public class ExtraData
	{
		[Key] public int AddedSectionsId { get; set; }

		[MaxLength(50)] public string SectionTitle { get; set; }

		public string Data { get; set; }

		public int ApplicationId { get; set; }

		// Navigation property
		public Application Application { get; set; }
	}
}
