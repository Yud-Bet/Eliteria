using LiveCharts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class MonthlyDashboardViewModel: BaseViewModel, INotifyDataErrorInfo
    {
        #region Chart
        private SeriesCollection _seriesCollection;

        public SeriesCollection SeriesCollection
        {
            get => _seriesCollection;
            set
            {
                _seriesCollection = value;
                OnPropertychanged(nameof(SeriesCollection));
            }
        }
        public ObservableCollection<string> xAxis { get; set; } = new ObservableCollection<string>();
        public Func<double, string> yAxis { get; set; }
        #endregion

        public MonthlyDashboardViewModel()
        {
            OnLoadCommand = new Command.MonthlyDashboardOnLoadCMD(this);
            OnSelectedDateChange = new Command.MonthlyDashboardOnSelectedDateChangeCMD(this);
            yAxis = y => y.ToString("N0");
        }

        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();
        private DateTime? _startMonth;
        private DateTime? _endMonth;
        private List<string> _SavingsAccType = new List<string>();
        private string _selectedAccType;

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public ObservableCollection<Models.MonthReport> MonthlyReport { get; set; }
        public List<Models.MonthlyReportItem> Data { get; set; }
        public List<string> SavingsAccTypes
        {
            get => _SavingsAccType;
            set
            {
                _SavingsAccType = value;
                OnPropertychanged(nameof(SavingsAccTypes));
            }
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

        #region Validation
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
        #endregion

        public ICommand OnLoadCommand { get; set; }
        public ICommand OnSelectedDateChange { get; set; }
    }
}
