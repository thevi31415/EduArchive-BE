﻿// <auto-generated />
using System;
using EduArchive_BE.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EduArchive_BE.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240617080128_Follow")]
    partial class Follow
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EduArchive_BE.Model.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("IdAuthor")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdChool")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSubject")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Like")
                        .HasColumnType("int");

                    b.Property<string>("LinkDownload")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkView")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameAuthor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSchool")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSubject")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeDocument")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("View")
                        .HasColumnType("int");

                    b.Property<string>("YearSchool")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userAuthor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("documents");
                });

            modelBuilder.Entity("EduArchive_BE.Model.FollowSubject", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<int>("Staus")
                        .HasColumnType("int");

                    b.Property<Guid>("idSubject")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("idUser")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("id");

                    b.ToTable("followSubjects");
                });

            modelBuilder.Entity("EduArchive_BE.Model.Subject", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Avartar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BackGround")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Document")
                        .HasColumnType("int");

                    b.Property<int?>("Like")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("View")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("subjects");
                });

            modelBuilder.Entity("EduArchive_BE.Model.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Armorial")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Avartar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdGoogle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Introduction")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastVisit")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Staus")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
