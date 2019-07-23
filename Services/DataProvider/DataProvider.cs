using Data;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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

        public async Task<int> UploadFileAsync(string fileName, string pathTmp)
        {
            try
            {
                FileInfo file = new FileInfo(pathTmp);
                ExcelPackage excel = new ExcelPackage(file);
                ExcelWorksheets workSheets = excel.Workbook.Worksheets;

                var fileId = Guid.NewGuid().ToString();
                
                _unit.RepFile.CreateItem(new Data.Dto.File
                {
                    Id = fileId,
                    UploadDateTime = DateTime.UtcNow,
                    Name = fileName,
                    NameTmp = pathTmp
                });

                foreach(ExcelWorksheet workSheet in workSheets)
                {                 
                    var workSheetId = Guid.NewGuid().ToString();
                    _unit.RepWorkSheet.CreateItem(new Data.Dto.WorkSheet
                    {
                        Id = workSheetId,
                        FileId = fileId,
                        Number = workSheet.Index,
                        Name = workSheet.Name
                    });

                    for (var rowNumber = 1; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                    {
                        var rowId = Guid.NewGuid().ToString();
                            
                        _unit.RepRow.CreateItem(new Data.Dto.Row
                        {
                            Id = rowId,
                            WorkSheetId = workSheetId,
                            Number = rowNumber,
                        });

                        var row = workSheet.Cells[rowNumber, 1, rowNumber, 20];
                        for (int cellNumber = 1; cellNumber <= workSheet.Dimension.End.Column; cellNumber++)
                        {
                            string cellValue = workSheet.Cells[rowNumber, cellNumber].Value.ToString();

                            _unit.RepCol.CreateItem(new Data.Dto.Col
                            {
                                Id = Guid.NewGuid().ToString(),
                                RowId = rowId,
                                Name = $"col{cellNumber}",
                                Value = cellValue
                            });
                        }
                    }
                }

                return await _unit.CommitAsync();
            }
            catch(Exception ex)
            {
                throw new Exception("Не удалось сохранить файл В БД", ex);
            }
        }
    }
}
