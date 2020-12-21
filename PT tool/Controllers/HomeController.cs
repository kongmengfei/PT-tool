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

        [HttpGet]
        public ActionResult Settings()
        {
            if (HttpContext.Session["token"] is null || string.IsNullOrEmpty( HttpContext.Session["token"].ToString()))
            {
                ViewBag.token = "Please Enter your Token !";
            }
            else
            {
                ViewBag.token = HttpContext.Session["token"];
            }

            return View();
        }

        [HttpPost]
        public ActionResult SetSettings(string token)
        {
            ViewBag.Message = "This is Settings page.";
            HttpContext.Session["token"] = "Bearer " + token;

            return RedirectToAction("GetRangQuestion", "Question");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}