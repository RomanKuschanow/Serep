using System;
using System.Text.Json.Serialization;

namespace Console_Serep
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

        [JsonConstructor]
        public Report() { }
        public Report(string publication, string video, string hour, string minute, string pp, string study)
        {
            Publication = Convert.ToInt32(publication);
            Video = Convert.ToInt32(video);
            Hour = Convert.ToInt32(hour);
            Minute = Convert.ToInt32(minute);
            Pp = Convert.ToInt32(pp);
            Study = Convert.ToInt32(study);

            if (Minute >= 60)
            {
                Hour += Convert.ToInt32(Math.Floor(Convert.ToDecimal(minute) / 60));
                Minute %= 60;
            }

            Date = DateTime.Now;
        }
        public Report(string publication, string video, string hour, string minute, string pp, string study, string date)
        {
            Publication = Convert.ToInt32(publication);
            Video = Convert.ToInt32(video);
            Hour = Convert.ToInt32(hour);
            Minute = Convert.ToInt32(minute);
            Pp = Convert.ToInt32(pp);
            Study = Convert.ToInt32(study);

            if (Minute >= 60)
            {
                Hour += Convert.ToInt32(Math.Floor(Convert.ToDecimal(minute) / 60));
                Minute %= 60;
            }

            Date = new DateTime(Convert.ToInt32(date[0..4]), Convert.ToInt32(date[5..7]), Convert.ToInt32(date[8..10]));
        }
    }
}
