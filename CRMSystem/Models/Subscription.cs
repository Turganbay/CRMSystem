using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRMSystem.Models
{
    public class Subscription
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int event_id { get; set; }
        public string user_name { get; set; }
        public string event_name { get; set; }
    }
}