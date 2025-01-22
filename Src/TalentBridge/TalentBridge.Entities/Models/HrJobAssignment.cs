using System.ComponentModel.DataAnnotations;

namespace TalentBridge.Entities.Models
{
    public class HrJobAssignment
    {
        [Key]
        public int HrJobAssignmentId { get; set; }
        public string HrId { get; set; }

        public int JobId { get; set; }

        public AppUser Hr { get; set; }
        public Job Job { get; set; }
    }
}
