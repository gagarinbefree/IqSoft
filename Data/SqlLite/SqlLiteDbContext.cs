﻿using Data.Dto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.SqlLite
{
    public class SqlLiteDbContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<WorkSheet> WorSheets { get; set; }
        public DbSet<Row> Rows { get; set; }
        public DbSet<Col> Cols { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=data.db");
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=data.db");

            base.OnConfiguring(optionsBuilder);
        }

        public SqlLiteDbContext()
        { }

        public SqlLiteDbContext(DbContextOptions<SqlLiteDbContext> options)
            : base(options)
        { }
    }
}
