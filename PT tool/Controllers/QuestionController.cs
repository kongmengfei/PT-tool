﻿using Newtonsoft.Json;
using PT_tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PT_tool.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult Index()
        {
            return View();
        }

        // GET: Question/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Question/Create
        public ActionResult GetAllQuestions(string start, string end)
        {
            var token = HttpContext.Session["token"];
            //fake data
            var jsontxt = Properties.Resources.demo;
            List<QuestionDetail> questionList = JsonConvert.DeserializeObject<List<QuestionDetail>>(jsontxt);

            
            return PartialView(questionList);
        }

        // POST: Question/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Question/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Question/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Question/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
