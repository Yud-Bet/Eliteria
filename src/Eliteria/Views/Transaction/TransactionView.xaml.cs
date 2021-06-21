using System.Windows.Controls;
using System.Windows.Media;

namespace Eliteria.Views.Transaction
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

    }
}
