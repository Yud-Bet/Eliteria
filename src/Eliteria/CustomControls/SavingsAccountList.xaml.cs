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


    }
}
