using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PT_tool.Models
{
    public class QuestionTopic
    {
        public int question_id { get; set; }
        public string platform { get; set; }

        public Topic support_topic { get; set; }

        public List<Topic> potential_support_topic { get; set; }
    }
}