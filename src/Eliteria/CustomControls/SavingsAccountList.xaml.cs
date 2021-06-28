using Eliteria.Models;
using Eliteria.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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


        public ICommand ViewItemCMD
        {
            get { return (ICommand)GetValue(ViewItemCMDProperty); }
            set { SetValue(ViewItemCMDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ViewItemCMD.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewItemCMDProperty =
            DependencyProperty.Register("ViewItemCMD", typeof(ICommand), typeof(SavingsAccountList));



        public ObservableCollection<Models.SavingsAccount> ItemsSource
        {
            get { return (ObservableCollection<Models.SavingsAccount>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<Models.SavingsAccount>), typeof(SavingsAccountList));



        public ICommand DeletedSelectedItem
        {
            get { return (ICommand)GetValue(DeletedSelectedItemProperty); }
            set { SetValue(DeletedSelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DeletedSelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DeletedSelectedItemProperty =
            DependencyProperty.Register("DeletedSelectedItem", typeof(ICommand), typeof(SavingsAccountList));



        private void ListBoxItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (SavingsListBox.SelectedItems[0] != null)
            {
                SavingsAccount savingsAccount = (SavingsAccount)SavingsListBox.SelectedItems[0];
                ViewItemCMD?.Execute(savingsAccount);
            }

        }
    }
}