﻿// <auto-generated />
using HotelListing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HotelListing.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221007042058_SeedingData")]
    partial class SeedingData
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("HotelListing.Domain.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Nigeria",
                            ShortName = "NG"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ghana",
                            ShortName = "GH"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Benin",
                            ShortName = "BJ"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cameroon",
                            ShortName = "CM"
                        });
                });

            modelBuilder.Entity("HotelListing.Domain.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Lagos",
                            CountryId = 1,
                            Name = "Radisson Bleu Anchorage Hotel"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Accra",
                            CountryId = 2,
                            Name = "Alisa Hotel North Ridge"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Porto-Novo",
                            CountryId = 3,
                            Name = "White Horse Hotel Port0-Novo"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Douala",
                            CountryId = 4,
                            Name = "K Hotel"
                        });
                });

            modelBuilder.Entity("HotelListing.Domain.Models.Hotel", b =>
                {
                    b.HasOne("HotelListing.Domain.Models.Country", "Country")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });
#pragma warning restore 612, 618
        }
    }
}