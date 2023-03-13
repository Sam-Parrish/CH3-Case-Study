﻿// <auto-generated />
using System;
using CS_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CS1.Migrations
{
    [DbContext(typeof(SportsProContext))]
    partial class SportsProContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CS_1.Models.Country", b =>
                {
                    b.Property<string>("CountryId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = "USA",
                            Name = "United States of America"
                        },
                        new
                        {
                            CountryId = "CDA",
                            Name = "Canada"
                        },
                        new
                        {
                            CountryId = "UNK",
                            Name = "United Kingdom"
                        },
                        new
                        {
                            CountryId = "JPN",
                            Name = "Japan"
                        },
                        new
                        {
                            CountryId = "AUS",
                            Name = "Australia"
                        },
                        new
                        {
                            CountryId = "RSA",
                            Name = "Russia"
                        },
                        new
                        {
                            CountryId = "CHA",
                            Name = "China"
                        });
                });

            modelBuilder.Entity("CS_1.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.HasIndex("CountryId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            CustomerId = 1,
                            Address = "120 Buddy Boulevard",
                            City = "San Francisco",
                            CountryId = "CDA",
                            Email = "kanthoni@pge.com",
                            FirstName = "Kaitlyn",
                            LastName = "Anthoni",
                            Phone = "8005550489",
                            PostalCode = 9993,
                            State = "California"
                        });
                });

            modelBuilder.Entity("CS_1.Models.Incident", b =>
                {
                    b.Property<int>("IncidentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IncidentId"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateClosed")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOpened")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("TechnicianId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IncidentId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ProductId");

                    b.HasIndex("TechnicianId");

                    b.ToTable("Incidents");

                    b.HasData(
                        new
                        {
                            IncidentId = 1,
                            CustomerId = 1,
                            DateClosed = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOpened = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The app won't open properly",
                            ProductId = 1,
                            TechnicianId = 1,
                            Title = "Cant run"
                        },
                        new
                        {
                            IncidentId = 2,
                            CustomerId = 1,
                            DateClosed = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOpened = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The app won't open properly",
                            ProductId = 1,
                            TechnicianId = 1,
                            Title = "Cant run"
                        },
                        new
                        {
                            IncidentId = 3,
                            CustomerId = 1,
                            DateClosed = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateOpened = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "The app won't open properly",
                            ProductId = 1,
                            TechnicianId = 1,
                            Title = "Cant run"
                        });
                });

            modelBuilder.Entity("CS_1.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProductId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ProductCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Name = "Tournament Master 1.0",
                            Price = 4.99m,
                            ProductCode = "TRN10",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            ProductId = 2,
                            Name = "League Scheduler 1.0",
                            Price = 4.99m,
                            ProductCode = "LEAG10",
                            ReleaseDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("CS_1.Models.Technician", b =>
                {
                    b.Property<int>("TechnicianId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TechnicianId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TechnicianId");

                    b.ToTable("Technicians");

                    b.HasData(
                        new
                        {
                            TechnicianId = 1,
                            Email = "alison@sportsprosoftware.com",
                            Name = "Alison Diaz",
                            PhoneNumber = "8005550443"
                        });
                });

            modelBuilder.Entity("CS_1.Models.Customer", b =>
                {
                    b.HasOne("CS_1.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("CS_1.Models.Incident", b =>
                {
                    b.HasOne("CS_1.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CS_1.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CS_1.Models.Technician", "Technician")
                        .WithMany()
                        .HasForeignKey("TechnicianId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Product");

                    b.Navigation("Technician");
                });
#pragma warning restore 612, 618
        }
    }
}
