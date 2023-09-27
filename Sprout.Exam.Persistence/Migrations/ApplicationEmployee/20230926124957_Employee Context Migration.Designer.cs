﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sprout.Exam.Persistence.Data;

#nullable disable

namespace Sprout.Exam.Persistence.Migrations.ApplicationEmployee
{
    [DbContext(typeof(ApplicationEmployeeContext))]
    [Migration("20230926124957_Employee Context Migration")]
    partial class EmployeeContextMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sprout.Exam.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeTypeId")
                        .HasColumnType("int");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("TIN")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeTypeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("Sprout.Exam.Domain.Entities.SEmployeeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeeType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SEmployeeType");
                });

            modelBuilder.Entity("Sprout.Exam.Domain.Entities.Employee", b =>
                {
                    b.HasOne("Sprout.Exam.Domain.Entities.SEmployeeType", "EmployeeType")
                        .WithMany()
                        .HasForeignKey("EmployeeTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EmployeeType");
                });
#pragma warning restore 612, 618
        }
    }
}
