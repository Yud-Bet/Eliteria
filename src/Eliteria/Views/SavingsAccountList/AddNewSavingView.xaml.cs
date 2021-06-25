using Eliteria.DataAccess;
using Eliteria.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Eliteria.Views
{
    /// <summary>
    /// Interaction logic for AddNewSaving.xaml
    /// </summary>
    public partial class AddNewSaving : UserControl
    {
        public Window window;

        public CustomControls.SavingsAccountList SavingsAccountList;
        public SavingsAccount SavingsAccount;
        private ObservableCollection<Models.SavingsAccount> UpdatedsavingsAccounts;


        public List<string> IDlist;
       



        public AddNewSaving(CustomControls.SavingsAccountList savingsAccountList)
        {
            this.SavingsAccountList = savingsAccountList;            
            InitializeComponent();
            rbtnNewCustomer.IsChecked = true;
        }
        private void btnCancel_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.window.Close();
        }
        private void AddNewSaving_Loaded(object sender, RoutedEventArgs e)
        {
            this.window = Window.GetWindow(this);
            IDlist = new List<string>();
        }

        private async void btnCreate_Click(object sender, RoutedEventArgs e)
        {   
            
            if((bool)rbtnOldCustomer.IsChecked)
            {
                 
                ComboBoxItem comboBoxItemsSVtype = (ComboBoxItem)cbxSavingtype.SelectedItem;
                if(cbxSavingtype.SelectedItem==null||OpenDate.SelectedDate==null||SavingAmount.Text==null||cbxID.SelectedItem==null)
                {
                    MessageBox.Show("Vui lòng nhập đủ dữ liệu", "Lỗi!", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                DACreateNewSavings.AsOldCustomer(cbxID.SelectedItem.ToString(), comboBoxItemsSVtype.Content.ToString(), OpenDate.SelectedDate.Value, Convert.ToDecimal(SavingAmount.Text));
                UpdatedsavingsAccounts = await DASavingAccountList.LoadListFromDatabase();

                var NewAddedSavings = UpdatedsavingsAccounts.Where(x => x.IdentificationNumber.Equals(cbxID.SelectedItem.ToString()) && x.OpenDate.Equals(OpenDate.SelectedDate.Value));
                SavingsAccountList.ItemsSource.Add(NewAddedSavings.ElementAt(0));
                this.window.Close();
            }
            else if ((bool)rbtnNewCustomer.IsChecked)
            {
                if(SavingID.Text==null||cbxSavingtype.SelectedItem==null||Fullname.Text==null||CustomerID.Text==null||CustomerAddress.Text==null||SavingAmount.Text ==null||OpenDate.SelectedDate==null||CustomerEmail.Text==null||cbxGender.SelectedItem==null||datepicker_DoB.SelectedDate ==null)
                {
                    MessageBox.Show("Vui lòng nhập đủ dữ liệu", "Lỗi!", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                SavingsAccount = new SavingsAccount();
                SavingsAccount.AccountNumber = SavingID.Text;
                ComboBoxItem comboBoxItem = (ComboBoxItem)cbxSavingtype.SelectedItem;
                SavingsAccount.Type = comboBoxItem.Content.ToString();
                SavingsAccount.Name = Fullname.Text;
                SavingsAccount.IdentificationNumber = CustomerID.Text;
                SavingsAccount.Address = CustomerAddress.Text;
                SavingsAccount.Balance = Convert.ToDecimal(SavingAmount.Text);
                SavingsAccount.OpenDate = OpenDate.SelectedDate.Value;
                SavingsAccount.Email = CustomerEmail.Text;
                SavingsAccount.Phonenumber = CustomerPhoneNumber.Text;
                ComboBoxItem comboBoxItemgender = (ComboBoxItem)cbxGender.SelectedItem;
                SavingsAccount.Gender = comboBoxItemgender.Content.ToString();
                SavingsAccount.DoB = datepicker_DoB.SelectedDate.Value;
                DACreateNewSavings.AsNewCustomer(SavingsAccount);

                UpdatedsavingsAccounts = await DASavingAccountList.LoadListFromDatabase();

                var NewAddedSavings = UpdatedsavingsAccounts.Where(x => x.IdentificationNumber.Equals(CustomerID.Text) && x.OpenDate.Equals(OpenDate.SelectedDate.Value));
                SavingsAccountList.ItemsSource.Add(NewAddedSavings.ElementAt(0));
                this.window.Close();
            }
           
        }
        private void CustomerPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private  void rbtnOldCustomer_Checked(object sender, RoutedEventArgs e)
        {
                 
            DAGetCustomerList.DAGetCustomerListIDs(IDlist);
            this.cbxID.ItemsSource = IDlist;
            SavingTypeLable.Visibility = Visibility.Visible;
            cbxSavingtype.Visibility = Visibility.Visible;

            Namelabel.Visibility = Visibility.Hidden;
            Fullname.Visibility = Visibility.Hidden;
            CrossLine1.Visibility = Visibility.Hidden;

           
            CustomerID.Visibility = Visibility.Hidden;
            CrossLine2.Visibility = Visibility.Hidden;
            DobLabel.Visibility = Visibility.Hidden;
            datepicker_DoB.Visibility = Visibility.Hidden;

            AddressLabel.Visibility = Visibility.Hidden;
            CustomerAddress.Visibility = Visibility.Hidden;
            CrossLine3.Visibility = Visibility.Hidden;

            SavingsAmountlabel.Visibility = Visibility.Visible;
            SavingAmount.Visibility = Visibility.Visible;
            CrossLine4.Visibility = Visibility.Visible;

            OpenDateLabel.Visibility = Visibility.Visible;
            OpenDate.Visibility = Visibility.Visible;

            EmailLabel.Visibility = Visibility.Hidden;
            CustomerEmail.Visibility = Visibility.Hidden;
            CrossLine5.Visibility = Visibility.Hidden;

            Phonelabel.Visibility = Visibility.Hidden;
            CustomerPhoneNumber.Visibility = Visibility.Hidden;
            CrossLine6.Visibility = Visibility.Hidden;
            GenderLabel.Visibility = Visibility.Hidden;
            cbxGender.Visibility = Visibility.Hidden;

            cbxID.Visibility = Visibility.Visible;





        }

        private async void rbtnNewCustomer_Checked(object sender, RoutedEventArgs e)
        {
           
            SavingTypeLable.Visibility = Visibility.Visible;
            cbxSavingtype.Visibility = Visibility.Visible;

            Namelabel.Visibility = Visibility.Visible;
            Fullname.Visibility = Visibility.Visible;
            CrossLine1.Visibility = Visibility.Visible;


            CustomerID.Visibility = Visibility.Visible;
            CrossLine2.Visibility = Visibility.Visible;
            DobLabel.Visibility = Visibility.Visible;
            datepicker_DoB.Visibility = Visibility.Visible;

            AddressLabel.Visibility = Visibility.Visible;
            CustomerAddress.Visibility = Visibility.Visible;
            CrossLine3.Visibility = Visibility.Visible;

            SavingsAmountlabel.Visibility = Visibility.Visible;
            SavingAmount.Visibility = Visibility.Visible;
            CrossLine4.Visibility = Visibility.Visible;

            OpenDateLabel.Visibility = Visibility.Visible;
            OpenDate.Visibility = Visibility.Visible;

            EmailLabel.Visibility = Visibility.Visible;
            CustomerEmail.Visibility = Visibility.Visible;
            CrossLine5.Visibility = Visibility.Visible;

            Phonelabel.Visibility = Visibility.Visible; ;
            CustomerPhoneNumber.Visibility = Visibility.Visible;
            CrossLine6.Visibility = Visibility.Visible;
            GenderLabel.Visibility = Visibility.Visible;
            cbxGender.Visibility = Visibility.Visible;

            cbxID.Visibility = Visibility.Hidden;
        }

        private void SavingAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
