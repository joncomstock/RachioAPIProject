using RachioAPI.Extensions;
using RachioAPI.Models;
using RestSharp;
using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RachioAPI.Services
{
    public class ZoneRepository
    {

        private const string CacheKey = "ZoneStore";

        public ZoneRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var persons = new Zone[]
                    {
                        new Zone
                        {
                            Id = "",
                            ZoneNumber = 0,
                            Name = "",
                            Enabled = true,
                            CustomNozzle = new CustomNozzle(),
                            AvailableWater = 0,
                            RootZoneDepth = 0,
                            ManagementAllowedDepletion = 0,
                            Efficiency = 0,
                            YardAreaSquareFeet = 0,
                            IrrigationAmount = 0,
                            DepthOfWater = 0,
                            RunTime = 0
                        }
                    };

                    ctx.Cache[CacheKey] = persons;
                }
            }
        }

        /// <summary>
        /// Retrieves the Rachio Person Info Data i.e. the id
        /// </summary>
        /// <returns>The deserialized Person data or empty if it fails CheckStatus</returns>
        public IRachioData SaveZoneSchedule(IRachioData zone)
        {
            return RestSharpExtensions.ExecuteAPICall<IRachioData>(zone, "public/person/start", Method.PUT);
        }
    }
}