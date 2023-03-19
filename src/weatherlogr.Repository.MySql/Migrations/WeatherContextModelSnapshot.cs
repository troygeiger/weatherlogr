﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using weatherlogr.Repository.MySql;

#nullable disable

namespace weatherlogr.Repository.MySql.Migrations
{
    [DbContext(typeof(WeatherContext))]
    partial class WeatherContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("weatherlogr.Repository.MySql.Models.ObjectProperty", b =>
                {
                    b.Property<string>("ClassName")
                        .HasMaxLength(512)
                        .HasColumnType("varchar(512)");

                    b.Property<string>("EntryName")
                        .HasMaxLength(60)
                        .HasColumnType("varchar(60)");

                    b.Property<bool?>("BoolValue")
                        .HasColumnType("tinyint(1)");

                    b.Property<decimal?>("DecimalValue")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int?>("IntValue")
                        .HasColumnType("int");

                    b.Property<long?>("LongValue")
                        .HasColumnType("bigint");

                    b.Property<string>("StringValue")
                        .HasColumnType("longtext");

                    b.HasKey("ClassName", "EntryName");

                    b.ToTable("ObjectProperties");
                });

            modelBuilder.Entity("weatherlogr.Repository.MySql.Models.StationCollector", b =>
                {
                    b.Property<string>("StationIdentifier")
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<DateTimeOffset?>("LastCollectionEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("StationName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("varchar(250)");

                    b.HasKey("StationIdentifier");

                    b.ToTable("StationCollectors");
                });

            modelBuilder.Entity("weatherlogr.Repository.MySql.Observation", b =>
                {
                    b.Property<long>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<decimal?>("BarometricPressure")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("BarometricPressureUOM")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<decimal?>("DewPoint")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("DewPointUOM")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<DateTimeOffset>("EntryDate")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal?>("HeatIndex")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("HeatIndexUOM")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<decimal?>("Humidity")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("HumidityUOM")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<string>("ObsDescription")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("StationID")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<decimal?>("Temperature")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("TemperatureUOM")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<decimal?>("Visibility")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("VisibilityUOM")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<decimal?>("WindChill")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("WindChillUOM")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<decimal?>("WindGust")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("WindGustUOM")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<decimal?>("WindSpeed")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("WindSpeedUOM")
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.HasKey("ID");

                    b.HasIndex("StationID");

                    b.ToTable("Observations");
                });

            modelBuilder.Entity("weatherlogr.Repository.MySql.RadarIndex", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTimeOffset>("RadarDate")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("ID");

                    b.ToTable("RadarIndices");
                });

            modelBuilder.Entity("weatherlogr.Repository.MySql.Observation", b =>
                {
                    b.HasOne("weatherlogr.Repository.MySql.Models.StationCollector", "Station")
                        .WithMany()
                        .HasForeignKey("StationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Station");
                });
#pragma warning restore 612, 618
        }
    }
}
