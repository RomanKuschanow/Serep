using System;
using System.Text.Json.Serialization;

namespace Serep
{
    class Report
    {
        public DateTime Date { get; set; }
        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Publication { get; set; }
        public int Video { get; set; }
        public int Pp { get; set; }
        public int Study { get; set; }
        public string Notes { get; set; }

        [JsonConstructor]
        public Report() { }

        public Report(DateTime date, int publication, int video, int hour, int minute, int pp, int study)
        {
            Date = new(date.Year, date.Month, date.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);
            Publication = publication;
            Video = video;
            Hour = hour;
            Minute = minute;
            Pp = pp;
            Study = study;
            Notes = "";
        }
    }
}
