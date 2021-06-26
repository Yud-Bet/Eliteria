using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Eliteria.Command
{
    class MonthlyExportCommand : BaseCommandAsync
    {
        private ViewModels.MonthlyDashboardViewModel viewModel;

        public MonthlyExportCommand(ViewModels.MonthlyDashboardViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await Task.Run(() => {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Visible = true;
                Excel.Workbook workbook;
                Excel.Worksheet worksheet;
                workbook = excelApp.Workbooks.Add();
                worksheet = (Excel.Worksheet)workbook.Worksheets.get_Item(1);
                worksheet.Name = "DailyReport";

                worksheet.Range["A1", "E1"].Merge();
                worksheet.Rows[1].RowHeight = 30;
                worksheet.get_Range("A1", "A1").Cells.Font.Size = 20;
                worksheet.Cells[1, 1] = "Báo cáo mở/đóng sổ tháng " + viewModel.SelectedMonth;
                worksheet.Range["A2", "E2"].Merge();
                worksheet.Cells[2, 1] = "Loại sổ tiết kiệm: " + viewModel.SelectedAccType;

                worksheet.Cells[3, 1] = "STT";
                worksheet.Cells[3, 2] = "Ngày";
                worksheet.Columns[2].ColumnWidth = 30;
                worksheet.Cells[3, 3] = "Sổ mở";
                worksheet.Columns[3].ColumnWidth = 30;
                worksheet.Cells[3, 4] = "Sổ đóng";
                worksheet.Columns[4].ColumnWidth = 30;
                worksheet.Cells[3, 5] = "Chênh lệch";
                worksheet.Columns[5].ColumnWidth = 30;
                worksheet.get_Range("A1", "E1").Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                if (viewModel.MonthlyReport == null) return;
                for (int i = 0; i < viewModel.MonthlyReport.Count; i++)
                {
                    worksheet.Cells[i + 4, 1] = i + 1;
                    worksheet.Cells[i + 4, 2] = viewModel.MonthlyReport[i].Date;
                    worksheet.Cells[i + 4, 3] = viewModel.MonthlyReport[i].Closed;
                    worksheet.Cells[i + 4, 4] = viewModel.MonthlyReport[i].Opened;
                    worksheet.Cells[i + 4, 5] = viewModel.MonthlyReport[i].Different;
                    if (i % 2 == 1)
                    {
                        worksheet.Range["A" + (i + 4), "E" + (i + 4)].Interior.Color = 0xC6E0B4;
                    }
                }
            });
        }
    }
}
