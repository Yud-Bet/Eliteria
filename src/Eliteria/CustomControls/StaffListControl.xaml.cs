using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Eliteria.CustomControls
{
    /// <summary>
    /// Interaction logic for StaffListControl.xaml
    /// </summary>
    public partial class StaffListControl : UserControl
    {
        public StaffListControl()
        {
            InitializeComponent();
        }


        public ObservableCollection<Models.Account> ItemsSource
        {
            get { return (ObservableCollection<Models.Account>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<Models.Account>), typeof(StaffListControl));



        public ICommand OnDoubleClickCMD
        {
            get { return (ICommand)GetValue(OnDoubleClickCMDProperty); }
            set { SetValue(OnDoubleClickCMDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OnDoubleClickCMD.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnDoubleClickCMDProperty =
            DependencyProperty.Register("OnDoubleClickCMD", typeof(ICommand), typeof(StaffListControl));


        public int SelectedIndex
        {
            get { return (int)GetValue(SelectedIndexProperty); }
            set { SetValue(SelectedIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedIndexProperty =
            DependencyProperty.Register("SelectedIndex", typeof(int), typeof(StaffListControl), new PropertyMetadata(-1));


        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedItem.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(StaffListControl));


        private void ListBoxItem_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Models.Account selected = (Models.Account)StaffsListBox.SelectedItem;
            OnDoubleClickCMD?.Execute(selected);
        }
    }
}
