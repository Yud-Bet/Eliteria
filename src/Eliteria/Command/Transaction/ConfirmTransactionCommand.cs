using Eliteria.Views;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Eliteria.Command
{
    class ConfirmTransactionCommand : BaseCommand
    {
        Models.Parameter param = new Models.Parameter();
        private ViewModels.TransactionViewModel viewModel;

        public ConfirmTransactionCommand(ViewModels.TransactionViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override async void Execute(object parameter)
        {
            if (viewModel.SelectedSaving == null) return;
            //QĐ2: Chỉ nhận gởi thêm tiền khi đến kỳ hạn tính lãi suất của các loại tiết kiệm tương ứng. Số tiền gởi thêm tối thiểu là 100.000đ
            if (viewModel.TransactionType == 1)
            {
                if (viewModel.SelectedSaving.NextDueDate.Date == viewModel.TransactionDate.Date || viewModel.SelectedSaving.BeforeDueDate == viewModel.TransactionDate.Date)
                {
                    if (Convert.ToDecimal(viewModel.TransactionMoney) >= this.param.MinNextSendMoney)
                    {
                        await InsertTransactionData();
                        printBill();
                        viewModel.LoadAllSavingCMD?.Execute(null);
                    }
                    else
                        MessageBox.Show(String.Concat("Số tiền gởi thêm tối thiểu là ", param.MinNextSendMoney.ToString(), "VND"));
                }
                else
                {
                    //(new Command.ShowMessageCommand(this.viewModel, "Thông báo!", String.Concat("Chỉ nhận gửi thêm tiền khi đến kỳ hạn tính lãi suất: Ngày ", viewModel.SelectedSaving.NextDueDate.Date.ToString("dd/MM/yyyy"))));
                    MessageBox.Show(String.Concat("Chỉ nhận gửi thêm tiền khi đến kỳ hạn tính lãi suất: Ngày ", viewModel.SelectedSaving.NextDueDate.Date.ToString("dd/MM/yyyy")));
                }

            }
            //QĐ3:  Lãi suất là 0.5% đối với loại không kỳ hạn, 5% với kỳ hạn 3 tháng và 5.5% với kỳ hạn 6 tháng.
            //Tiền lãi 1 năm = số dư* lãi suất của loại tiết kiệm tương ứng.
            //Loại tiết kiệm có kỳ hạn chỉ được rút khi quá kỳ hạn và phải rút hết toàn bộ, khi này tiền lãi được tính với mức lãi suất của loại không kỳ hạn.
            //Loại tiết kiệm không kỳ hạn được rút khi gửi trên 15 ngày và có thể rút số tiền <= số dư hiện có.
            //Sổ sau khi rút hết tiền sẽ tự động đóng.

            else if (viewModel.TransactionType == 2)
            {
                if (!viewModel.isWithdrawInterest)
                {
                    TimeSpan timeSpan = viewModel.TransactionDate.Subtract(viewModel.SelectedSaving.OpenDate);
                    if (timeSpan.Days >= viewModel.SelectedSaving.MinDaysToWithdrawn)
                    {
                        //Loại tiết kiệm không kỳ hạn được rút khi gửi trên 15 ngày và có thể rút số tiền <= số dư hiện có.
                        if (viewModel.SelectedSaving.IdSavingType == 1)
                        {

                            if (Convert.ToDecimal(viewModel.TransactionMoney) <= viewModel.SelectedSaving.Balance)
                            {
                                await InsertTransactionData();
                                printBill();
                                await CloseSaving();
                                viewModel.LoadAllSavingCMD?.Execute(null);
                            }
                            else
                            {
                                MessageBox.Show(String.Concat("Bạn chỉ có thể rút số tiền không quá số dư hiện có là ", viewModel.SelectedSaving.Balance.ToString(), "VND"));
                            }
                        }
                        //Loại tiết kiệm có kỳ hạn chỉ được rút khi quá kỳ hạn và phải rút hết toàn bộ, khi này tiền lãi được tính với mức lãi suất của loại không kỳ hạn.
                        else if (viewModel.SelectedSaving.IdSavingType != 1)
                        {
                            if (timeSpan.Days > viewModel.SelectedSaving.MinDaysToWithdrawn)
                            {
                                //if ()
                                MessageBox.Show("");
                                if (Convert.ToDecimal(viewModel.TransactionMoney) == viewModel.SelectedSaving.Balance)
                                {
                                    await InsertTransactionData();
                                    printBill();
                                    //Sổ sau khi rút hết tiền sẽ tự động đóng.
                                    await CloseSaving();
                                    viewModel.LoadAllSavingCMD?.Execute(null);
                                }
                                else
                                {
                                    MessageBox.Show(String.Concat("Bạn chỉ có thể rút hết số tiền hiện có là ", viewModel.SelectedSaving.Balance.ToString(), "VND"));
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show(String.Concat("Loại tiết kiệm không kỳ hạn được rút khi gửi trên ",
                                                            viewModel.SelectedSaving.MinDaysToWithdrawn.ToString(),
                                                            " ngày! \nXin vui lòng quay lại sau ngày ",
                                                            viewModel.SelectedSaving.OpenDate.AddDays(viewModel.SelectedSaving.MinDaysToWithdrawn).Date.ToString("dd/MM/yyyy")));
                        }
                    }
                    else
                    {
                        MessageBox.Show(String.Concat("Chỉ được rút khi gửi trên ",
                                                        viewModel.SelectedSaving.MinDaysToWithdrawn.ToString(),
                                                        " ngày! \nXin vui lòng quay lại sau ngày ",
                                                        viewModel.SelectedSaving.OpenDate.AddDays(viewModel.SelectedSaving.MinDaysToWithdrawn).Date.ToString("dd/MM/yyyy")));
                    }

                }
                else
                {
                    //viewModel.TransactionMoney = viewModel.SelectedSaving.Interest.ToString();
                    await WithdrawInterest(Convert.ToInt32(viewModel.SelectedSaving.AccountNumber)); 
                    printBill();
                    viewModel.LoadAllSavingCMD?.Execute(null);

                }
            }
        }

        public async Task InsertTransactionData()
        {
            int result = await DataAccess.TransactionData.InsertNewTransaction(viewModel.TransactionType,
                                                                                Convert.ToInt32(viewModel.SelectedSaving.AccountNumber),
                                                                                1,  //idStaff
                                                                                Convert.ToDateTime(viewModel.TransactionDate),
                                                                                Convert.ToDecimal(viewModel.TransactionMoney));
            if (result > 0)
            {
                MessageBox.Show("Giao dịch thành công!");
            }
        }

        public void printBill()
        {
            if (viewModel.isPrintBill)
            {
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(TransactionView._transation, "Eliteria");
                }
            }

        }

        public async Task CloseSaving()
        {
            int result = await DataAccess.TransactionData.ControlCloseSaving();
            if (result > 0)
            {
                MessageBox.Show("Đóng sổ tự động thành công!");
            }
        }
        public async Task WithdrawInterest(int idSaving)
        {
            int result = await DataAccess.TransactionData.WithdrawInterest(idSaving);
            if (result > 0)
            {
                MessageBox.Show("Rút tiền lãi thành công!");
            }

        }
    }
}
