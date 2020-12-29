using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PT_tool.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Status_E
    {
        Answered=8,

        [Description("Waiting for Customer")]
        [EnumMember(Value = "Waiting for Customer")] 
        Waitting_for_Customer =1,

        [EnumMember(Value = "Follow Up")]
        Follow_Up=42,

        [EnumMember(Value = "New Issue")]
        New_Issue =10,

        Researching=4,

        [EnumMember(Value = "Self-Answered")]
        Self_Answered=5
    }
}