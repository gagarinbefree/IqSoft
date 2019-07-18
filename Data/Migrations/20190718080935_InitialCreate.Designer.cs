﻿// <auto-generated />
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(SqlLiteDbContext))]
    [Migration("20190718080935_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("Data.Dto.Xlsx1", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Col1");

                    b.Property<string>("Col10");

                    b.Property<string>("Col11");

                    b.Property<string>("Col12");

                    b.Property<string>("Col120");

                    b.Property<string>("Col13");

                    b.Property<string>("Col14");

                    b.Property<string>("Col15");

                    b.Property<string>("Col16");

                    b.Property<string>("Col17");

                    b.Property<string>("Col18");

                    b.Property<string>("Col19");

                    b.Property<string>("Col2");

                    b.Property<string>("Col3");

                    b.Property<string>("Col4");

                    b.Property<string>("Col5");

                    b.Property<string>("Col6");

                    b.Property<string>("Col7");

                    b.Property<string>("Col8");

                    b.Property<string>("Col9");

                    b.Property<int>("FileId");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.ToTable("Xlsx1");
                });

            modelBuilder.Entity("Data.Dto.Xlsx2", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Col1");

                    b.Property<string>("Col10");

                    b.Property<string>("Col11");

                    b.Property<string>("Col12");

                    b.Property<string>("Col120");

                    b.Property<string>("Col13");

                    b.Property<string>("Col14");

                    b.Property<string>("Col15");

                    b.Property<string>("Col16");

                    b.Property<string>("Col17");

                    b.Property<string>("Col18");

                    b.Property<string>("Col19");

                    b.Property<string>("Col2");

                    b.Property<string>("Col3");

                    b.Property<string>("Col4");

                    b.Property<string>("Col5");

                    b.Property<string>("Col6");

                    b.Property<string>("Col7");

                    b.Property<string>("Col8");

                    b.Property<string>("Col9");

                    b.Property<int>("FileId");

                    b.HasKey("Id");

                    b.HasIndex("FileId");

                    b.ToTable("Xlsx2");
                });

            modelBuilder.Entity("Data.Dto.XlsxFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("XlsxFiles");
                });

            modelBuilder.Entity("Data.Dto.Xlsx1", b =>
                {
                    b.HasOne("Data.Dto.XlsxFile", "File")
                        .WithMany("Xlsx1")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Data.Dto.Xlsx2", b =>
                {
                    b.HasOne("Data.Dto.XlsxFile", "File")
                        .WithMany("Xlsx2")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}