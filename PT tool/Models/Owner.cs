using System;

namespace PT_tool.Models
{
    public class Owner
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string alias { get; set; }
        public bool active { get; set; }
        public DateTime created_at { get; set; }
        public string updated_by { get; set; }
        public DateTime updated_at { get; set; }
        public object[] roles { get; set; }
        public object[] forum_profiles { get; set; }
        public object[] teams { get; set; }
        public object[] subscriptions { get; set; }
        public object[] products { get; set; }
    }
}