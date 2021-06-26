using Eliteria.Models;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Eliteria.Views
{
    /// <summary>
    /// Interaction logic for AddNewSaving.xaml
    /// </summary>
    public partial class AddNewSaving : UserControl
    {
        public Window window;
        //public ObservableCollection<Models.SavingsAccount> _savingAccounts;

        public AddNewSaving(/*ObservableCollection<Models.SavingsAccount> savingsAccounts*/)
        {
            InitializeComponent();
            //this._savingAccounts = savingsAccounts;
        }
        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.window.Close();
        }
        private void AddNewSaving_Loaded(object sender, RoutedEventArgs e)
        {
            this.window = Window.GetWindow(this);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            //SavingsAccount savingsAccount = new SavingsAccount();
            //savingsAccount.Name = Fullname.Text;
            //savingsAccount.AccountNumber = SavingID.Text;
            //savingsAccount.IdentificationNumber = CustomerID.Text;
            //savingsAccount.Address = CustomerAddress.Text;
            //savingsAccount.Balance = Convert.ToDecimal(SavingAmount.Text);
            //savingsAccount.Type = cbxSavingtype.SelectedItem.ToString();
            //savingsAccount.OpenDate = Convert.ToDateTime(OpenDate);
            //_savingAccounts.Add(savingsAccount);
            this.window.Close();

        }
    }
}
