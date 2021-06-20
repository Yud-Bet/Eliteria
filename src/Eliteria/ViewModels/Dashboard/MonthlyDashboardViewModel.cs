using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Eliteria.ViewModels
{
    class MonthlyDashboardViewModel: BaseViewModel, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();
        public MonthlyDashboardViewModel()
        {
            SeriesCollection = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Sổ mở",
                    Values = new ChartValues<double> { 4, 6, 5, 2 ,4 }
                },
                new LineSeries
                {
                    Title = "Sổ đóng",
                    Values = new ChartValues<double> { 6, 7, 3, 4 ,6 },
                    PointGeometry = null
                },
            };

            Labels = new List<string>{ "Jan", "Feb", "Mar", "Apr", "May" };
            YFormatter = value => value.ToString();
        }

        public SeriesCollection SeriesCollection { get; set; }
        public List<string> Labels { get; set; }
        public Func<double, string> YFormatter { get; set; }

        private DateTime? _startMonth;
        private DateTime? _endMonth;
        private ObservableCollection<string> _SavingsAccType = new ObservableCollection<string>() { "Không thời hạn", "6 tháng" };
        private string _selectedAccType;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public ObservableCollection<Models.MonthlyReportItemModel> MonthlyReport { get; set; }
        public ObservableCollection<string> SavingsAccTypes
        {
            get => _SavingsAccType;
        }
        public string SelectedAccType
        {
            get => _selectedAccType;
            set
            {
                _selectedAccType = value;
                OnPropertychanged(nameof(SelectedAccType));
            }
        }
        public DateTime? startMonth
        {
            get => _startMonth;
            set
            {
                if (_startMonth != value)
                {
                    _startMonth = value;
                    ClearErrors(nameof(startMonth));
                    ClearErrors(nameof(endMonth));
                    if (startMonth > endMonth)
                    {
                        AddErrors(nameof(startMonth), "Ngày không hợp lệ!");
                    }
                    OnPropertychanged(nameof(startMonth));
                    OnPropertychanged(nameof(endMonth));
                }
            }
        }
        public DateTime? endMonth
        {
            get => _endMonth;
            set
            {
                if (_endMonth != value)
                {

                    _endMonth = value;
                    ClearErrors(nameof(startMonth));
                    ClearErrors(nameof(endMonth));
                    if (startMonth > endMonth)
                    {
                        AddErrors(nameof(endMonth), "Ngày không hợp lệ!");
                    }
                    OnPropertychanged(nameof(startMonth));
                    OnPropertychanged(nameof(endMonth));
                }
            }
        }

        private void ClearErrors(string propertyName)
        {
            _propertyErrors.Remove(propertyName);
        }

        public bool HasErrors => _propertyErrors.Count > 0;

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
    }
}
