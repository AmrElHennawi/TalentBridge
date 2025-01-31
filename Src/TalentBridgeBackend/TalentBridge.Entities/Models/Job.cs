using System.ComponentModel.DataAnnotations;
using TalentBridge.Entities.Enums;

namespace TalentBridge.Entities.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public DateTime? Deadline { get; set; }
        [Range(1, int.MaxValue)]
        public int? ApplicationLimit { get; set; }
        public string Location { get; set; }
        public EmploymentTypes EmploymentType { get; set; }
        [Range(1, 100)]
        public int NumberOfVacancies { get; set; }

        public bool JobState { get; set; } = true;
        public List<HrJobAssignment> HrJobsAssignments { get; set; }
        public List<AddedSections> AddedSections { get; set; }

    }
}
