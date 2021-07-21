using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Eliteria.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public ICommand loadCMD
        {
            get { return (ICommand)GetValue(LoadCMDProperty); }
            set { SetValue(LoadCMDProperty, value); }
        }
       
        public static readonly DependencyProperty LoadCMDProperty =
            DependencyProperty.Register("loadCMD", typeof(ICommand), typeof(HomeView), new PropertyMetadata(null));


        public HomeView()
        {
            InitializeComponent();
        }

        private void HomeView_SavingsList_Loaded(object sender, RoutedEventArgs e)
        {            
            if (loadCMD != null)
            {
                loadCMD.Execute(null);
            }
        }
    }
}
