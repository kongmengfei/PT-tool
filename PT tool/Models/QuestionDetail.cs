using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PT_tool.Models
{
    public class QuestionDetail
    {
        [JsonProperty]
        public Question question { get; set; }

        [JsonProperty]
        public Owner owner { get; set; }

    }
}