using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RachioAPI.Models
{
    public class Notification : IRachioData
    {
        public double CreateDate { get; set; }
        public string Id { get; set; }
        public string Url { get; set; }
        public string ExternalId { get; set; }
        public int MyProperty { get; set; }
        public List<EventType> EventTypes { get; set; }
    }

    public class EventType
    {
        public double CreateDate { get; set; }
        public double LastUpdateDate { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
    }
}