using System;

namespace Eliteria.Models
{
    class MonthlyReportItemModel
    {
        public DateTime Date { get; set; }
        public int Opened { get; set; }
        public int Closed { get; set; }
        public int Different { get; set; }
    }
}
