using Microsoft.AspNetCore.Mvc;
using ResumeMangaer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;
namespace ResumeMangaer.Controllers
{
    public class ResumeController : Controller
    {
        private readonly ApplicationDbContext _Context;
        private readonly IWebHostEnvironment _webHost;
        //private Stream fileStream;

        public ResumeController(ApplicationDbContext Context,IWebHostEnvironment webHost)
        {
            _Context = Context;
            _webHost = webHost;
        }
        public IActionResult Index()
        {
            List<Applicant> applicants;
            applicants = _Context.Applicants.ToList();
            return View(applicants);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Applicant applicant = new Applicant();
            applicant.Experiences.Add(new Experience() { ExperienceId = 1 });
            //applicant.Experiences.Add(new Experience() { ExperienceId = 2 });
            //applicant.Experiences.Add(new Experience() { ExperienceId = 3});
            return View(applicant);
        }
        [HttpPost]
        public IActionResult Create (Applicant applicant)
        {
            string uniqueFileName = GetUploadedFileName(applicant);
            applicant.PhotoUlr = uniqueFileName;
            _Context.Add(applicant);
            _Context.SaveChanges();
            return RedirectToAction("Index");
        }
        public string GetUploadedFileName(Applicant applicant)
        {
            string uniqueFileName = null;
            if (applicant.ProfilePhoto != null)
            {
                string uploadFolder = Path.Combine(_webHost.WebRootPath, "Images");
                 uniqueFileName = Guid.NewGuid().ToString() + "_ " + applicant.ProfilePhoto.FileName;
                string filepath = Path.Combine(uploadFolder, uniqueFileName);
                using (var fileStream = new FileStream(filepath, FileMode.Create)) ;
                {
                    applicant.ProfilePhoto.CopyTo(fileStream);

                }
                
            }
            return uniqueFileName;
        }
    }
}
