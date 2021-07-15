﻿using System;

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

        public Report(string publication, string video, string hour, string minute, string pp, string study)
        {
            Publication = Convert.ToInt32(publication);
            Video = Convert.ToInt32(video);
            Hour = Convert.ToInt32(hour);
            Minute = Convert.ToInt32(minute);
            Pp = Convert.ToInt32(pp);
            Study = Convert.ToInt32(study);
            Date = DateTime.Now;
        }
        /*public Report(string publication, string video, string hour, string minute, string pp, string study, string Date)
        {
            Publication = Convert.ToInt32(publication);
            Video = Convert.ToInt32(video);
            Hour = Convert.ToInt32(hour);
            Minute = Convert.ToInt32(minute);
            Pp = Convert.ToInt32(pp);
            Study = Convert.ToInt32(study);
            this.Date = new DateTime(Convert.ToInt32(Date[0..4]), Convert.ToInt32(Date[5..7]), Convert.ToInt32(Date[8..10]));
        }*/
    }
}