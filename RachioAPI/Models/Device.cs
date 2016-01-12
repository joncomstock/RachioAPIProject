using RachioAPI.SiteConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RachioAPI.Models
{
    public class Device : IRachioData
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public List<Zone> Zones { get; set; }
        public string SerialNumber { get; set; }
        public double RainDelayExpirationDate { get; set; }
        public double RainDelayStartDate { get; set; }   
        public string MacAddress { get; set; }
        public double Elevation { get; set; }
        public List<string> Webhooks { get; set; }
        public bool Paused { get; set; }
        public string PausedText
        {
            get
            {
                if (Paused)
                {
                    return TextConstants.BoolConstants.Yes;
                }
                else
                {
                    return TextConstants.BoolConstants.No;
                }
            }
        }
        public bool On { get; set; }
        public string OnText
        {
            get
            {
                if (On)
                {
                    return TextConstants.BoolConstants.On;
                }
                else
                {
                    return TextConstants.BoolConstants.Off;
                }
            }
        }
        public List<FlexScheduleRule> FlexScheduleRules { get; set; }
        public double UtcOffset { get; set; }
    }

    public class CustomNozzle
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Category { get; set; }
        public double InchesPerHour { get; set; }
    }

    public class Forecast
    {
        public double Time { get; set; }
        public double PrecipIntensty { get; set; }
        public double PrecipProbability { get; set; }
        public double TemperatureMin { get; set; }
        public double TemperatureMax { get; set; }
        public double WindSpeed { get; set; }
        public double Humidity { get; set; }
        public double CloudCover { get; set; }
        public double DewPoint { get; set; }
        public string WeatherType { get; set; }
        public string UnitType { get; set; }
        public string WeatherSummary { get; set; }
        public string DailyWeatherType { get; set; }
        public string PrettyTime { get; set; }
    }
}