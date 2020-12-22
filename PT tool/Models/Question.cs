using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PT_tool.Models
{
    public class Question
    {
        public int Qid { get; set; }
        public string Title { get; set; }
        public string T_Link { get; set; }
        public DateTime CreatedDate { get; set; }
       
        public DateTime ModifieddDate { get; set; }

        public DateTime Status { get; set; }
    }



}