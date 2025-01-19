using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentBridge.Entities.Models
{
    public class HrJobAssignment
    {
        public string HrId { get; set; }
        public Hr Hr { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
    }
}
