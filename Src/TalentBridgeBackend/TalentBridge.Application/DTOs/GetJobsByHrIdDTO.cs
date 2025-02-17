﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentBridge.Entities.Enums;
using TalentBridge.Entities.Models;

namespace TalentBridge.Application.DTOs
{
    public class GetJobsByHrIdDTO
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
        public IEnumerable<AddedSectionsDTO> AddedSections { get; set; }
    }
}
