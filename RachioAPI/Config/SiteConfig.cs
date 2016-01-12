using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RachioAPI
{
    public partial class Config
    {
        public class Site
        {
            //Api Access Token to connect to API
            public const string _apiAccessToken = "c3667b81-92a6-4913-b83c-64cc713cbc1e";
            //Base URL
            public const string BaseRachioURL = "https://api.rach.io/1/";
        }
    }
}