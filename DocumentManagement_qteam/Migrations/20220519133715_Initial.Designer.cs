﻿// <auto-generated />
using System;
using DocumentManegemant.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DocumentManagement.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220519133715_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DocumentManagement.Models.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("DocumentManagement.Models.DocumentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int")
                        .HasColumnName("Category");

                    b.Property<int?>("Code")
                        .IsRequired()
                        .HasColumnType("int")
                        .HasColumnName("Code");

                    b.Property<string>("FileUrl")
                        .HasColumnType("longtext")
                        .HasColumnName("File Url");

                    b.Property<int>("ProcessId")
                        .HasColumnType("int")
                        .HasColumnName("ProcessId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.HasIndex("ProcessId");

                    b.ToTable("Document");
                });

            modelBuilder.Entity("DocumentManagement.Models.Process", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Process");
                });

            modelBuilder.Entity("DocumentManagement.Models.DocumentModel", b =>
                {
                    b.HasOne("DocumentManagement.Models.Process", "Process")
                        .WithMany()
                        .HasForeignKey("ProcessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Process");
                });

            modelBuilder.Entity("DocumentManagement.Models.Process", b =>
                {
                    b.HasOne("DocumentManagement.Models.CategoryModel", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });
#pragma warning restore 612, 618
        }
    }
}
