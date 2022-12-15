﻿// <auto-generated />
using First_MVC_App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace First_MVC_App.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221202143843_fixed-languages")]
    partial class fixedlanguages
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
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"), 1L, 1);

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.HasIndex("CountryId");

                    b.ToTable("CityList");

                    b.HasData(
                        new
                        {
                            CityId = 1,
                            CityName = "Stockholm",
                            CountryId = 1
                        },
                        new
                        {
                            CityId = 2,
                            CityName = "Los Angeles",
                            CountryId = 2
                        });
                });

            modelBuilder.Entity("First_MVC_App.Models.Country", b =>
                {
                    b.Property<int>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CountryId"), 1L, 1);

                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("CountryList");

                    b.HasData(
                        new
                        {
                            CountryId = 1,
                            CountryName = "Sweden"
                        },
                        new
                        {
                            CountryId = 2,
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

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("LanguageId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("PeopleList");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityId = 1,
                            LanguageId = 0,
                            Name = "Oskar F",
                            PhoneNumber = "031 123 345"
                        },
                        new
                        {
                            Id = 2,
                            CityId = 2,
                            LanguageId = 0,
                            Name = "Ronnie Coleman",
                            PhoneNumber = "0976 123 321"
                        });
                });

            modelBuilder.Entity("LanguagePerson", b =>
                {
                    b.Property<int>("LanguageListLanguageId")
                        .HasColumnType("int");

                    b.Property<int>("PeopleListId")
                        .HasColumnType("int");

                    b.HasKey("LanguageListLanguageId", "PeopleListId");

                    b.HasIndex("PeopleListId");

                    b.ToTable("LanguagePerson");

                    b.HasData(
                        new
                        {
                            LanguageListLanguageId = 1,
                            PeopleListId = 1
                        },
                        new
                        {
                            LanguageListLanguageId = 2,
                            PeopleListId = 2
                        },
                        new
                        {
                            LanguageListLanguageId = 3,
                            PeopleListId = 2
                        });
                });

            modelBuilder.Entity("First_MVC_App.Models.City", b =>
                {
                    b.HasOne("First_MVC_App.Models.Country", "Country")
                        .WithMany("CityList")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("First_MVC_App.Models.Person", b =>
                {
                    b.HasOne("First_MVC_App.Models.City", "City")
                        .WithMany("PersonList")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("LanguagePerson", b =>
                {
                    b.HasOne("First_MVC_App.Models.Language", null)
                        .WithMany()
                        .HasForeignKey("LanguageListLanguageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("First_MVC_App.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PeopleListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("First_MVC_App.Models.City", b =>
                {
                    b.Navigation("PersonList");
                });

            modelBuilder.Entity("First_MVC_App.Models.Country", b =>
                {
                    b.Navigation("CityList");
                });
#pragma warning restore 612, 618
        }
    }
}