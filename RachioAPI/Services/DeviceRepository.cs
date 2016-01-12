using RachioAPI.Extensions;
using RachioAPI.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RachioAPI.Services
{
    public class DeviceRepository
    {
        private const string CacheKey = "DeviceStore";

        public DeviceRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var devices = new Device[]
                    {
                        new Device
                        {
                            Id = "2a5e7d3c-c140-4e2e-91a1-a212a518adc5",
                            Status = "ONLINE"
                        }
                    };

                    ctx.Cache[CacheKey] = devices;
                }
            }
        }

        public Device[] GetAllDevices()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (Device[])ctx.Cache[CacheKey];
            }

            return new Device[]
            {
                new Device
                {
                    Id = "0",
                    Status = "ONLINE"
                }
            };
        }

        /// <summary>
        /// Retrieves the Rachio Device Data
        /// </summary>
        /// <returns>The deserialized Device data or empty if it fails CheckStatus</returns>
        public static Device GetDevice(string id)
        {

            Device device = new Device();

            device = (Device)RestSharpExtensions.ExecuteAPICall<Device>(device, String.Format("public/device", id), Method.GET);

            return device;
        }

        public bool SaveDevice(Device device)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((Device[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(device);
                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }

            return false;
        }
    }
}