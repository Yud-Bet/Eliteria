using Eliteria.DataAccess.Models;
using System.Windows.Controls;
using System.Windows.Media;

namespace Eliteria.Views
{
    /// <summary>
    /// Interaction logic for TransationBillView.xaml
    /// </summary>
    public partial class TransactionBillView : UserControl
    {
        public static Visual _bill { get; internal set; }


        public TransactionBillView(Transaction transaction)
        {
            InitializeComponent();
            this.tbxIdSaving.Text = transaction.idSaving.ToString();
            this.tbxCustomerName.Text = transaction.customerName;
            this.tbxTransactionMoney.Text = transaction.transactionMoney.ToString();
            this.tbxTransactionDate.Text = transaction.transactionDate.ToString();
            this.tbkStaffName.Text = transaction.staffName;
            this.tbkCustomerName.Text = transaction.customerName;
            this.tbxIdTransaction.Text = transaction.idTransaction.ToString();
            if (transaction.idTransactionType == 1)
                this.tbkTransactionType.Text = "GỬI TIỀN";
            else
            {
                if (transaction.isWithdrawInterest)
                    this.tbkTransactionType.Text = "RÚT TIỀN LÃI";
                else this.tbkTransactionType.Text = "RÚT TIỀN";
            }
        }
    }
}
