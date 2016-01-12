using RachioAPI.Extensions;
using RachioAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RachioAPI.Services
{
    public class PersonRepository
    {
        private const string CacheKey = "PersonStore";

        public PersonRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var persons = new Person[]
                    {
                        new Person
                        {
                            Id = "",                            
                            UserName = "",
                            FullName = "",
                            Email = "",
                            Devices = new List<Device>(),
                            Enabled = true
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
        public IRachioData GetPersonInfo()
        {
            Person person = new Person();
            return RestSharpExtensions.ExecuteAPICall<Person>(person, "public/person/info", Method.GET);
        }

        /// <summary>
        /// Retrieves the Rachio Person Data
        /// </summary>
        /// <returns>The deserialized Person data or empty if it fails CheckStatus</returns>
        public IRachioData GetPerson()
        {
            IRachioData person = GetPersonInfo();            
            if (person.GetType() == typeof(Person))
            {
                person = RestSharpExtensions.ExecuteAPICall<Person>(person, String.Format("public/person/{0}", person.Id), Method.GET);
            }            

            return person;
        }
    }
}