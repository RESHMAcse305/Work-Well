using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WorkWell.Models;

namespace WorkWell.Controllers
{
    public class SearchController : Controller
    {
        JobPortalEntities dbobj = new JobPortalEntities();
        // GET: Search
        public ActionResult search_load()
        {
            return View();
        }
        public ActionResult Search_click(DetailsSearch clsobj)
        {

            return View();
        }
    }
}