using Microsoft.Extensions.Options;
using MyDemoProject.Services.ZoomResponse;
using MyDemoProject.Services.ZoomSettings;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDemoProject.Services.Zoom
{
    public class ZoomServices:IZoomServices
    {
        private readonly IOptions<ZoomInfo> _zoom;

        public ZoomServices(IOptions<ZoomInfo> zoom)
        {
            _zoom = zoom;
        }

        private string AuthorizationHeader
        {
            get
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes($"{_zoom.Value.ClientId}:{_zoom.Value.ClientSecret}");
                var encodedString = System.Convert.ToBase64String(plainTextBytes);
                return $"Basic {encodedString}";
            }
        }

        public string SignIn()
        {
            return string.Format(_zoom.Value.AuthorizationUrl, _zoom.Value.ClientId, _zoom.Value.RedirectUrl).Replace("&amp;", "&");
        }
        public ZoomAuthDto OAuthRedirect(string code)
        {
            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest();

            request.AddQueryParameter("grant_type", "authorization_code");
            request.AddQueryParameter("code", code);
            request.AddQueryParameter("redirect_uri", _zoom.Value.RedirectUrl);
            request.AddHeader("Authorization", string.Format(AuthorizationHeader));


            restClient.BaseUrl = new Uri("https://zoom.us/oauth/token");
            var response = restClient.Post(request);

          //  if (response.StatusCode == System.Net.HttpStatusCode.OK)
           // {
                //System.IO.File.WriteAllText(ConfigurationManager.AppSettings["TokenFilePath"], response.Content);
               // var token = JObject.Parse(response.Content);
            var responseObj = JsonConvert.DeserializeObject<ZoomAuthDto>(response.Content);

            return responseObj;

               // this.GetUserDetails(token["access_token"].ToString());
               //return RedirectToAction("Index", "Home");
               // }

            //return View("Error");
        }
        public ZoomResponseDto GetUserDetails(string accessToken)
        {
            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest();

            request.AddHeader("Authorization", string.Format("Bearer {0}", accessToken));

            restClient.BaseUrl = new Uri("https://api.zoom.us/v2/users/me");
            var response = restClient.Get(request);

            // if (response.StatusCode == System.Net.HttpStatusCode.OK)
            // {
            //System.IO.File.WriteAllText(ConfigurationManager.AppSettings["UserDetailsPath"], response.Content);
            // }
            var responseObj = JsonConvert.DeserializeObject<ZoomResponseDto>(response.Content);
            return responseObj;
        }
        public ZoomAuthDto RefreshToken(string RefreshToken)
        {
            //var token = JObject.Parse(System.IO.File.ReadAllText(ConfigurationManager.AppSettings["TokenFilePath"]));

            RestClient restClient = new RestClient();
            RestRequest request = new RestRequest();

            request.AddQueryParameter("grant_type", "refresh_token");
            request.AddQueryParameter("refresh_token", RefreshToken);
            request.AddHeader("Authorization", string.Format(AuthorizationHeader));

            restClient.BaseUrl = new Uri("https://zoom.us/oauth/token");
            var response = restClient.Post(request);
            var responseObj = JsonConvert.DeserializeObject<ZoomAuthDto>(response.Content);
            return responseObj;

            //if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //{
            //   // System.IO.File.WriteAllText(ConfigurationManager.AppSettings["TokenFilePath"], response.Content);
            //   // return RedirectToAction("Index", "Home");
            //}

            //return View("Error");
        }
        public ZoomMeeting CreateMeeting(Meeting meeting, string AccessToken, string Id)
        {
            string model;
            if (meeting.type == 8)
            {
                var day = (int)meeting.Date.DayOfWeek+1;
                var meetingModel = new Meeting
                {
                    topic = meeting.topic,
                    agenda = meeting.agenda,

                    start_time = meeting.Date.ToString("yyyy-MM-dd") + "T" + meeting.Date.ToString("HH':'mm':'ss"),
                   // start_time = meeting.Date.ToString("s"),
                    //start_time = new DateTime().ToString("2022-06-27T18:00:00"),
                    duration = meeting.duration,
                   // schedule_for = meeting.schedule_for,
                    type = meeting.type,

                    recurrence = new Recurrence
                    {
                        end_date_time = "2022-09-29T09:00:00Z",
                        type = meeting.recurrence.type,    // 1-Daily 2-Weekly 3-Monthly    
                        repeat_interval = 1,
                        weekly_days = $"{day}",
                        monthly_day = Int16.Parse(meeting.Date.ToString("dd")),


                        //end_times = meeting.recurrence.end_times,
                        // monthly_week_day = meeting.recurrence.monthly_week_day,
                        // monthly_week = meeting.recurrence.monthly_week,
                        // weekly_days = meeting.recurrence.weekly_days,
                    }
                };
                 model = JsonConvert.SerializeObject(meetingModel);
            }
            //if(meeting.type==3)
            //{
            //    var meetingModel = new Meeting
            //    {
            //        topic = meeting.topic,
            //        agenda = meeting.agenda,
            //        //start_time = meeting.Date.ToString("yyyy-MM-dd") + "T" + meeting.Date.ToString("HH':'mm':'ss"),
            //        start_time = meeting.Date.ToString("s"),

            //        duration = meeting.duration,
            //        type = meeting.type,
            //        recurrence = new Recurrence
            //        {
            //            //end_times=meeting.recurrence.end_times,
            //            type= meeting.recurrence.type,

            //        }
            //    };
            //    model = JsonConvert.SerializeObject(meetingModel);

            //}
            else  //fix this if else
            {
                var meetingModel = new JObject();
                meetingModel["topic"] = meeting.topic;
                meetingModel["agenda"] = meeting.agenda;
               // meetingModel["start_time"] = meeting.Date.ToString("s");

                meetingModel["start_time"] = meeting.Date.ToString("yyyy-MM-dd") + "T" + meeting.Date.ToString("HH':'mm':'ss");
                meetingModel["duration"] = meeting.duration;
                model = JsonConvert.SerializeObject(meetingModel);

            }



            RestClient restClient = new RestClient();
            RestRequest restRequest = new RestRequest();

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("Authorization", string.Format("Bearer {0}", AccessToken));
            restRequest.AddParameter("application/json", model, ParameterType.RequestBody);
            restClient.BaseUrl = new Uri(string.Format(_zoom.Value.MeetingUrl, Id));
            var response = restClient.Post(restRequest);
            var responseObj = JsonConvert.DeserializeObject<ZoomMeeting>(response.Content);
            return responseObj;
            //if (response.StatusCode == System.Net.HttpStatusCode.Created)
            //{
            //    System.IO.File.WriteAllText(ConfigurationManager.AppSettings["MeetingResponsePath"], response.Content);
            //    return RedirectToAction("Index", "Home");
            //}

            //return View("Error");
        }
        //public ZoomMeeting Meeting(string identifier, string AccessToken)
        //{
        //    //var token = JObject.Parse(ConfigurationManager.AppSettings["TokenFilePath"]);

        //    RestClient restClient = new RestClient();
        //    RestRequest restRequest = new RestRequest();

        //    restRequest.AddHeader("Authorization", "Bearer " + AccessToken);

        //    restClient.BaseUrl = new Uri($"https://api.zoom.us/v2/meetings/{identifier}");
        //    var response = restClient.Get(restRequest);

        //   // if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //   // {
        //        var zoomMeeting = JObject.Parse(response.Content).ToObject<ZoomMeeting>();
        //        zoomMeeting.start_time = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(zoomMeeting.start_time.Ticks, DateTimeKind.Unspecified), TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        //    //var responseObj = JsonConvert.DeserializeObject<ZoomAuthDto>(response.Content);
        //    //return responseObj;
        //    return zoomMeeting;
        //  //  }

        //   // return View("Error");
        //}

        //public IEnumerable<ZoomMeeting> AllMeetings(string AccessToken,string userId)
        //{
        //    //var token = JObject.Parse(System.IO.File.ReadAllText(ConfigurationManager.AppSettings["TokenFilePath"]));
        //    //var userDetails = JObject.Parse(System.IO.File.ReadAllText(ConfigurationManager.AppSettings["UserDetailsPath"]));
        //   // var access_token = token["access_token"];
        //   // var userId = userDetails["id"];

        //    RestClient restClient = new RestClient();
        //    RestRequest restRequest = new RestRequest();
        //    restRequest.AddHeader("Authorization", "Bearer " + AccessToken);

        //    restClient.BaseUrl = new Uri($"https://api.zoom.us/v2/users/{userId}/meetings");
        //    var response = restClient.Get(restRequest);

        //    //if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //    //{
        //        var zoomMeetings = JObject.Parse(response.Content)["meetings"].ToObject<IEnumerable<ZoomMeeting>>();
        //        foreach (ZoomMeeting meeting in zoomMeetings)
        //        {
        //            meeting.Start_Time = TimeZoneInfo.ConvertTimeFromUtc(new DateTime(meeting.Start_Time.Ticks, DateTimeKind.Unspecified), TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        //        }

        //        return zoomMeetings;
        //    //}

        //   // return View("Error");
        //}


    }
}
