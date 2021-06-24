using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;

namespace Eliteria.Command
{
    class DailyExportCommand : BaseCommandAsync
    {
        private ViewModels.DailyDashboardViewModel viewModel;

        public DailyExportCommand(ViewModels.DailyDashboardViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await Task.Run(() =>
            {
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
                worksheet.Cells[1, 1] = "Báo cáo doanh số hoạt động ngày " + viewModel.selectedDay;

                worksheet.Cells[2, 1] = "STT";
                worksheet.Cells[2, 2] = "Loại tiết kiệm";
                worksheet.Columns[2].ColumnWidth = 30;
                worksheet.Cells[2, 3] = "Tổng thu";
                worksheet.Columns[3].ColumnWidth = 30;
                worksheet.Cells[2, 4] = "Tổng chi";
                worksheet.Columns[4].ColumnWidth = 30;
                worksheet.Cells[2, 5] = "Chênh lệch";
                worksheet.Columns[5].ColumnWidth = 30;
                worksheet.get_Range("A1", "E1").Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                if (viewModel.DailyReport == null) return;
                for (int i = 0; i < viewModel.DailyReport.Count; i++)
                {
                    worksheet.Cells[i + 3, 1] = i + 1;
                    worksheet.Cells[i + 3, 2] = viewModel.DailyReport[i].Type;
                    worksheet.Cells[i + 3, 3] = viewModel.DailyReport[i].Revenue;
                    worksheet.Cells[i + 3, 4] = viewModel.DailyReport[i].Expense;
                    worksheet.Cells[i + 3, 5] = viewModel.DailyReport[i].Different;
                    if (i % 2 == 1)
                    {
                        worksheet.Range["A" + (i + 3), "E" + (i + 3)].Interior.Color = 0xC6E0B4;
                    }
                }
            });
        }
    }
}
