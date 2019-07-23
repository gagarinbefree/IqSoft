using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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

        private IRepository<File> _repFile;
        public IRepository<File> RepFile
        {
            get { return _repFile ?? (_repFile = new SqlLiteRepository<File>(_db)); }
        }

        private IRepository<WorkSheet> _repWorkSheet;
        public IRepository<WorkSheet> RepWorkSheet
        {
            get { return _repWorkSheet ?? (_repWorkSheet = new SqlLiteRepository<WorkSheet>(_db)); }
        }

        private IRepository<Row> _repRow;
        public IRepository<Row> RepRow
        {
            get { return _repRow ?? (_repRow = new SqlLiteRepository<Row>(_db)); }
        }

        private IRepository<Col> _repCol;
        public IRepository<Col> RepCol
        {
            get { return _repCol ?? (_repCol = new SqlLiteRepository<Col>(_db)); }
        }

        public async Task<int> CommitAsync()
        {
            return await _db.SaveChangesAsync();
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
