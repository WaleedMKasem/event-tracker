using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;

namespace Z2data.Data
{
    public class ExcelReader
    {
        public void ReadFile(FileInfo file)
        {
            var package = new ExcelPackage(file);

            ExcelWorksheet workSheet = package.Workbook.Worksheets[1];

            for (int rowIndex = workSheet.Dimension.Start.Row; rowIndex <= workSheet.Dimension.End.Row; rowIndex++)
            {
                for (int columnIndex = workSheet.Dimension.Start.Column; columnIndex <= workSheet.Dimension.End.Column; columnIndex++)
                {
                    object cellValue = workSheet.Cells[rowIndex, columnIndex].Value;
                }
            }
        }

    }
}
