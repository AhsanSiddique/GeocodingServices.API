using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helper
{
    public static class Helper
    {
        public static string GeoCodingPreURL = "https://geocoding.geo.census.gov/";
        //public static string GeoCodingPostURL = "geocoder/locations/address?";
        public static string GeoCodingPostURL = "geocoder/locations/onelineaddress?";
        public static string WeatherAPIURL = "https://api.weather.gov/points/";

        public static string GeoCodingURLGenerator(string address)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(GeoCodingPreURL);
            sb.Append(GeoCodingPostURL);
            if (address != null)
            {
                sb.Append("address=" + address.Replace(" ", "+").Replace(",", "%2C").Replace("#", "%23"));
            }
            sb.Append("&benchmark=2020");
            sb.Append("&format=json");
            return sb.ToString();
        }
    }
}
