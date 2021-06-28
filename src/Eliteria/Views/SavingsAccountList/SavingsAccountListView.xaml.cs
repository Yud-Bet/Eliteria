using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Eliteria.Views
{
    /// <summary>
    /// Interaction logic for SavingsAccountListView.xaml
    /// </summary>
    public partial class SavingsAccountListView : UserControl
    {
        public SavingsAccountListView()
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
            DependencyProperty.Register("OnLoadCommand", typeof(ICommand), typeof(SavingsAccountListView));


   

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (OnLoadCommand != null)
            {
                OnLoadCommand.Execute(null);
            }
        }

     
    }
}
