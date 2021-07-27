﻿// <auto-generated />
using System;
using EFDataAccessLib.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFDataAccessLib.Migrations
{
    [DbContext(typeof(PeopleContext))]
    [Migration("20210722094756_InitialDBCreation")]
    partial class InitialDBCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFDataAccessLib.Models.Address", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonID")
                        .HasColumnType("int");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("EFDataAccessLib.Models.Email", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PersonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("PersonID");

                    b.ToTable("EmailAddresses");
                });

            modelBuilder.Entity("EFDataAccessLib.Models.Person", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("EFDataAccessLib.Models.Address", b =>
                {
                    b.HasOne("EFDataAccessLib.Models.Person", null)
                        .WithMany("Addresses")
                        .HasForeignKey("PersonID");
                });

            modelBuilder.Entity("EFDataAccessLib.Models.Email", b =>
                {
                    b.HasOne("EFDataAccessLib.Models.Person", null)
                        .WithMany("EmailsAddresses")
                        .HasForeignKey("PersonID");
                });

            modelBuilder.Entity("EFDataAccessLib.Models.Person", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("EmailsAddresses");
                });
#pragma warning restore 612, 618
        }
    }
}