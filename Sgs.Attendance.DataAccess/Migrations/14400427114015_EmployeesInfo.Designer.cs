﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sgs.Attendance.DataAccess;

namespace Sgs.Attendance.DataAccess.Migrations
{
    [DbContext(typeof(AttendanceDb))]
    [Migration("14400427114015_EmployeesInfo")]
    partial class EmployeesInfo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Sgs.Attendance.Model.DepartmentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<bool>("ManagerExempted");

                    b.HasKey("Id");

                    b.ToTable("DepartmentsInfo");
                });

            modelBuilder.Entity("Sgs.Attendance.Model.EmployeeInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<bool>("Exempted");

                    b.Property<DateTime>("ExemptedDate");

                    b.Property<string>("ExemptedResone");

                    b.Property<string>("Note");

                    b.HasKey("Id");

                    b.ToTable("EmployeesInfo");
                });

            modelBuilder.Entity("Sgs.Attendance.Model.EmployeeWorkShiftsSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<string>("Note");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("WorkShiftsSystemId");

                    b.HasKey("Id");

                    b.HasIndex("WorkShiftsSystemId");

                    b.ToTable("EmployeesWorkShiftsSystems");
                });

            modelBuilder.Entity("Sgs.Attendance.Model.WorkShiftsSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Note");

                    b.HasKey("Id");

                    b.ToTable("WorkShiftsSystems");
                });

            modelBuilder.Entity("Sgs.Attendance.Model.EmployeeWorkShiftsSystem", b =>
                {
                    b.HasOne("Sgs.Attendance.Model.WorkShiftsSystem", "WorkShiftsSystem")
                        .WithMany()
                        .HasForeignKey("WorkShiftsSystemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
