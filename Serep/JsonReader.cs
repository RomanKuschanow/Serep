using System;
using System.Collections.Generic;

namespace Serep
{
    class ReadedReport
    {
        public List<Report> Items { get; set; }

        public void Sorter()
        {
            List<Report> sorted = new();
            DateTime d;
            for (int i = 0; i < Items.Count; i++)
            {
                d = new();
                for (int j = 0; j < Items.Count; j++)
                {
                    if (sorted.Contains(Items[j]))
                        continue;
                    else
                        d = d > Items[j].Date ? d : Items[j].Date;
                }

                foreach (var item in Items)
                {
                    if (sorted == null)
                        sorted = new List<Report>();
                    if (item.Date == d)
                    {
                        sorted.Add(item);
                        break;
                    }
                }
            }
            Items = sorted;
        }
    }
}
