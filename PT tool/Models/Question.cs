using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PT_tool.Models
{
    [JsonObjectAttribute("question")]
    public class Question
    {
        [JsonProperty]
        public int id { get; set; }

        [JsonProperty]
        public string title { get; set; }

        [JsonProperty]
        public string link { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime create_date { get; set; }
        public string platform { get; set; }

        public int owner_id { get; set; }
        public int answer_count { get; set; }
        public bool is_answered { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime last_activity_date { get; set; }

        [JsonProperty("status")]
        [JsonConverter(typeof(StringEnumConverter))]
        public Status_E status { get; set; }

        public int ut { get; set; }
    }



}