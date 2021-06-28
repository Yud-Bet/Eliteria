using Eliteria.Models;
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
