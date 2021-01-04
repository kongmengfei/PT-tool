using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace PT_tool.Controllers
{
    public class TopicController : Controller
    {
        const string baseurl = "https://platinumapi-v2.azurewebsites.net/api/Question";
        // GET: Topic
        public async System.Threading.Tasks.Task<JsonResult> GetAsync(string platform, int question_id)
        {
            string token = HttpContext.Session["token"].ToString();
            using (var httpclient = new HttpClient()
            {
                BaseAddress = new Uri(baseurl)
            }
            )
            {
                httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await httpclient.GetAsync($"/SupportTopic?platform={platform}&question_id={question_id}");
                if (Res.IsSuccessStatusCode)
                {

                    return Json(Res.Content);
                }
                else
                {
                    return Json(Res);
                }

            }
        }
    }
}