using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RachioAPI.Models
{
    public class Person : IRachioData
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<Device> Devices { get; set; }
        public bool Enabled { get; set; }
    }
}