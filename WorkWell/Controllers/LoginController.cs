using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkWell.Models;

namespace WorkWell.Controllers
{
    public class LoginController : Controller
    {
        JobPortalEntities dbobj = new JobPortalEntities();
        // GET: Login
        public ActionResult Login_PageLoad()
        {
            return View();
        }
        public ActionResult UserHome()
        {
            return View();
        }
        public ActionResult AdminHome()
        {
            return View();
        }
        public ActionResult Login_click(LoginCls clsobj)
        {
            if (ModelState.IsValid)
            {
                ObjectParameter op = new ObjectParameter("status", typeof(int));
                dbobj.sp_login(clsobj.Uname, clsobj.pass, op);
                int val = Convert.ToInt32(op.Value);
                if (val == 1)
                {
                    var uid = dbobj.sp_loginId(clsobj.Uname, clsobj.pass).FirstOrDefault();
                    Session["uid"] = uid;
                    var Utype = dbobj.sp_logintype(clsobj.Uname, clsobj.pass).FirstOrDefault();
                    if(Utype == "user")
                    {
                        return RedirectToAction("UserHome");
                    }
                    else if (Utype == "admin")
                    {
                        return RedirectToAction("AdminHome");
                    }
                }
            }
            else
            {
                ModelState.Clear();
                clsobj.msg = "invalid login";
                return View("Login_PageLoad",clsobj);

            }
            return View("Login_PageLoad", clsobj);
        }
    }
}