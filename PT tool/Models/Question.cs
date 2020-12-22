using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PT_tool.Models
{
    public class Question
    {
        public int id { get; set; }
        public string title { get; set; }
        public string link { get; set; }
        public DateTime create_date { get; set; }
        public string platform { get; set; }

        public int owner_id { get; set; }
        public int answer_count { get; set; }
        public bool is_answered { get; set; }
        public DateTime last_activity_date { get; set; }
       

        public Status_E status { get; set; }

        public int ut { get; set; }
    }



}