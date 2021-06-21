using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class DailyDashboardViewModel : BaseViewModel, INotifyDataErrorInfo
    {
        #region Chart
        private SeriesCollection _seriesCollection;

        public SeriesCollection seriesCollection
        {
            get => _seriesCollection;
            set
            {
                _seriesCollection = value;
                OnPropertychanged(nameof(seriesCollection));
            }
        }
        public ObservableCollection<string> xAxis { get; set; } = new ObservableCollection<string>();
        public Func<double, string> yAxis { get; set; }
        public int xAxisConst = 0;
        public Dictionary<int, int> xAxisToDataIndexConverter = new Dictionary<int, int>();
        #endregion

        private DateTime? _startDate;
        private DateTime? _endDate;
        private readonly Dictionary<string, List<string>> _propertyErrors = new Dictionary<string, List<string>>();
        private ObservableCollection<Models.DayReport> _dailyReport;
        private string _selectedDay = "...";
        public Stores.NavigationStore _homeNavigationStore;

        public DailyDashboardViewModel(Stores.NavigationStore homeNavigationStore)
        {
            _homeNavigationStore = homeNavigationStore;
            DailyDashboardOnLoadCommand = new Command.DailyDashboardOnLoadCommand(this);
            OnSelectedDateChangeCommand = new Command.DailyDashboardOnSelectedDateChangeCMD(this);
            DrillDownCommand = new Command.DailyDashboardDrillDownCMD(this);
            //Chart
            yAxis = y => y.ToString("N0");
            //
        }

        public ICommand OnSelectedDateChangeCommand { get; set; }
        public ICommand DrillDownCommand { get; set; }
        public ICommand DailyDashboardOnLoadCommand { get; set; }

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

        public string selectedDay
        {
            get => _selectedDay;
            set
            {
                _selectedDay = value;
                OnPropertychanged(nameof(selectedDay));
            }
        }

        public ObservableCollection<Models.DayReport> DailyReport
        {
            get => _dailyReport;
            set
            {
                _dailyReport = value;
                OnPropertychanged(nameof(DailyReport));
            }
        }

        public List<Models.DailyReportItem> Data;
    }
}
