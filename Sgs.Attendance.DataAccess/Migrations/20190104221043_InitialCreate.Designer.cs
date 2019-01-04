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
    [Migration("20190104221043_InitialCreate")]
    partial class InitialCreate
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

            modelBuilder.Entity("Sgs.Attendance.Model.DeviceInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(8);

                    b.Property<string>("IpAddress")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("LocationArabic")
                        .IsRequired();

                    b.Property<string>("LocationEnglish")
                        .IsRequired();

                    b.Property<string>("Model")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("Note");

                    b.Property<string>("RefrenceNumber")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("DevicesInfo");
                });

            modelBuilder.Entity("Sgs.Attendance.Model.EmployeeInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeId");

                    b.Property<bool>("Exempted");

                    b.Property<DateTime?>("ExemptedDate");

                    b.Property<string>("ExemptedResone")
                        .HasMaxLength(100);

                    b.Property<string>("Note");

                    b.HasKey("Id");

                    b.ToTable("EmployeesInfo");
                });

            modelBuilder.Entity("Sgs.Attendance.Model.EmployeeWorkShiftsCalendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeInfoId");

                    b.Property<string>("Note");

                    b.Property<int>("WorkShiftsCalendarId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeInfoId");

                    b.HasIndex("WorkShiftsCalendarId");

                    b.ToTable("EmployeesWorkShiftsCalendars");
                });

            modelBuilder.Entity("Sgs.Attendance.Model.EmployeeWorkShiftsSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EmployeeInfoId");

                    b.Property<DateTime?>("EndDate");

                    b.Property<string>("Note");

                    b.Property<DateTime>("StartDate");

                    b.Property<int>("WorkShiftsSystemId");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeInfoId");

                    b.HasIndex("WorkShiftsSystemId");

                    b.ToTable("EmployeesWorkShiftsSystems");
                });

            modelBuilder.Entity("Sgs.Attendance.Model.WorkShiftsCalendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttendanceProof");

                    b.Property<DateTime>("EndDate");

                    b.Property<bool>("IsVacationCalendar");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Note");

                    b.Property<DateTime>("StartDate");

                    b.Property<string>("VacationDescription");

                    b.HasKey("Id");

                    b.ToTable("WorkShiftsCalendars");
                });

            modelBuilder.Entity("Sgs.Attendance.Model.WorkShiftsCalendarCycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CycleOrder");

                    b.Property<string>("DayOffDescription");

                    b.Property<string>("DayOffDescriptionInRamadan");

                    b.Property<bool>("IsDayOff");

                    b.Property<bool?>("IsDayOffInRamadan");

                    b.Property<string>("Note");

                    b.Property<int>("RepeatCount");

                    b.Property<double?>("ShiftEnd");

                    b.Property<double?>("ShiftEndInRamadan");

                    b.Property<double?>("ShiftStart");

                    b.Property<double?>("ShiftStartInRamadan");

                    b.Property<int>("WorkShiftsCalendarId");

                    b.HasKey("Id");

                    b.HasIndex("WorkShiftsCalendarId");

                    b.ToTable("WorkShiftsCalendarsCycles");
                });

            modelBuilder.Entity("Sgs.Attendance.Model.WorkShiftsSystem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AttendanceProof");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(4);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Note");

                    b.Property<DateTime>("StartDate");

                    b.HasKey("Id");

                    b.ToTable("WorkShiftsSystems");
                });

            modelBuilder.Entity("Sgs.Attendance.Model.WorkShiftsSystemCalendar", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Note");

                    b.Property<int>("WorkShiftsCalendarId");

                    b.Property<int>("WorkShiftsSystemId");

                    b.HasKey("Id");

                    b.HasIndex("WorkShiftsCalendarId");

                    b.HasIndex("WorkShiftsSystemId");

                    b.ToTable("WorkShiftsSystemsCalendars");
                });

            modelBuilder.Entity("Sgs.Attendance.Model.WorkShiftsSystemCycle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CycleOrder");

                    b.Property<string>("DayOffDescription");

                    b.Property<string>("DayOffDescriptionInRamadan");

                    b.Property<bool>("IsDayOff");

                    b.Property<bool?>("IsDayOffInRamadan");

                    b.Property<string>("Note");

                    b.Property<int>("RepeatCount");

                    b.Property<double?>("ShiftEnd");

                    b.Property<double?>("ShiftEndInRamadan");

                    b.Property<double?>("ShiftStart");

                    b.Property<double?>("ShiftStartInRamadan");

                    b.Property<int>("WorkShiftsSystemId");

                    b.HasKey("Id");

                    b.HasIndex("WorkShiftsSystemId");

                    b.ToTable("WorkShiftsSystemsCycles");
                });

            modelBuilder.Entity("Sgs.Attendance.Model.EmployeeWorkShiftsCalendar", b =>
                {
                    b.HasOne("Sgs.Attendance.Model.EmployeeInfo", "EmployeeInfo")
                        .WithMany()
                        .HasForeignKey("EmployeeInfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sgs.Attendance.Model.WorkShiftsCalendar", "WorkShiftsCalendar")
                        .WithMany("EmployeesCalendars")
                        .HasForeignKey("WorkShiftsCalendarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sgs.Attendance.Model.EmployeeWorkShiftsSystem", b =>
                {
                    b.HasOne("Sgs.Attendance.Model.EmployeeInfo", "EmployeeInfo")
                        .WithMany()
                        .HasForeignKey("EmployeeInfoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sgs.Attendance.Model.WorkShiftsSystem", "WorkShiftsSystem")
                        .WithMany("EmployeesInfo")
                        .HasForeignKey("WorkShiftsSystemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sgs.Attendance.Model.WorkShiftsCalendarCycle", b =>
                {
                    b.HasOne("Sgs.Attendance.Model.WorkShiftsCalendar", "WorkShiftsCalendar")
                        .WithMany("WorkShiftsCycles")
                        .HasForeignKey("WorkShiftsCalendarId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sgs.Attendance.Model.WorkShiftsSystemCalendar", b =>
                {
                    b.HasOne("Sgs.Attendance.Model.WorkShiftsCalendar", "WorkShiftsCalendar")
                        .WithMany("WorkShiftsSystems")
                        .HasForeignKey("WorkShiftsCalendarId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Sgs.Attendance.Model.WorkShiftsSystem", "WorkShiftsSystem")
                        .WithMany("WorkShiftsCalendars")
                        .HasForeignKey("WorkShiftsSystemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Sgs.Attendance.Model.WorkShiftsSystemCycle", b =>
                {
                    b.HasOne("Sgs.Attendance.Model.WorkShiftsSystem", "WorkShiftsSystem")
                        .WithMany("WorkShiftsSystemCycles")
                        .HasForeignKey("WorkShiftsSystemId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
