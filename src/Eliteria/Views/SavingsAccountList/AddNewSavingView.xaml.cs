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
    public partial class AddNewSavingView : UserControl
    {
        public AddNewSavingView()
        {
            InitializeComponent();           
        }

        private void CustomerPhoneNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        public ICommand OnLoadCommand
        {
            get { return (ICommand)GetValue(OnLoadCommandProperty); }
            set { SetValue(OnLoadCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OnLoadCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnLoadCommandProperty =
            DependencyProperty.Register("OnLoadCommand", typeof(ICommand), typeof(AddNewSavingView));


        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (OnLoadCommand != null)
            {
                OnLoadCommand.Execute(null);
            }
        }
        private void rbtnOldCustomer_Checked(object sender, RoutedEventArgs e)
        {
            cbxGender.Visibility = Visibility.Hidden;
            txtGender.Visibility = Visibility.Visible;
            CustomerID.Visibility = Visibility.Hidden;
            CrossLine2.Visibility = Visibility.Hidden;
            cbxID.Visibility = Visibility.Visible;
        }

        private void rbtnNewCustomer_Checked(object sender, RoutedEventArgs e)
        {
            Fullname.Text = "";
            datepicker_DoB.SelectedDate = DateTime.Now;
            Fullname.Text = "";
            CustomerAddress.Text = "";
            CustomerEmail.Text = "";
            CustomerPhoneNumber.Text = "";
            cbxGender.SelectedItem = null;

            cbxGender.Visibility = Visibility.Visible;
            txtGender.Visibility = Visibility.Hidden;
            CustomerID.Visibility = Visibility.Visible;
            CrossLine2.Visibility = Visibility.Visible;
            cbxID.Visibility = Visibility.Hidden;
        }

        private void SavingAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void cbxID_DropDownClosed(object sender, EventArgs e)
        {
            hiddenbtn.Command.Execute(null);
        }

        private void CustomerID_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

     
    }
}
