using Eliteria.DataAccess.Models;
using Eliteria.DataAccess.Modules;
using Eliteria.Views;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace Eliteria.Command
{
    class ConfirmTransactionCommand : BaseCommand
    {
        OtherParameter otherParameter;
        private ViewModels.TransactionViewModel viewModel;
        private ViewModels.TransactionBillViewModel billViewModel = new ViewModels.TransactionBillViewModel() ;

        public ConfirmTransactionCommand(ViewModels.TransactionViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override async void Execute(object parameter)
        {

            if (viewModel.SelectedSaving == null) return;
            if (viewModel.TransactionMoney == "")
            {
                viewModel.ErrorStatus = "Vui lòng nhập số tiền giao dịch";
                viewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                return;
            }
            DataTable data = await DataAccess.ExecuteQuery.ExecuteReaderAsync("Eliteria_LoadOtherParameters");
            if (data != null)
            {
                otherParameter = new OtherParameter
                {
                    MinDepositAmount = (Decimal)data.Rows[0][1],
                    MinInitialDeposit = (Decimal)data.Rows[0][0],
                    ControlClosingSaving = (bool)data.Rows[0][2]
                };
            }
                //if ()
                //QĐ2: Chỉ nhận gởi thêm tiền khi đến kỳ hạn tính lãi suất của các loại tiết kiệm tương ứng. Số tiền gởi thêm tối thiểu là 100.000đ
                if (viewModel.TransactionType == 1)
            {
                if (viewModel.SelectedSaving.NextDueDate.Date == viewModel.TransactionDate.Date || viewModel.SelectedSaving.BeforeDueDate == viewModel.TransactionDate.Date)
                {
                    if (Convert.ToDecimal(viewModel.TransactionMoney) >= this.otherParameter.MinDepositAmount)
                    {
                        InsertTransactionData();
                        LastTransactionID();
                        printBill();
                        viewModel.LoadAllSavingCMD?.Execute(null);
                    }
                    else
                    {
                        viewModel.ErrorStatus = String.Concat("Số tiền gởi thêm tối thiểu là ", otherParameter.MinDepositAmount.ToString(), "VND");
                        viewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    }
                }
                else
                {
                    viewModel.ErrorStatus = String.Concat("Chỉ nhận gửi thêm tiền khi đến kỳ hạn tính lãi suất: Ngày ", viewModel.SelectedSaving.NextDueDate.Date.ToString("dd/MM/yyyy"));
                    viewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                }

            }
            //QĐ3:  Lãi suất là 0.5% đối với loại không kỳ hạn, 5% với kỳ hạn 3 tháng và 5.5% với kỳ hạn 6 tháng.
            //Tiền lãi 1 năm = số dư* lãi suất của loại tiết kiệm tương ứng.
            //Loại tiết kiệm có kỳ hạn chỉ được rút khi quá kỳ hạn và phải rút hết toàn bộ, khi này tiền lãi được tính với mức lãi suất của loại không kỳ hạn.
            //Loại tiết kiệm không kỳ hạn được rút khi gửi trên 15 ngày và có thể rút số tiền <= số dư hiện có.
            //Sổ sau khi rút hết tiền sẽ tự động đóng.

            else if (viewModel.TransactionType == 2)
            {
                //RÚT TIỀN
                if (!viewModel.isWithdrawInterest)
                {
                    //Kiểm tra số ngày gửi tối thiểu
                    TimeSpan timeSpan = viewModel.TransactionDate.Subtract(viewModel.SelectedSaving.OpenDate);
                    if (timeSpan.Days >= viewModel.SelectedSaving.MinDaysToWithdrawn)
                    {
                        //Loại tiết kiệm không kỳ hạn được rút khi gửi trên 15 ngày và có thể rút số tiền <= số dư hiện có.
                        if (viewModel.SelectedSaving.IdSavingType == 1)
                        {
                            if (Convert.ToDecimal(viewModel.TransactionMoney) <= viewModel.SelectedSaving.Balance)
                            {
                                InsertTransactionData();
                                LastTransactionID();
                                printBill();
                                CloseSaving();
                                viewModel.LoadAllSavingCMD?.Execute(null);
                            }
                            else
                            {
                                viewModel.ErrorStatus = String.Concat("Bạn chỉ có thể rút số tiền không quá số dư hiện có là ", viewModel.SelectedSaving.Balance.ToString(), "VND");
                                viewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                            }
                        }
                        //Loại tiết kiệm có kỳ hạn chỉ được rút khi quá kỳ hạn và phải rút hết toàn bộ, khi này tiền lãi được tính với mức lãi suất của loại không kỳ hạn.
                        else 
                        {
                            //Tính lãi suất trước kỳ hạn
                            if (viewModel.SelectedSaving.NextDueDate.Date != viewModel.TransactionDate.Date && viewModel.SelectedSaving.BeforeDueDate != viewModel.TransactionDate.Date)
                            {
                                ICommand message = new ShowMessageCommand(viewModel.navigationStore, "Thông báo", "Bạn rút tiền trước kỳ hạn nên áp dụng lãi suất không kỳ hạn");
                                message.Execute(null);
                                CalculatePreMaturityInterest(Convert.ToInt32(viewModel.SelectedSaving.AccountNumber));
                                InsertTransactionData();
                                LastTransactionID();
                                printBill();
                                CloseSaving();
                                viewModel.LoadAllSavingCMD?.Execute(null);
                            }
                            else
                            {
                                if (Convert.ToDecimal(viewModel.TransactionMoney) == viewModel.SelectedSaving.Balance)
                                {
                                    InsertTransactionData();
                                    LastTransactionID();
                                    printBill();
                                    CloseSaving();
                                    viewModel.LoadAllSavingCMD?.Execute(null);
                                }
                                else
                                {
                                    viewModel.ErrorStatus = String.Concat("Bạn chỉ có thể rút hết số tiền hiện có là ", viewModel.SelectedSaving.Balance.ToString(), "VND");
                                    viewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                                }
                            }
                        }
                    }
                    else
                    {
                        viewModel.ErrorStatus = String.Concat("Chỉ được rút khi gửi trên ",
                                                        viewModel.SelectedSaving.MinDaysToWithdrawn.ToString(),
                                                        " ngày! \nXin vui lòng quay lại sau ngày ",
                                                        viewModel.SelectedSaving.OpenDate.AddDays(viewModel.SelectedSaving.MinDaysToWithdrawn).Date.ToString("dd/MM/yyyy"));
                        viewModel.ErrorColor = System.Windows.Media.Brushes.Red;
                    }

                }
                //RÚT TIỀN LÃI
                else
                {
                    WithdrawInterest(Convert.ToInt32(viewModel.SelectedSaving.AccountNumber));
                    LastTransactionID();
                    printBill();
                    viewModel.LoadAllSavingCMD?.Execute(null);

                }
            }
        }

        public void LastTransactionID()
        {
            try
            {
                int id = MoneyTransactionModule.GetLastTransactionID();
                if (id != -1) viewModel.idTransaction = id;
            }
            catch (Exception ex)
            {
                ICommand message = new ShowMessageCommand(viewModel.navigationStore, "Thông báo", ex.Message);
                message.Execute(null);
            }
        }
        public void InsertTransactionData()
        {
            try
            {
                TransactionSlipData data = new TransactionSlipData
                {
                    TransactionTypeID = viewModel.TransactionType,
                    SavingsID = Convert.ToInt32(viewModel.SelectedSaving.AccountNumber),
                    StaffID = viewModel.accountStore.CurrentAccount.StaffID,
                    TransactionDate = viewModel.TransactionDate,
                    Amount = Convert.ToDecimal(viewModel.TransactionMoney)
                };
                bool result = MoneyTransactionModule.InsertNewTransaction(data);
                if (result == true)
                {
                    viewModel.ErrorStatus = "Giao dịch thành công!";
                    viewModel.ErrorColor = System.Windows.Media.Brushes.Green;
                }
            }
            catch (Exception ex)
            {
                ICommand message = new Command.ShowMessageCommand(viewModel.navigationStore, "Thông báo", ex.Message);
                message.Execute(null);
            }
        }

        public void printBill()
        {
            try
            {
                if (viewModel.isPrintBill)
                {
                    PrintDialog printDialog = new PrintDialog();
                    if (printDialog.ShowDialog() == true)
                    {
                        Transaction transaction = new Transaction();
                        transaction.idTransactionType = viewModel.TransactionType;
                        transaction.idSaving = Convert.ToInt32(viewModel.SelectedSaving.AccountNumber);
                        transaction.customerName = viewModel.SelectedSaving.Name;
                        transaction.transactionMoney = Convert.ToDecimal(viewModel.TransactionMoney);
                        transaction.transactionDate = viewModel.TransactionDate;
                        transaction.staffName = viewModel.accountStore.CurrentAccount.StaffName; //
                        transaction.isWithdrawInterest = viewModel.isWithdrawInterest;
                        transaction.idTransaction = viewModel.idTransaction;
                        TransactionBillView transactionBillView = new TransactionBillView(transaction);
                        printDialog.PrintVisual(transactionBillView.bill, "Eliteria");
                    }
                }
            }
            catch (Exception ex)
            {
                ICommand message = new ShowMessageCommand(viewModel.navigationStore, "Lỗi", ex.Message);
                message.Execute(null);
            }

        }

        public void CloseSaving()
        {
            try
            {
                bool result = MoneyTransactionModule.ControlCloseSavings();
                if (result == true)
                {
                    viewModel.ErrorStatus = "Đóng sổ tự động thành công!";
                    viewModel.ErrorColor = System.Windows.Media.Brushes.Green;
                }
            }
            catch (Exception ex)
            {
                ICommand message = new Command.ShowMessageCommand(viewModel.navigationStore, "Thông báo", ex.Message);
                message.Execute(null);
            }
        }
        public void WithdrawInterest(int idSaving)
        {
            try
            {
                bool result = MoneyTransactionModule.WithdrawInterest(idSaving);
                if (result == true)
                {
                    viewModel.ErrorStatus = "Rút tiền lãi thành công!";
                    viewModel.ErrorColor = System.Windows.Media.Brushes.Green;
                }
            }
            catch (Exception ex)
            {
                ICommand message = new Command.ShowMessageCommand(viewModel.navigationStore, "Thông báo", ex.Message);
                message.Execute(null);
            }
        }
        public void CalculatePreMaturityInterest(int idSaving)
        {
            try
            {
                decimal trans = MoneyTransactionModule.CalculatePreMaturityInterest(idSaving);
                if (trans != -1)
                {
                    viewModel.ErrorStatus = "Tính lãi trước kỳ hạn thành công!";
                    viewModel.ErrorColor = System.Windows.Media.Brushes.Green;
                    viewModel.TransactionMoney = trans.ToString();
                }
            }
            catch (Exception ex)
            {
                ICommand message = new Command.ShowMessageCommand(viewModel.navigationStore, "Thông báo", ex.Message);
                message.Execute(null);
            }
        }
        public void GetSavingIf(int idSaving)
        {
            try
            {
                SavingsAccount item = MoneyTransactionModule.GetSavingsWithID(idSaving);
                viewModel.SelectedSaving = item;
            }
            catch (Exception ex)
            {
                ICommand message = new Command.ShowMessageCommand(viewModel.navigationStore, "Thông báo", ex.Message);
                message.Execute(null);
            }
        }

    }
}
