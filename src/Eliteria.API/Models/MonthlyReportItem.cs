using System.Collections.Generic;

namespace Eliteria.Models
{
    public class MonthlyReportItem
    {
        public string Type { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public List<MonthReport> Details { get; set; }
    }
}
