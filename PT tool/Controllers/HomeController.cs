using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PT_tool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Settings(string token)
        {
            

            return View();
        }

        [HttpPost]
        public RedirectResult SetSettings(string token)
        {
            ViewBag.Message = "This is Settings page.";
            HttpContext.Session["token"] = "Bearer " + token;

            return RedirectResult
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}