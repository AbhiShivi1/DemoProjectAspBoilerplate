using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDemoProject.Services.ZoomResponse
{
    public class Meeting
    {
        public string Id { get; set; }

        public string Topic { get; set; }

        public string Agenda { get; set; }

        public DateTime Date { get; set; }
        public DateTime DateOnly { get; set; }
        public DateTime TimeOnly { get; set; }

      //  public double Time { get; set; }

        public int Duration { get; set; }
    }
}
