using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkWell.Models;


namespace WorkWell.Controllers
{
    public class JobVacancyInsertController : Controller
    {
        JobPortalEntities dbobj = new JobPortalEntities();
        // GET: JobVacancyInsert
        public ActionResult Job_pageload()
        {
            return View();
        }
        public ActionResult AddJob(JobVacancyInsert clsobj)
        {
            int company_Id = Convert.ToInt32(Session["uid"]);
            string currentdate = DateTime.Now.ToString("yyyy-MM-dd");
            if (ModelState.IsValid)
            {
                dbobj.sp_InsertJobVacancy(company_Id, clsobj.jtitle, clsobj.des, clsobj.exp,clsobj.skills,clsobj.jtype, clsobj.location, clsobj.salary, currentdate,clsobj.cdate,"active");
                clsobj.jobmsg = "Jobinserted successfully";
                return View("Job_pageload", clsobj);
            }
            return View("Job_pageload", clsobj);
        }

       
    }
}