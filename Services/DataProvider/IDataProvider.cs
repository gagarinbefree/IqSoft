using System;

namespace Services
{
    public interface IDataProvider
    {
        void UploadFileToDB(string path);
    }
}
