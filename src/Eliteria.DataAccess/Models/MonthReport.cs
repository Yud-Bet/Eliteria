using System;

namespace Eliteria.DTA
{
    public class MonthReport
    {
        public DateTime Date { get; set; }
        public int Opened { get; set; }
        public int Closed { get; set; }
        public int Different { get; set; }
    }
}
