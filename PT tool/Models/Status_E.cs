using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PT_tool.Models
{
    public enum Status_E
    {
        Answered,
        [EnumMember(Value = "Waitting for Customer")]
        Waitting_for_Customer
    }
}