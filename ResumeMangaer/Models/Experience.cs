﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeMangaer.Models
{
    public class Experience
    {
        public Experience()
        {

        }
        [Key]
        public int ExperienceId { get; set; }
        [ForeignKey("Applicant")]
        public int ApplicantId { get; set; }
        public virtual Applicant Applicaint { get; private set; }
        public string  CompanyName { get; set; }
        public string Designation { get; set; }
        public int YearWorked{ get; set; }

    }
}
