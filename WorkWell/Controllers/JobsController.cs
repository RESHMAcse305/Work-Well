using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkWell.Models;

namespace WorkWell.Controllers
{
    public class JobsController : Controller
    {
        JobPortalEntities dbobj = new JobPortalEntities();
        // GET: Jobs
        public ActionResult Index()
        {
            //var jobVacancies = dbobj.Job_vacancies_tbl.ToList();
            var model = new JobSearchViewModel
            {
                JobVacancies = dbobj.Job_vacancies_tbl.Select(job => new JobSearch
                {
                    jobid = job.Job_Id,
                    cid = job.Company_Id,
                    jtitle = job.JobTitle,
                    desc = job.Description,
                    exp = job.Experience,
                    skills = job.Skills,
                    location = job.Location,
                    sal = job.Salary,
                    closedate = job.ClosingDate
                }).ToList()
            };
            return View(model);
        }
        public ActionResult SearchJobs(JobSearchViewModel model)
        {
            var jobVacancies = dbobj.Job_vacancies_tbl.AsQueryable();

            // Apply filters
            if (!string.IsNullOrWhiteSpace(model.Location))
            {
                jobVacancies = jobVacancies.Where(j => j.Location.Contains(model.Location));
            }
            if (!string.IsNullOrWhiteSpace(model.Experience))
            {
                jobVacancies = jobVacancies.Where(j => j.Experience.Contains(model.Experience));
            }
            if (!string.IsNullOrWhiteSpace(model.Skills))
            {
                jobVacancies = jobVacancies.Where(j => j.Skills.Contains(model.Skills));
            }

            // Update model with filtered results
            model.JobVacancies = jobVacancies.Select(job => new JobSearch
            {
                jobid = job.Job_Id,
                cid = job.Company_Id,
                jtitle = job.JobTitle,
                desc = job.Description,
                exp = job.Experience,
                skills = job.Skills,
                location = job.Location,
                sal = job.Salary,
                closedate = job.ClosingDate
            }).ToList();

            return View("Index", model); // Return to Index view with search results
        }

    }
}