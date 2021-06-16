using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Eliteria.ViewModels
{
    class DailyDashboardViewModel : BaseViewModel, INotifyDataErrorInfo
    {
        private DateTime? _startDate;
        private DateTime? _endDate;
        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();

        public DateTime? startDate
        {
            get => _startDate;
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    ClearErrors(nameof(startDate));
                    ClearErrors(nameof(endDate));
                    if (startDate > endDate)
                    {
                        AddErrors(nameof(startDate), "Ngày không hợp lệ!");
                    }
                    OnPropertychanged(nameof(startDate));
                    OnPropertychanged(nameof(endDate));
                }
            }
        }
        public DateTime? endDate
        {
            get => _endDate;
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    ClearErrors(nameof(endDate));
                    ClearErrors(nameof(startDate));
                    if (endDate < startDate)
                    {
                        AddErrors(nameof(endDate), "Ngày không hợp lệ!");
                    }
                    OnPropertychanged(nameof(startDate));
                    OnPropertychanged(nameof(endDate));
                }
            }
        }

        private void ClearErrors(string propertyName)
        {
            _propertyErrors.Remove(propertyName);
        }

        public bool HasErrors => _propertyErrors.Count > 0;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            if (!_propertyErrors.ContainsKey(propertyName)) return null;
            return _propertyErrors[propertyName];
        }

        public void AddErrors(string propertyName, string errorMessage)
        {
            if (!_propertyErrors.ContainsKey(propertyName))
            {
                _propertyErrors.Add(propertyName, new List<string>());
            }

            _propertyErrors[propertyName].Add(errorMessage);
            OnErrorsChanged(propertyName);
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public ObservableCollection<Models.DailyReportItemModel> DailyReport { get; } = new ObservableCollection<Models.DailyReportItemModel>() {
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
            new Models.DailyReportItemModel(){
                Type = "Không kỳ hạn",
                Revenue = 100000,
                Expense = 50000,
                Different = 50000
            },
        };
    }
}
