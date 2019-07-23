using System;
using System.Threading.Tasks;

namespace Services.DataProvider
{
    public interface IDataProvider
    {
        Task<int> UploadFileAsync(string fileName, string pathTmp);
    }
}
