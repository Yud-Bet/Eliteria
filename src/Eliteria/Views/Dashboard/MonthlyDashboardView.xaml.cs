using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Eliteria.Views
{
    /// <summary>
    /// Interaction logic for MonthlyDashboardView.xaml
    /// </summary>
    public partial class MonthlyDashboardView : UserControl
    {
        public MonthlyDashboardView()
        {
            InitializeComponent();
        }


        public ICommand OnLoadCommand
        {
            get { return (ICommand)GetValue(OnLoadCommandProperty); }
            set { SetValue(OnLoadCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OnLoadCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnLoadCommandProperty =
            DependencyProperty.Register("OnLoadCommand", typeof(ICommand), typeof(MonthlyDashboardView));


        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (OnLoadCommand != null)
            {
                OnLoadCommand.Execute(null);
            }
        }
    }
}
