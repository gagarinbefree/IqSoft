using Services.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.DataProvider
{
    public interface IDataProvider
    {
        Task<int> UploadFileAsync(string fileName, string pathTmp);
        Task<List<DomainRow>> GetRecordsByUploadDateAsync(DateTime uploadDateTime);
        Task<int> DeleteRecordByIdAsync(string id);
        Task<int> UpdateRecordByIdAsync(string id, string name, string value);
    }
}
