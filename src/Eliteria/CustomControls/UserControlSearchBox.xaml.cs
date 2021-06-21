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

namespace Eliteria.CustomControls
{
    /// <summary>
    /// Interaction logic for UserControlSearchBox.xaml
    /// </summary>
    public partial class UserControlSearchBox : UserControl
    {
        public UserControlSearchBox()
        {
            InitializeComponent();
            
        }



        public ICommand SearchCommand
        {
            get { return (ICommand)GetValue(SearchCommandProperty); }
            set { SetValue(SearchCommandProperty, value); }
        }
     
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(UserControlSearchBox));



        public static readonly DependencyProperty SearchCommandProperty =
            DependencyProperty.Register("SearchCommand", typeof(ICommand), typeof(UserControlSearchBox));
        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (SearchCommand != null)
            {
                SearchCommand.Execute(null);
            }
        }

     
    }
}
