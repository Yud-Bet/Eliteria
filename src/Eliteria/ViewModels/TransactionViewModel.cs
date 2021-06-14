using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eliteria.ViewModels
{
    class TransactionViewModel : BaseViewModel
    {
        public ICommand navigateSendMoneyCMD { get; }
        public ICommand navigateWithdrawMoneyCMD { get; }
        public ICommand navigateConfirmCMD { get; }
        public ICommand navigateCancelCMD { get; }
        public ICommand navigateCheckPrintBill { get; }
        public TransactionViewModel()
        {
        }
    }
}
