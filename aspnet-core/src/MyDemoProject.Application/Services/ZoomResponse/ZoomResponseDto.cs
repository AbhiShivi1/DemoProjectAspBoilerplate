using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDemoProject.Services.ZoomResponse
{
    public class ZoomResponseDto
    {
        public string id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public string role_name { get; set; }
        public string vanity_url { get; set; }
        public string personal_meeting_url { get; set; }
        public string pic_url { get; set; }
        public string account_id { get; set; }
        public string timezone { get; set; }
        public string language { get; set; }
        public string phone_country { get; set; }
        public string phone_number { get; set; }
    }
}
