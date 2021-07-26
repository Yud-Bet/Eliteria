﻿using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliteria.Command
{
    class DailyDashboardOnLoadCommand : BaseCommandAsync
    {
        private ViewModels.DailyDashboardViewModel viewModel;
        public DailyDashboardOnLoadCommand(ViewModels.DailyDashboardViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public async override Task ExecuteAsync(object parameter)
        {
            viewModel.IsLoading = true;
            await Task.Delay(100);
            viewModel.Data = await DataAccess.Modules.ReportModule.GetDailyData().ContinueWith(OnTaskCompleted);
            viewModel.IsLoading = false;
        }

        private List<DataAccess.Models.DailyReportItem> OnTaskCompleted(Task<List<DataAccess.Models.DailyReportItem>> arg)
        {
            if (arg.IsFaulted)
            {
                viewModel.IsLoadingError = true;
                return null;
            }
            return arg.Result;
        }
    }
}
