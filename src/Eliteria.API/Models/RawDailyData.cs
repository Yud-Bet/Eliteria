using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Eliteria.API.Models
{
    public class RawDailyData
    {
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public decimal Revenue { get; set; }
        public decimal Expense { get; set; }
        public decimal Different { get; set; }
    }
}
