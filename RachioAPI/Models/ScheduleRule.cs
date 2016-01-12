using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RachioAPI.Models
{
    public class ScheduleRule : IRachioData
    {
        public string Id { get; set; }
        public List<Zone> Zones { get; set; }
        public List<string> ScheduleJobTypes { get; set; }
        public string Summary { get; set; }
        public bool RainDelay { get; set; }
        public bool WaterBudget { get; set; }
        public string CycleSoakStatus { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public int TotalDuration { get; set; }
        public double WeatherIntelligenceSensitivity { get; set; }
        public int SeasonalAdjustment { get; set; }
        public int Cycles { get; set; }
        public string ExternalName { get; set; }
        public bool CycleSoak { get; set; }
    }

    public class FlexScheduleRule
    {
        public string Id { get; set; }
        public List<Zone> Zones { get; set; }
        public string Summary { get; set; }
        public bool CycleSoak { get; set; }
        public DateTimeOffset? StartDate { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public double TotalDuration { get; set; }
        public double TotalDurationNoCycle { get; set; }
        public string ExternalName { get; set; }
        public string Type { get; set; }
    }
}