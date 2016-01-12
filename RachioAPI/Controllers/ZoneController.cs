using RachioAPI.Models;
using RachioAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace RachioAPI.Controllers
{
    [RoutePrefix("public/zone")]
    public class ZoneController : ApiController
    {
        private ZoneRepository zoneRepository;

        public ZoneController()
        {
            this.zoneRepository = new ZoneRepository();
        }

        /// <summary>
        /// Start a Specific Zone or all Zones
        /// </summary>
        /// <param name="zoneRule">The Zone information to start a Zone</param>
        [AcceptVerbs("PUT")]
        public void PutMethod(ZoneRule zoneRule)
        {
            var zoneData = this.zoneRepository.SaveZoneSchedule(zoneRule);

            var response = Request.CreateResponse<IRachioData>(HttpStatusCode.Created, zoneData);
        }
    }
}