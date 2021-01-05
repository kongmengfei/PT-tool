using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PT_tool.Models
{
    public class Topic
    {
        public int id { get; set; }
        public string name { get; set; }
        public string raw { get; set; }
        
        public List<Topic> children { get; set; }


    }
}