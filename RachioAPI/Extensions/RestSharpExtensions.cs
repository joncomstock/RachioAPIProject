using Newtonsoft.Json;
using RachioAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace RachioAPI.Extensions
{
    public static class RestSharpExtensions
    {
        /// <summary>
        /// Initializes the RestSharp Rest Client
        /// </summary>
        /// <param name="uri">Base URI to connect to</param>
        /// <returns>An inited RestClient</returns>
        public static RestClient InitRestClient(Uri uri)
        {
            var client = new RestClient(uri);
            return client;
        }

        /// <summary>
        /// Initializes the RestSharp Rest Request
        /// </summary>
        /// <param name="url">The URL to attach to the Base URI</param>
        /// <returns></returns>
        public static RestRequest InitRestRequest(string url, Method method)
        {
            //Get is the default, but added for clarity
            var req = new RestRequest(url, method);
            return req;
        }

        /// <summary>
        /// Takes the RestRequest in question, and the API Key needed to authenticate with the Rachio API and authenticates the request
        /// </summary>
        /// <param name="req">The RestRequest to authenticate</param>
        /// <param name="apiKey">The API Key used to authenticate</param>
        public static void SetAPIKeyAuthentication(RestRequest req, string apiKey)
        {
            req.AddHeader("Content-Type", "application/json");
            req.AddHeader("Authorization", "Bearer " + apiKey);
        }

        /// <summary>
        /// Adds in the necessary data for a POST request.
        /// </summary>
        /// <param name="inputData">The data to be serialized</param>
        /// <param name="req">The RestRequest to add data to</param>
        public static void AddDataParameters(RestRequest req, IRachioData inputData)
        {
            req.AddJsonBody(inputData);
        }

        /// <summary>
        /// Checks the status of the API request
        /// OK: Deserialize the data
        /// Completed but not OK: Any type of Successful return from API that's not OK i.e. 500 error
        /// Else: The response failed completely
        /// </summary>
        /// <param name="response">IRestResponse from request</param>
        /// <param name="inputData">Object to place the successful data in</param>
        /// <returns></returns>
        public static IRachioData CheckStatus<T>(IRestResponse response, IRachioData inputData) where T : IRachioData
        {
            if (response.StatusCode == HttpStatusCode.OK)
            {
                inputData = JsonConvert.DeserializeObject<T>(response.Content);
            }
            else if (response.ResponseStatus == ResponseStatus.Completed)
            {
                //Catch every type of "success" error
                var errorMsg = JsonConvert.DeserializeObject<RachioErrors>(response.Content);
                if (errorMsg != null)
                {
                    if (errorMsg != null)
                    {
                        return errorMsg;
                    }
                }

            }
            else
            {
                RachioError errorItem = new RachioError() { message = response.ErrorMessage };
                RachioErrors error = new RachioErrors() { errors = new List<RachioError>() { errorItem } };
                
                return error;
            }

            return inputData;
        }

        /// <summary>
        /// Uses RestSharp to fully execute the REST call
        /// </summary>
        /// <typeparam name="T">The specific type of IRachioData</typeparam>
        /// <param name="inputData">The type of data</param>
        /// <param name="url">The API Url</param>
        /// <param name="method">The type of REST API call</param>
        /// <returns>The data retrieved/message from API call/or error from API call</returns>
        public static IRachioData ExecuteAPICall<T>(IRachioData inputData, string url, Method method) where T : IRachioData
        {
            var client = InitRestClient(new Uri(Config.Site.BaseRachioURL));
            var req = InitRestRequest(url, method);
            SetAPIKeyAuthentication(req, Config.Site._apiAccessToken);
            if (method == Method.PUT)
            {
                AddDataParameters(req, inputData);
            }

            IRestResponse response = client.Execute(req);
            //Will return as the appropriate IRachioData, i.e. a Person, or a RachioError if something goes wrong
            inputData = CheckStatus<T>(response, inputData);

            return inputData;
        }
    }
}