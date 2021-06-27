using Eliteria.Models;
using Eliteria.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Eliteria.Command
{
    class MonthlyDashboardOnLoadCMD : BaseCommand
    {
        private ViewModels.MonthlyDashboardViewModel viewModel;

        public MonthlyDashboardOnLoadCMD(MonthlyDashboardViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public async override void Execute(object parameter)
        {
            viewModel.IsLoading = true;
            await Task.Delay(100);
            viewModel.SavingsAccTypes = await DataAccess.DASavingsType.Load().ContinueWith(OnSavingsAccTypeLoadFinish);
            viewModel.Data = await DataAccess.DAMonthlyData.Load().ContinueWith(OnMonthlyDataLoadFinish);
            viewModel.IsLoading = false;
        }

        private List<MonthlyReportItem> OnMonthlyDataLoadFinish(Task<List<MonthlyReportItem>> arg)
        {
            if (arg.IsFaulted)
            {
                viewModel.IsLoadingError = true;
                return null;
            }
            return arg.Result;
        }

        private List<string> OnSavingsAccTypeLoadFinish(Task<List<string>> arg)
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
