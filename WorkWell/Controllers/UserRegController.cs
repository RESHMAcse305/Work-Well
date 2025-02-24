using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WorkWell.Models;
namespace WorkWell.Controllers
{
    public class UserRegController : Controller
    {
        JobPortalEntities dbobj = new JobPortalEntities();

        // GET: UserReg
        public ActionResult User_pageload()
        {
            return View();
        }
        public ActionResult User_Insert(UserInsert clsobj,HttpPostedFileBase photoFile,HttpPostedFileBase resumeFile)
        {
            if (ModelState.IsValid)
            {
               
                if (resumeFile != null && resumeFile.ContentLength > 0)
                {
                    string resumepath  = Path.GetFileName(resumeFile.FileName);
                    var cv = Server.MapPath("~/Resume");
                    string res = Path.Combine(cv, resumepath);
                    resumeFile.SaveAs(res);

                    var fullpath = Path.Combine("~\\Resume", resumepath);
                    clsobj.resume= fullpath;
                }
                if (photoFile != null && photoFile.ContentLength > 0)
                {
                    string fname = Path.GetFileName(photoFile.FileName);
                    var s = Server.MapPath("~/Photos");
                    string pa = Path.Combine(s, fname);
                    photoFile.SaveAs(pa);

                    var fullpath = Path.Combine("~\\Photos", fname);
                    clsobj.photo = fullpath;
                }
                var getmaxid = dbobj.sp_maxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if (mid == 0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_UserInsert(regid, clsobj.name, clsobj.age, clsobj.add, clsobj.phone, clsobj.email, clsobj.exp, clsobj.skills, clsobj.resume, clsobj.dob, clsobj.photo);
                dbobj.sp_logininsert(regid, clsobj.username, clsobj.pass, "user");
                clsobj.Usermsg = "inserted successfully";
                return View("User_pageload", clsobj);


            }
            return View("User_pageload", clsobj);
        }
    }
}