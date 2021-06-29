using Eliteria.Models;
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
        Parameter param = new Models.Parameter();
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
            //if ()
            //QĐ2: Chỉ nhận gởi thêm tiền khi đến kỳ hạn tính lãi suất của các loại tiết kiệm tương ứng. Số tiền gởi thêm tối thiểu là 100.000đ
            if (viewModel.TransactionType == 1)
            {
                if (viewModel.SelectedSaving.NextDueDate.Date == viewModel.TransactionDate.Date || viewModel.SelectedSaving.BeforeDueDate == viewModel.TransactionDate.Date)
                {
                    if (Convert.ToDecimal(viewModel.TransactionMoney) >= this.param.MinNextSendMoney)
                    {
                        await InsertTransactionData();
                        await LastTransactionID();
                        printBill();
                        viewModel.LoadAllSavingCMD?.Execute(null);
                    }
                    else
                    {
                        viewModel.ErrorStatus = String.Concat("Số tiền gởi thêm tối thiểu là ", param.MinNextSendMoney.ToString(), "VND");
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
                                await InsertTransactionData();
                                await LastTransactionID();
                                printBill();
                                await CloseSaving();
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

                                await CalculatePreMaturityInterest(Convert.ToInt32(viewModel.SelectedSaving.AccountNumber));
                                await InsertTransactionData();
                                await LastTransactionID();
                                printBill();
                                await CloseSaving();
                                viewModel.LoadAllSavingCMD?.Execute(null);
                            }
                            else
                            {
                                if (Convert.ToDecimal(viewModel.TransactionMoney) == viewModel.SelectedSaving.Balance)
                                {
                                    await InsertTransactionData();
                                    await LastTransactionID();
                                    printBill();
                                    await CloseSaving();
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
                    await WithdrawInterest(Convert.ToInt32(viewModel.SelectedSaving.AccountNumber));
                    await LastTransactionID();
                    printBill();
                    viewModel.LoadAllSavingCMD?.Execute(null);

                }
            }
        }

        public async Task LastTransactionID()
        {
            try
            {
                DataTable data = await DataAccess.TransactionData.LastTransactionID();
                if (data.Rows.Count > 0)
                {
                    int idTran = Convert.ToInt32(data.Rows[0].ItemArray[0]);
                    viewModel.idTransaction = idTran;
                }
            }
            catch (Exception ex)
            {
                ICommand message = new ShowMessageCommand(viewModel.navigationStore, "Thông báo", ex.Message);
                message.Execute(null);
            }
        }
        public async Task InsertTransactionData()
        {
            try
            {

                int result = await DataAccess.TransactionData.InsertNewTransaction(viewModel.TransactionType,
                                                                                    Convert.ToInt32(viewModel.SelectedSaving.AccountNumber),
                                                                                    1, //Convert.ToInt32(viewModel.accountStore.CurrentAccount.Username),  //idStaff
                                                                                    Convert.ToDateTime(viewModel.TransactionDate),
                                                                                    Convert.ToDecimal(viewModel.TransactionMoney));
                if (result > 0)
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
                        transaction.staffName = "..."; //viewModel.accountStore.CurrentAccount.StaffName; //
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

        public async Task CloseSaving()
        {
            try
            {

                int result = await DataAccess.TransactionData.ControlCloseSaving();
                if (result > 0)
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
        public async Task WithdrawInterest(int idSaving)
        {
            try
            {
                int result = await DataAccess.TransactionData.WithdrawInterest(idSaving);
                if (result > 0)
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
        public async Task CalculatePreMaturityInterest(int idSaving)
        {
            try
            {
                DataTable data = await DataAccess.TransactionData.CalculatePreMaturityInterest(idSaving);
                if (data.Rows.Count > 0)
                {
                    viewModel.ErrorStatus = "Tính lãi trước kỳ hạn thành công!";
                    viewModel.ErrorColor = System.Windows.Media.Brushes.Green;
                    viewModel.TransactionMoney = Convert.ToString((decimal)data.Rows[0].ItemArray[0]);
                }
            }
            catch (Exception ex)
            {
                ICommand message = new Command.ShowMessageCommand(viewModel.navigationStore, "Thông báo", ex.Message);
                message.Execute(null);
            }
        }
        public async Task GetSavingIf(int idSaving)
        {
            try
            {
                DataTable data = await DataAccess.TransactionData.GetSavingIf(idSaving);
                if (data.Rows.Count > 0)
                {
                    SavingsAccount item = new SavingsAccount();
                    item.AccountNumber = Convert.ToString(data.Rows[0].ItemArray[0]);
                    item.Name = Convert.ToString(data.Rows[0].ItemArray[1]);
                    item.Balance = Convert.ToDecimal(data.Rows[0].ItemArray[2]);
                    item.NextDueDate = Convert.ToDateTime(data.Rows[0].ItemArray[3]);
                    item.PrescribedAmountDrawn = Convert.ToString(data.Rows[0].ItemArray[4]);
                    item.BeforeDueDate = Convert.ToDateTime(data.Rows[0].ItemArray[5]);
                    item.OpenDate = Convert.ToDateTime(data.Rows[0].ItemArray[6]);
                    item.IdSavingType = Convert.ToInt32(data.Rows[0].ItemArray[7]);
                    item.MinDaysToWithdrawn = Convert.ToInt32(data.Rows[0].ItemArray[8]);
                    item.Interest = Convert.ToInt32(data.Rows[0].ItemArray[9]);
                    viewModel.SelectedSaving = item;
                }
            }
            catch (Exception ex)
            {
                ICommand message = new Command.ShowMessageCommand(viewModel.navigationStore, "Thông báo", ex.Message);
                message.Execute(null);
            }
        }

    }
}
