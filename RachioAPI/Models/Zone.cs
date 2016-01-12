using RachioAPI.SiteConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RachioAPI.Models
{
    public class Zone : IRachioData
    {
        public string Id { get; set; }
        public int ZoneNumber { get; set; }
        public string Name { get; set; }
        public bool Enabled { get; set; }
        public string EnabledText
        {
            get
            {
                if (Enabled)
                {
                    return TextConstants.BoolConstants.Yes;
                }
                else
                {
                    return TextConstants.BoolConstants.No;
                }
            }
        }
        public CustomNozzle CustomNozzle { get; set; }
        public double AvailableWater { get; set; }
        public double RootZoneDepth { get; set; }
        public double ManagementAllowedDepletion { get; set; }
        public double Efficiency { get; set; }
        public double YardAreaSquareFeet { get; set; }
        public double IrrigationAmount { get; set; }
        public double DepthOfWater { get; set; }
        public double RunTime { get; set; }
    }

    public class ZoneRule : IRachioData
    {
        public string Id { get; set; }
        public string ZoneNumber { get; set; }
        public double Duration { get; set; }
        public int SortOrder { get; set; }
        public List<ZoneRule> Zones { get; set; }
    }
}