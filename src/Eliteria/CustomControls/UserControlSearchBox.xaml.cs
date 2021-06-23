using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchCommand?.Execute(null);
        }
    }
}
