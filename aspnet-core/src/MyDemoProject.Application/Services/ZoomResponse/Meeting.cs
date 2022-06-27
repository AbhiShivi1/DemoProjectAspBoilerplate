using Newtonsoft.Json;
using System;

namespace MyDemoProject.Services.ZoomResponse
{
    public class Meeting
    {
       // [JsonProperty("id")]
       // public string id { get; set; }
        //[JsonProperty("topic")]
        public string topic { get; set; }
       // [JsonProperty("agenda")]
        public string agenda { get; set; }
        //[JsonProperty("start_time")]
        public string start_time { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;

        //   [JsonProperty("duration")]
        public int duration { get; set; }
       // public DateTime EndDate { get; set; }
        public int type { get; set; }

        //  [JsonProperty("scheduleFor")]
       // public string schedule_for { get; set; }
       // [JsonProperty("recurrence")]
        public Recurrence recurrence { get; set; }
    }
    public class Recurrence
    {
        public string end_date_time { get; set; } //end_date_time
        public int type { get; set; } // 1-Daily 2-Weekly 3-Monthly
        public int repeat_interval { get; set; }
        //public int end_times { get; set; }
        public int monthly_day { get; set; }
       // public int monthly_week { get; set; }
        public string weekly_days { get; set; }

    }
    //public enum Type
    //{
    //    Daily=1,Weekly,Monthly

    //"end_times": 7,
    //"monthly_day": 1,
    //"monthly_week": 1,
    //"monthly_week_day": 1,
    //"weekly_days": "1"
}
