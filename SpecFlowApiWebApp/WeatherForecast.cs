using System;
using Newtonsoft.Json;

namespace SpecFlowApiWebApp
{
    public class WeatherForecast
    {
        //private DateTime _date;

        //[JsonProperty("date")]
        //public DateTime Date 
        //{ 
        //    get { return _date.Date; }
        //    set { _date = value;  }
        //}

        public DateTime Date { get; set; }

        //[JsonProperty("temperatureC")]
        public int TemperatureC { get; set; }

        //[JsonProperty("temperatureF")]
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        //[JsonProperty("summary")]
        public string Summary { get; set; }
    }
}
