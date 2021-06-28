using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Eliteria.CustomControls
{
    /// <summary>
    /// Interaction logic for SavingTypeList.xaml
    /// </summary>
    public partial class SavingTypeList : UserControl
    {
        public SavingTypeList()
        {
            InitializeComponent();
        }
        public ObservableCollection<Models.SavingType> ItemsSource
        {
            get { return (ObservableCollection<Models.SavingType>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<Models.SavingType>), typeof(SavingTypeList));


        public ICommand EditItemCommand
        {
            get { return (ICommand)GetValue(EditItemCommandProperty); }
            set { SetValue(EditItemCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for EditItemCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EditItemCommandProperty =
            DependencyProperty.Register("EditItemCommand", typeof(ICommand), typeof(SavingTypeList));


        private void ListBoxItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Models.SavingType savingType = (Models.SavingType)SavingTypeListBox.SelectedItem;
            EditItemCommand?.Execute(savingType);
        }
    }
}
