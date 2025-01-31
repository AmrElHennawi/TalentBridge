using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Mime;

namespace TalentBridge.Entities.Models
{
	public class ExtraData
	{
		[Key] 
		public int ExtraDataId { get; set; }

		[MaxLength(50)] 
		public int AddedSectionsId { get; set; }

		public string Data { get; set; }

		public int ApplicationId { get; set; }

		public Application Application { get; set; }
	}
}
