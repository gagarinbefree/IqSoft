using Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public interface IUoW : IDisposable
    {
        IRepository<File> RepFile { get; }
        IRepository<WorkSheet> RepWorkSheet { get; }
        IRepository<Row> RepRow { get; }
        IRepository<Col> RepCol { get; }

        Task<int> CommitAsync();
    }
}
