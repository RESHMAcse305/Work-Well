using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkWell.Models;
using System.IO;

namespace WorkWell.Controllers
{
    public class Job_ApplyController : Controller
    {
        JobPortalEntities dbobj = new JobPortalEntities();
        // GET: Job_Apply
        public ActionResult jobapply_load(int jid, int cid)
        {
            var application = new JobApplication
            {
                JobId = jid,
                CompanyId = cid
            };
            return View(application);
        }
        public ActionResult job_apply(int jid,int cid, HttpPostedFileBase resume,JobApplication clsobj)
        {
            if (jid <= 0 || cid <= 0)
            {
                TempData["Message"] = "Invalid job ID or company ID.";
                return RedirectToAction("jobapply_load");
            }
            System.Diagnostics.Debug.WriteLine($"Received jid: {jid}, cid: {cid}");

            if (resume != null && resume.ContentLength > 0)
                {
                    string path = Path.Combine(Server.MapPath("~/uploadResume"), Path.GetFileName(resume.FileName));
                    resume.SaveAs(path);

                    var fullpath = Path.Combine("~\\uploadResume", path);
                    clsobj.resume = fullpath;

                int userId = Convert.ToInt32(Session["uid"]);
                    string currentdate = DateTime.Now.ToString("yyyy-MM-dd");

                    if (ModelState.IsValid)
                    {
                        dbobj.sp_jobApplication(userId,cid,jid, clsobj.resume, currentdate,"applied");
                        clsobj.applymsg = "Job application submitted successfully";
                    TempData["Message"] = clsobj.applymsg;

                    return View("jobapply_load", clsobj);  
                    }
                else
                {
                    TempData["Message"] = "Please correct the errors.";
                }
            }
            else
            {
                clsobj.applymsg = "Please upload a valid CV.";
                TempData["Message"] = "CV uploaded successfully.";
            }

           
            return RedirectToAction("jobapply_load");


        }
        
    }
}