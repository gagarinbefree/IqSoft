using Data;
using OfficeOpenXml;
using OfficeOpenXml.Core.ExcelPackage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace Services.DataProvider
{
    public class DataProvider : IDataProvider
    {
        private readonly IUoW _unit;

        public DataProvider(IUoW unit)
        {
            _unit = unit;
        }

        public void UploadFileToDB(string path)
        {
            FileInfo file = new FileInfo(path);
            ExcelPackage excel = new ExcelPackage(file);
            ExcelWorksheets workSheets = excel.Workbook.Worksheets;

            for(int ii = 0; ii < 2; ii++)
            {
                ExcelWorksheet workSheet = workSheets[ii];

                for (var rowNumber = 2; rowNumber <= 20; rowNumber++)
                {
                    try
                    {
                        var row = workSheet.Cells[rowNumber, 1, rowNumber, workSheet.Dimension.End.Column];
                        var cells = row.Value as object[,];
                        if (cells == null)
                            continue;

                        for (var cellnumber = 0; cellnumber < cells.GetLength(1); cellnumber++)
                        {
                            newRow[cellnumber] = _getCellValue(cellnumber, cells[0, cellnumber]);
                        }

                        res.Rows.Add(newRow);
                    }
                    catch (Exception ex)
                    {
                        MvcApplication.log.Info(ex, String.Format("Не удалось загрузить строку файла №{0}", rowNumber));

                        throw;
                    }
                }
            }

            throw new NotImplementedException();
        }
    }
}
