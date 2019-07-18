using Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public interface IUoW : IDisposable
    {
        IRepository<XlsxFile> RepXlsxFile { get; }
        IRepository<XlsxList1> RepXlsxList1 { get; }
        IRepository<XlsxList2> RepXlsxList2 { get; }
    }
}
