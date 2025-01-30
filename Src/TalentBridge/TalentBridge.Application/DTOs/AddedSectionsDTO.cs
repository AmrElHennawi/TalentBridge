using System.ComponentModel.DataAnnotations;
using TalentBridge.Entities.Enums;

namespace TalentBridge.Application.DTOs
{
	public class AddedSectionsDTO
	{
		[MaxLength(50)]
		public string SectionTitle { get; set; }

		public SectionTypes SectionType { get; set; }

	}
}
