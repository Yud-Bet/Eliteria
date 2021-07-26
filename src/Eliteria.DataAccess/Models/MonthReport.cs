using System;

namespace Eliteria.DataAccess.Models
{
    public class MonthReport
    {
        public DateTime Date { get; set; }
        public int Opened { get; set; }
        public int Closed { get; set; }
        public int Different { get; set; }
    }
}
