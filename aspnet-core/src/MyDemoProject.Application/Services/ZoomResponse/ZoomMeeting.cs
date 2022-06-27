namespace MyDemoProject.Services.ZoomResponse
{
    public class ZoomMeeting
    {
        public string id { get; set; }
        public string host_email { get; set; }

        public string topic { get; set; }

        public string agenda { get; set; }
        public string created_at { get; set; }

        public string start_time { get; set; }

        public int duration { get; set; }
        public Recurrence recurrence { get; set; }

        public string timezone { get; set; }

        public string join_url { get; set; }

        public string start_url { get; set; }
        public int type { get; set; }

    }
}
//{
//    "assistant_id": "kFFvsJc-Q1OSxaJQLvaa_A",
//"host_email": "jchill@example.com",
//"id": 92674392836,
//"registration_url": "https://example.com/meeting/register/7ksAkRCoEpt1Jm0wa-E6lICLur9e7Lde5oW6",
//"agenda": "My Meeting",
//"created_at": "2022-03-25T07:29:29Z",
//"duration": 60,
//"h323_password": "123456",
//"join_url": "https://example.com/j/11111",
//"occurrences": [],
//"password": "123456",
//"pmi": 97891943927,
//"pre_schedule": false,
//"recurrence": {
//"end_date_time": "2022-04-02T15:59:00Z",
//"end_times": 7,
//"monthly_day": 1,
//"monthly_week": 1,
//"monthly_week_day": 1,
//"repeat_interval": 1,
//"type": 1,
//"weekly_days": "1"
//},
//"settings": { },
//"start_time": "2022-03-25T07:29:29Z",
//"start_url": "https://example.com/s/11111",
//"timezone": "America/Los_Angeles",
//"topic": "My Meeting",
//"tracking_fields": [
//{ }
//],
//"type": 2
//}