using Eliteria.Models;
using Eliteria.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Eliteria.CustomControls
{
    /// <summary>
    /// Interaction logic for SavingsAccountList.xaml
    /// </summary>
    public partial class SavingsAccountList : UserControl
    {
        public SavingsAccountList()
        {
            InitializeComponent();
        }


        public ObservableCollection<Models.SavingsAccount> ItemsSource
        {
            get { return (ObservableCollection<Models.SavingsAccount>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<Models.SavingsAccount>), typeof(SavingsAccountList));

        private void ListBoxItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            SavingsAccount savingsAccount = (SavingsAccount)SavingsListBox.SelectedItems[0];

            Window window = new Window
            {
                Content = new ASavingProfileView(savingsAccount),
                SizeToContent = SizeToContent.WidthAndHeight,
                ResizeMode = ResizeMode.NoResize,
                WindowStartupLocation = WindowStartupLocation.CenterScreen,
                WindowStyle = WindowStyle.None,
            };

            window.ShowDialog();
        }
    }
}