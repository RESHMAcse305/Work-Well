using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkWell.Models;
namespace WorkWell.Controllers
{
    public class CompanyRegController : Controller
    {
        JobPortalEntities dbobj = new JobPortalEntities();
        // GET: CompanyReg
        public ActionResult Insert_pageload()
        {
            return View();
        }
        public ActionResult Insert_click(CompanyInsert clsobj)
        {
            if (ModelState.IsValid)
            {
                var getmaxid = dbobj.sp_maxIdLogin().FirstOrDefault();
                int mid = Convert.ToInt32(getmaxid);
                int regid = 0;
                if(mid==0)
                {
                    regid = 1;
                }
                else
                {
                    regid = mid + 1;
                }
                dbobj.sp_CompanyInsert(regid, clsobj.cname, clsobj.cadd, clsobj.cphone, clsobj.cemail);
                dbobj.sp_logininsert(regid, clsobj.username, clsobj.pass, "admin");
                clsobj.admsg = "inseerted successfully";
                return View("Insert_pageload", clsobj);
            }
            return View("Insert_pageload",clsobj);
        }
    }
}