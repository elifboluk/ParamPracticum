﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Practicum.Repository.Context;

#nullable disable

namespace Practicum.Repository.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230217133813_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Practicum.Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryName = "Technologies",
                            CompanyId = 1,
                            CreatedDate = new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(8017)
                        },
                        new
                        {
                            Id = 2,
                            CategoryName = "Stationery",
                            CompanyId = 2,
                            CreatedDate = new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(8034)
                        });
                });

            modelBuilder.Entity("Practicum.Core.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyName = "Amazon",
                            CreatedDate = new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(8583)
                        },
                        new
                        {
                            Id = 2,
                            CompanyName = "HepsiBurada",
                            CreatedDate = new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(8607)
                        });
                });

            modelBuilder.Entity("Practicum.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CompanyId = 1,
                            CreatedDate = new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(9076),
                            Price = 50m,
                            ProductName = "Mouse",
                            Stock = 10
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            CompanyId = 1,
                            CreatedDate = new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(9087),
                            Price = 10000m,
                            ProductName = "PC",
                            Stock = 5
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 1,
                            CompanyId = 2,
                            CreatedDate = new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(9090),
                            Price = 100m,
                            ProductName = "Keyboard",
                            Stock = 10
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            CompanyId = 2,
                            CreatedDate = new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(9092),
                            Price = 100m,
                            ProductName = "Book",
                            Stock = 10
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            CompanyId = 2,
                            CreatedDate = new DateTime(2023, 2, 17, 16, 38, 13, 564, DateTimeKind.Local).AddTicks(9094),
                            Price = 10m,
                            ProductName = "Pencil",
                            Stock = 20
                        });
                });

            modelBuilder.Entity("Practicum.Core.Entities.Product", b =>
                {
                    b.HasOne("Practicum.Core.Entities.Company", null)
                        .WithMany("Products")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Practicum.Core.Entities.Company", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}