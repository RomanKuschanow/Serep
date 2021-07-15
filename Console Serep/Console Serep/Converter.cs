using System;

namespace Console_Serep
{
    class Converter
    {
        public Report Report { get; }

        public Converter(string rep)
        {
            string pub = rep[0..rep.IndexOf(' ')];
            rep = rep[(rep.IndexOf(' ') + 1)..];
            string video = rep[0..rep.IndexOf(' ')];
            rep = rep[(rep.IndexOf(' ') + 1)..];
            string hour = rep[0..rep.IndexOf(':')];
            string minute = rep[(rep.IndexOf(':') + 1)..rep.IndexOf(' ')];
            rep = rep[(rep.IndexOf(' ') + 1)..];
            string pp = rep[0..rep.IndexOf(' ')];
            rep = rep[(rep.IndexOf(' ') + 1)..];
            string study = rep[0..];
            Report = new Report(pub, video, hour, minute, pp, study);
        }
    }
}
