using Newtonsoft.Json;
using PT_tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
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
      
        public async Task<ActionResult> GetAllQuestionsAsync(string start, string end, string subscriptions)
        {
            string token = HttpContext.Session["token"] as string;
            string baseurl = "https://platinumapi-v2.azurewebsites.net/api/Question";

            //fake data
            //var jsontxt = Properties.Resources.demo;
            //List<QuestionDetail> questionList = JsonConvert.DeserializeObject<List<QuestionDetail>>(jsontxt);

            using (var httpclient = new HttpClient())
            {                
                httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await httpclient.GetAsync($"{baseurl}/view2?start={start}&end={end}&subscriptions={subscriptions}&owner=ownedbyme&orderby=create_date");
                Res.EnsureSuccessStatusCode();
                string jsontxt = await Res.Content.ReadAsStringAsync();
                List<QuestionDetail> questionList = JsonConvert.DeserializeObject<List<QuestionDetail>>(jsontxt);
                return PartialView(questionList);
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
