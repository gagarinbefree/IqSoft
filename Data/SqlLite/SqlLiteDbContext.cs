using Data.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.SqlLite
{
    public class SqlLiteDbContext : DbContext
    {
        public DbSet<XlsxFile> XlsxFiles { get; set; }
        public DbSet<XlsxList1> Xlsx1 { get; set; }
        public DbSet<XlsxList2> Xlsx2 { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=data.db");
        }
    }
}
