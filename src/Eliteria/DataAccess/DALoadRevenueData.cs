﻿using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Threading.Tasks;

namespace Eliteria.DataAccess
{
    public static class DALoadRevenueData
    {
        public static async Task<List<DailyReportItem>> Load()
        {
            var res = new List<DailyReportItem>();
            DataTable data = await ExecuteQuery.ExecuteReaderAsync("Eliteria_LoadRevenueData");

            if (data.Rows.Count == 0) return res;

            DateTime dateTime = (DateTime)data.Rows[0].ItemArray[0];
            DayReport dayReport = new DayReport
            {
                Type = (string)data.Rows[0].ItemArray[1],
                Revenue = (decimal)data.Rows[0].ItemArray[2],
                Expense = (decimal)data.Rows[0].ItemArray[3],
                Different = (decimal)data.Rows[0].ItemArray[4]
            };
            res.Add(new DailyReportItem { Date = dateTime, DayReports = new List<DayReport> { dayReport } });
            for (int i = 1, j = 0; i < data.Rows.Count; i++)
            {
                DateTime dateItem = (DateTime)data.Rows[i].ItemArray[0];
                DayReport dayReportItem = new DayReport
                {
                    Type = (string)data.Rows[i].ItemArray[1],
                    Revenue = (decimal)data.Rows[i].ItemArray[2],
                    Expense = (decimal)data.Rows[i].ItemArray[3],
                    Different = (decimal)data.Rows[i].ItemArray[4]
                };

                if (dateItem == res[j].Date)
                {
                    res[j].DayReports.Add(dayReportItem);
                }
                else
                {
                    res.Add(new DailyReportItem { Date = dateItem, DayReports = new List<DayReport> { dayReportItem} });
                    j++;
                }
            }
            return res;
        }
    }
}
