using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for OtherParametersView.xaml
    /// </summary>
    public partial class OtherParametersView : UserControl
    {
        public OtherParametersView()
        {
            InitializeComponent();
        }


        public ICommand OnLoadCMD
        {
            get { return (ICommand)GetValue(OnLoadCMDProperty); }
            set { SetValue(OnLoadCMDProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OnLoadCMD.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnLoadCMDProperty =
            DependencyProperty.Register("OnLoadCMD", typeof(ICommand), typeof(OtherParametersView));


        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            OnLoadCMD?.Execute(null);
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_PreviewTextInput_1(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            ThemToiThieu.Text = ThemToiThieu.Text.Replace(",", "").Replace(".", "").Replace("₫", "").TrimEnd(' ');
            ThemToiThieu.Text = ThemToiThieu.Text.Substring(0, ThemToiThieu.Text.Length - 2);
        }

        private void TextBox_GotKeyboardFocus_1(object sender, KeyboardFocusChangedEventArgs e)
        {
            BanDauToiThieu.Text = BanDauToiThieu.Text.Replace(",", "").Replace(".", "").Replace("₫", "").TrimEnd(' ');
            BanDauToiThieu.Text = BanDauToiThieu.Text.Substring(0, BanDauToiThieu.Text.Length - 2);
        }
    }
}
