using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RachioAPI.Models
{
    public class RachioErrors : IRachioData
    {
        public string Id { get; set; }
        public List<RachioError> errors { get; set; }
    }

    public class RachioError
    {
        public string message { get; set; }
    }
}