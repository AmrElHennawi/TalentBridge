using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentBridge.Entities.Models
{
    public class Hr : AppUser
    {
        public List<HrJobAssignment> HrJobsAssignments { get; set; }
    }
}
