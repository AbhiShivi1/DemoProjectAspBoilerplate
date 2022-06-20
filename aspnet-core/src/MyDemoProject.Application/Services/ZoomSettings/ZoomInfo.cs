using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDemoProject.Services.ZoomSettings
{
    public class ZoomInfo
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUrl { get; set; }
        public string AuthorizationUrl { get; set; }
        public string MeetingUrl { get; set; }
    }
}
