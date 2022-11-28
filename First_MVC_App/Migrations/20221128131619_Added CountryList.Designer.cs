﻿// <auto-generated />
using System;
using First_MVC_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FirstMVCApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221128131619_Added CountryList")]
    partial class AddedCountryList
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("First_MVC_App.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("CityList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityName = "Stockholm",
                            CountryName = "Sweden"
                        },
                        new
                        {
                            Id = 2,
                            CityName = "Los Angeles",
                            CountryName = "USA"
                        });
                });

            modelBuilder.Entity("First_MVC_App.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Capital")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CountryList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Capital = "Stockholm",
                            CountryName = "Sweden"
                        },
                        new
                        {
                            Id = 2,
                            Capital = "Washington",
                            CountryName = "USA"
                        });
                });

            modelBuilder.Entity("First_MVC_App.Models.Language", b =>
                {
                    b.Property<int>("LanguageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LanguageId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LanguageId");

                    b.ToTable("LanguageList");

                    b.HasData(
                        new
                        {
                            LanguageId = 1,
                            Name = "Swedish"
                        },
                        new
                        {
                            LanguageId = 2,
                            Name = "English"
                        },
                        new
                        {
                            LanguageId = 3,
                            Name = "Polish"
                        },
                        new
                        {
                            LanguageId = 4,
                            Name = "Tagalog"
                        });
                });

            modelBuilder.Entity("First_MVC_App.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("LanguageId");

                    b.ToTable("PeopleList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Göteborg",
                            Name = "Oskar F",
                            PhoneNumber = "031 123 345"
                        },
                        new
                        {
                            Id = 2,
                            City = "Los Angeles",
                            Name = "Ronnie Coleman",
                            PhoneNumber = "0976 123 321"
                        });
                });

            modelBuilder.Entity("First_MVC_App.Models.City", b =>
                {
                    b.HasOne("First_MVC_App.Models.Country", null)
                        .WithMany("Cities")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("First_MVC_App.Models.Person", b =>
                {
                    b.HasOne("First_MVC_App.Models.City", null)
                        .WithMany("Persons")
                        .HasForeignKey("CityId");

                    b.HasOne("First_MVC_App.Models.Language", null)
                        .WithMany("PeopleList")
                        .HasForeignKey("LanguageId");
                });

            modelBuilder.Entity("First_MVC_App.Models.City", b =>
                {
                    b.Navigation("Persons");
                });

            modelBuilder.Entity("First_MVC_App.Models.Country", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("First_MVC_App.Models.Language", b =>
                {
                    b.Navigation("PeopleList");
                });
#pragma warning restore 612, 618
        }
    }
}