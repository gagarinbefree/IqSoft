using Data;
using Mapster;
using OfficeOpenXml;
using Services.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Linq;

namespace Services.DataProvider
{
    public class DataProvider : IDataProvider
    {
        private readonly IUoW _unit;

        public DataProvider(IUoW unit)
        {
            _unit = unit;
        }

        public async Task<int> DeleteRecordByIdAsync(string id)
        {
            var item = await _unit.RepRow.GetAsync(f => f.Id == id);
            if (item == null)
                return 0;

            _unit.RepRow.Delete(item);

            return await _unit.CommitAsync();
        }       

        public async Task<List<DomainRow>> GetRecordsByUploadDateAsync(DateTime uploadDateTime)
        {
            var rows = await _unit.RepRow.GetAllAsync(f => f.WorkSheet.File.UploadDateTime.Date == uploadDateTime.Date, f => f.WorkSheet, f => f.Cols);
            if (rows.Any())
            {
                var file = await _unit.RepFile.GetAsync(f => f.Id == rows[0].WorkSheet.FileId);
                foreach (var row in rows)
                {
                    row.WorkSheet.File = file;
                }
            }

            return rows.Adapt<DomainRow[]>().ToList();
        }

        public async Task<int> UpdateRecordByIdAsync(string id, string name, string value)
        {
            Data.Dto.Row row = await _unit.RepRow.GetAsync(f => f.Id == id);
            if (row == null)
                return 0;

            Data.Dto.Col col = await _unit.RepCol.GetAsync(f => f.Row.Id == row.Id && f.Name.ToUpper() == name.ToUpper());
            if (col == null)
                return 0;

            col.Value = value;
            _unit.RepCol.Update(col);

            return await _unit.CommitAsync();
        }

        public async Task<int> UploadFileAsync(string fileName, string pathTmp)
        {
            try
            {
                FileInfo file = new FileInfo(pathTmp);
                ExcelPackage excel = new ExcelPackage(file);
                ExcelWorksheets workSheets = excel.Workbook.Worksheets;

                var fileId = Guid.NewGuid().ToString();                
                _unit.RepFile.Create(new Data.Dto.File
                {
                    Id = fileId,
                    UploadDateTime = DateTime.UtcNow,
                    Name = fileName,
                    NameTmp = pathTmp
                });

                foreach(ExcelWorksheet workSheet in workSheets)
                {                 
                    var workSheetId = Guid.NewGuid().ToString();
                    _unit.RepWorkSheet.Create(new Data.Dto.WorkSheet
                    {
                        Id = workSheetId,
                        FileId = fileId,
                        Number = workSheet.Index,
                        Name = workSheet.Name
                    });

                    for (var rowNumber = 1; rowNumber <= workSheet.Dimension.End.Row; rowNumber++)
                    {
                        var rowId = Guid.NewGuid().ToString();                            
                        _unit.RepRow.Create(new Data.Dto.Row
                        {
                            Id = rowId,
                            WorkSheetId = workSheetId,
                            Number = rowNumber,
                        });

                        for (int cellNumber = 1; cellNumber <= workSheet.Dimension.End.Column; cellNumber++)
                        {
                            string cellValue = workSheet.Cells[rowNumber, cellNumber].Value.ToString();

                            _unit.RepCol.Create(new Data.Dto.Col
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
