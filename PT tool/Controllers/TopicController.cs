﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PT_tool.Models;
using PT_tool.Models.Unitity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PT_tool.Controllers
{
    [SessionState(System.Web.SessionState.SessionStateBehavior.ReadOnly)]
    public class TopicController : Controller
    {
        const string baseurl = "https://platinumapi-v2.azurewebsites.net";
        private readonly HttpClient httpclient;

        public TopicController()
        {
            httpclient = new HttpClient
            {
                BaseAddress = new Uri(baseurl)
            };
            
            httpclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        // GET: Topic
        public async System.Threading.Tasks.Task<JsonResult> GetTopicsAsync(string platform, int question_id)
        {
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

        // Get supported topic
        public async Task<ActionResult> GetSupportedTopicAsync(string platform, int question_id)
        {
            string token = HttpContext.Session["token"].ToString();
            httpclient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            HttpResponseMessage Res = await httpclient.GetAsync($"/api/Question/SupportTopic?platform={HttpUtility.UrlEncode(platform)}&question_id={question_id}");
            if (Res.IsSuccessStatusCode)
            {
                var root = JObject.Parse(await Res.Content.ReadAsStringAsync());

                string raw = root["support_topic"].Type != JTokenType.Null ? root["support_topic"]["raw"].ToString() : "no topic";

                ViewBag.support_topic = raw;
            }
            else
            {
                ViewBag.support_topic = "request fail: " + Res.StatusCode + "," + Res.ReasonPhrase;
            }
            return PartialView();
        }


        //Topic fake data:
        public ContentResult GetfakeTopics()
        {
            var fakedatajson = Properties.Resources.topic;
            var root = JObject.Parse(fakedatajson);

            var potential_support_topic = root["potential_support_topic"].ToString();
            List<Topic> fake_potential_support_topic_list = JsonConvert.DeserializeObject<List<Topic>>(potential_support_topic);

            string treejson = Tool.ConvertToTreeJson(fake_potential_support_topic_list);

            return Content(treejson, "application/json");
        }


    }
}