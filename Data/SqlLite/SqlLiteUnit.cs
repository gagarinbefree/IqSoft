using System;
using System.Collections.Generic;
using System.Text;
using Data.Dto;

namespace Data.SqlLite
{
    public class SqlLiteUnit : IUoW, IDisposable
    {
        private bool _disposed = false;

        private SqlLiteDbContext _db;

        public SqlLiteUnit(SqlLiteDbContext db)
        {
            _db = db;
        }

        private IRepository<XlsxFile> _repXlsxFile;
        public IRepository<XlsxFile> RepXlsxFile
        {
            get { return _repXlsxFile ?? (_repXlsxFile = new SqlLiteRepository<XlsxFile>(_db)); }
        }

        private IRepository<XlsxList1> _repXlsxList1;
        public IRepository<XlsxList1> RepXlsxList1
        {
            get { return _repXlsxList1 ?? (_repXlsxList1 = new SqlLiteRepository<XlsxList1>(_db)); }
        }

        private IRepository<XlsxList2> _repXlsxList2;
        public IRepository<XlsxList2> RepXlsxList2
        {
            get { return _repXlsxList2 ?? (_repXlsxList2 = new SqlLiteRepository<XlsxList2>(_db)); }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
