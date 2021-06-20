using Eliteria.Models;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace Eliteria.Views
{
    /// <summary>
    /// Interaction logic for ASavingProfileView.xaml
    /// </summary>
    public partial class ASavingProfileView : UserControl
    {
        public Window window;
        public SavingsAccount _savingsAccount;
        public string ASavingsID { get; set; }
        public string ASavingsType { get; set; }
        public string ASavingsOwnerName { get; set; }
        public string ASavingsOwnerID { get; set; }
        public string ASavingsOwnerAddress { get; set; }
        public decimal ASavingsBlance { get; set; }
        public string ASavingsOpenDate { get; set; }

        public ASavingProfileView(SavingsAccount savingsAccount)
        {
            InitializeComponent();
            this.DataContext = this;            
            this._savingsAccount = savingsAccount;
            ASavingsID = _savingsAccount.AccountNumber;
            ASavingsType = _savingsAccount.Type;
            ASavingsOwnerName = _savingsAccount.Name;
            ASavingsOwnerID = _savingsAccount.IdentificationNumber;
            ASavingsOwnerAddress = _savingsAccount.Address;
            ASavingsBlance = _savingsAccount.Balance;
            ASavingsOpenDate = _savingsAccount.OpenDate.ToString("dd/MM/yyyy");

        }

        private void btnClose_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            window.Close();
        }



        private void ASaving_Loaded(object sender, RoutedEventArgs e)
        {
            this.window = Window.GetWindow(this);
        }
    }
}
