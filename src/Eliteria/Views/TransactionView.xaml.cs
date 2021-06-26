using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Eliteria.Views
{
    /// <summary>
    /// Interaction logic for TransactionView.xaml
    /// </summary>
    public partial class TransactionView : UserControl
    {
        public static Visual _transation { get; internal set; }

        public TransactionView()
        {
            InitializeComponent();
            _transation = transaction;
        }



        public ICommand OnLoadCommand
        {
            get { return (ICommand)GetValue(OnLoadCommandProperty); }
            set { SetValue(OnLoadCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OnLoadCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OnLoadCommandProperty =
            DependencyProperty.Register("OnLoadCommand", typeof(ICommand), typeof(TransactionView));



        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            OnLoadCommand?.Execute(null);
        }
    }
}