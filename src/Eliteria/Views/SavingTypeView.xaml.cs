using System;
using System.Collections.Generic;
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

namespace Eliteria.Views
{
    /// <summary>
    /// Interaction logic for SavingTypeView.xaml
    /// </summary>
    public partial class SavingTypeView : UserControl
    {
        public SavingTypeView()
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
            DependencyProperty.Register("OnLoadCommand", typeof(ICommand), typeof(SavingTypeView));

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (OnLoadCommand != null)
            {
                OnLoadCommand?.Execute(null);
            }
        }
    }
}
