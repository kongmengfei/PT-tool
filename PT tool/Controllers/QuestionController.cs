using Newtonsoft.Json;
using PT_tool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
      
        public async System.Threading.Tasks.Task<ActionResult> GetAllQuestionsAsync(string start, string end, string subscriptions)
        {
            var token = HttpContext.Session["token"].ToString();
            string baseurl = "https://platinumapi-v2.azurewebsites.net/api/Question";

            //fake data
            //var jsontxt = Properties.Resources.demo;
            //List<QuestionDetail> questionList = JsonConvert.DeserializeObject<List<QuestionDetail>>(jsontxt);

            using (var httpclient = new HttpClient())
            {                
                httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsImtpZCI6IjVPZjlQNUY5Z0NDd0NtRjJCT0hIeEREUS1EayJ9.eyJhdWQiOiI3NzA1ZWNjNC1kZTExLTQ3ZWEtODgxYy04YzJkODVjMDQ2MTYiLCJpc3MiOiJodHRwczovL2xvZ2luLm1pY3Jvc29mdG9ubGluZS5jb20vNzJmOTg4YmYtODZmMS00MWFmLTkxYWItMmQ3Y2QwMTFkYjQ3L3YyLjAiLCJpYXQiOjE2MDk4MTM1NjYsIm5iZiI6MTYwOTgxMzU2NiwiZXhwIjoxNjA5ODE3NDY2LCJhaW8iOiJBVlFBcS84U0FBQUFsd2tEL1pFVFQ2Z1dLTWJxMDA0aFl2bUsvOVBWMzFVWXY5UmZ4OEpDTE1zRjZNRVo0QTlRQ3QxUXBLNzM2SUFwZVlvcVVRWG5sdUU0NVZlV0JXc3pzdzZ5SzMxM1J2WHNUeWZnL2tnNjgxRT0iLCJuYW1lIjoiQmFrZXIgS29uZyAoU2hhbmdoYWkgV2ljcmVzb2Z0IENvLC5MdGQuKSIsIm5vbmNlIjoiMWZjYjZmNTAtNTU5ZS00NmQ4LTgyNzktNzNiY2UyOTdhYjE1Iiwib2lkIjoiOWMyODY5NDQtMTg5NS00Y2I4LTljODYtNmZiNDYyMzNmNWZkIiwicHJlZmVycmVkX3VzZXJuYW1lIjoidi1tZWtvbmdAbWljcm9zb2Z0LmNvbSIsInJoIjoiMC5BUm9BdjRqNWN2R0dyMEdScXkxODBCSGJSOFRzQlhjUjN1cEhpQnlNTFlYQVJoWWFBTzAuIiwic3ViIjoiZjVWQjlLTi1sdV9UeWk4dDhRTUx4eHcxR2d6WHZweVpmaThONjVYTm1yMCIsInRpZCI6IjcyZjk4OGJmLTg2ZjEtNDFhZi05MWFiLTJkN2NkMDExZGI0NyIsInV0aSI6IlhzS2sxMjVnUjBhMTlEaDJTanh0QWciLCJ2ZXIiOiIyLjAifQ.yP1kEPi9BcUmJDhqqa1-ubo1TmFkFBteSehXadRZTyhShS64utpUm1Mron04y96nPyrgXz9Fx2XFYEQi-h91poZOezRk1a624LqrASQAJn69FSrAQ6e2OybbIGjgaYEuxrVQ92esEVjjO1jRjmUcdqtFPKS0VvT_27ZKQradmCas5JXukNok6fAPB61cIh4YDsWew1LjCE_tYwRU5Sdwa00Z6Fig3U4XTDYXx7asWBEHEdtFNqkcph5I4AJojndBhJhIB6dOBfjT4MAS09c5hCpsR0-D2W7an9DS5e_M0o6Jg2jbcYdaM7lPrxp2IKIoWQ8F1KFFPOTXTj2B_kfMIA");
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
