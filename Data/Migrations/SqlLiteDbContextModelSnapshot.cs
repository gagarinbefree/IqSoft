﻿// <auto-generated />
using System;
using Data.SqlLite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(SqlLiteDbContext))]
    partial class SqlLiteDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Data.Dto.Col", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Name");

                    b.Property<string>("RowId");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.HasIndex("RowId");

                    b.ToTable("Cols");
                });

            modelBuilder.Entity("Data.Dto.File", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("Name");

                    b.Property<string>("NameTmp");

                    b.Property<DateTime>("UploadDateTime");

                    b.HasKey("Id");

                    b.ToTable("Files");
                });

            modelBuilder.Entity("Data.Dto.Row", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<int>("Number");

                    b.Property<string>("WorkSheetId");

                    b.HasKey("Id");

                    b.HasIndex("WorkSheetId");

                    b.ToTable("Rows");
                });

            modelBuilder.Entity("Data.Dto.WorkSheet", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("FileId");

                    b.Property<string>("Name");

                    b.Property<int>("Number");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.ToTable("WorSheets");
                });

            modelBuilder.Entity("Data.Dto.Col", b =>
                {
                    b.HasOne("Data.Dto.Row", "Row")
                        .WithMany("Cols")
                        .HasForeignKey("RowId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Dto.Row", b =>
                {
                    b.HasOne("Data.Dto.WorkSheet", "WorkSheet")
                        .WithMany("Rows")
                        .HasForeignKey("WorkSheetId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Dto.WorkSheet", b =>
                {
                    b.HasOne("Data.Dto.File", "File")
                        .WithMany("WorkSheets")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
