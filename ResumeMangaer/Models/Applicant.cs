using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ResumeMangaer.Models
{
    public class Applicant
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Gender  { get; set; }
        [Required]
        [Range(25,55,ErrorMessage ="Currently ,We have no position vacant for your age")]
        [DisplayName("Age in Years")]
        public int Age { get; set; }
        [Required]
        [StringLength(10)]
        public string Qualification { get; set; }
        [Required]
        [Range(2, 55, ErrorMessage = "Currently ,We have no position vacant for your Experience")]
        [DisplayName("Total experience in Years")]
        public int TotalExperience { get; set; }
        public virtual List<Experience> Experiences { get; set; } = new List<Experience>();
        public string  PhotoUlr { get; set; }
        [Required(ErrorMessage ="Please choose the Profile Photo")]
        [Display(Name ="Profile photo")]
        [NotMapped]
        public IFormFile ProfilePhoto { get; set; }
    }
}
