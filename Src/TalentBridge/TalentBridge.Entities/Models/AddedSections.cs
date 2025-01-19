using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentBridge.Entities.Enums;

namespace TalentBridge.Entities.Models
{
	public class AddedSections
	{
		[Key]
		public int AddedSectionsId { get; set; }

		[MaxLength(50)]
		public string SectionTitle { get; set; } 

		public SectionTypes SectionType { get; set; }

		public int JobId { get; set; }

		public Job Job { get; set; }
	}
}
