using System.Data;
using OfficeOpenXml;

namespace Demo_MVC.Models.Process
{
    public class ExcelProcess
    {
        public DataTable ExcelToDataTable(string filePath)
        {
            // Thiết lập License dùng miễn phí (đúng cú pháp EPPlus)
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            var dt = new DataTable();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();
                if (worksheet == null)
                    return dt;

                int colCount = worksheet.Dimension.End.Column;
                int rowCount = worksheet.Dimension.End.Row;

                // Tạo tên cột từ dòng 1
                for (int col = 1; col <= colCount; col++)
                {
                    string columnName = worksheet.Cells[1, col].Text;
                    if (string.IsNullOrWhiteSpace(columnName))
                        columnName = $"Column{col}";

                    dt.Columns.Add(columnName);
                }

                // Đọc dữ liệu từ dòng 2 trở đi
                for (int row = 2; row <= rowCount; row++)
                {
                    DataRow newRow = dt.NewRow();

                    for (int col = 1; col <= colCount; col++)
                    {
                        newRow[col - 1] = worksheet.Cells[row, col].Text?.Trim();
                    }

                    dt.Rows.Add(newRow);
                }
            }

            return dt;
        }
    }
}
