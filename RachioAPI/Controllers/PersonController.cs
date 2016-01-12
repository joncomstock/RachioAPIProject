using RachioAPI.Models;
using RachioAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RachioAPI.Controllers
{
    public class PersonController : ApiController
    {
        private PersonRepository personRepository;

        public PersonController()
        {
            this.personRepository = new PersonRepository();
        }

        /// <summary>
        /// Get Request to retrieve /public/person/info
        /// </summary>
        /// <returns>IRachioData most likely Person Data</returns>
        public IRachioData Get()
        {
            return this.personRepository.GetPerson();
        }
    }
}