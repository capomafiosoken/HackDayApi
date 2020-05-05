using System;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace HackDayApi.External
{
    public class YandexResponse
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public class CsrfTokenResponse
    {
        [JsonProperty("csrfToken")]
        public string CsrfToken { get; set; }
    }
    public class Data
    {
        [JsonProperty("items")]
        public ExactResult[] Items { get; set; }
        
    }

    public class ExactResult
    {
        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }

        [JsonProperty("entrances")]
        public Entrance[] Entrances { get; set; }
    }

    public class Entrance
    {
        [JsonProperty("coordinates")]
        public double[] Coordinates { get; set; }

        [JsonProperty("azimuth")]
        public double Azimuth { get; set; }

        [JsonProperty("tilt")]
        public long Tilt { get; set; }
    }
}
