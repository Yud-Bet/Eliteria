﻿using System;
using System.Collections.Generic;

namespace Eliteria.DataAccess.Models
{
    public class DailyReportItem
    {
        public DateTime Date { get; set; }
        public List<DayReport> DayReports { get; set; }
    }
}
