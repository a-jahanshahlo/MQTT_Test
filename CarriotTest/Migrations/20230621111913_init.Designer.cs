﻿// <auto-generated />
using System;
using CarriotTest.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarriotTest.Migrations
{
    [DbContext(typeof(CarriotDbContext))]
    [Migration("20230621111913_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CarriotTest.Db.Entities.HasWarning", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<string>("DeviceID")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DeviceID");

                    b.Property<DateTime>("WarningTime")
                        .HasColumnType("datetime")
                        .HasColumnName("WarningTime");

                    b.Property<int>("WarningType")
                        .HasColumnType("int")
                        .HasColumnName("WarningType");

                    b.HasKey("Id");

                    b.ToTable("HasWarning", (string)null);
                });

            modelBuilder.Entity("CarriotTest.Db.Entities.TempLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id");

                    b.Property<decimal>("AccelerationX1")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("AccelerationX1");

                    b.Property<decimal>("AccelerationY1")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("AccelerationY1");

                    b.Property<decimal>("Altitude")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("Altitude");

                    b.Property<decimal>("Course")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("Course");

                    b.Property<string>("DeviceID")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("DeviceID");

                    b.Property<DateTime>("DeviceTime")
                        .HasColumnType("datetime")
                        .HasColumnName("DeviceTime");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("Latitude");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("Longitude");

                    b.Property<int>("PowerSupply")
                        .HasColumnType("int")
                        .HasColumnName("PowerSupply");

                    b.Property<int>("Satellites")
                        .HasColumnType("int")
                        .HasColumnName("Satellites");

                    b.Property<int>("Signal")
                        .HasColumnType("int")
                        .HasColumnName("Signal");

                    b.Property<decimal>("SpeedOTG")
                        .HasColumnType("decimal(18, 0)")
                        .HasColumnName("SpeedOTG");

                    b.HasKey("Id");

                    b.ToTable("TempLog", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}