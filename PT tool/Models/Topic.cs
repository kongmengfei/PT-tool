using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PT_tool.Models
{
    public class Topic
    {
        public int question_id { get; set; }
        public string platform { get; set; }

        public object support_topic { get; set; }
    }
}