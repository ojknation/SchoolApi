﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyApi.Data;

namespace StudyApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200226232536_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StudyApi.Models.Course", b =>
                {
                    b.Property<int>("CourseID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<int>("Level")
                        .HasColumnType("int");

                    b.Property<int>("Semester")
                        .HasColumnType("int");

                    b.HasKey("CourseID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("StudyApi.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DepartmentName")
                        .HasColumnType("int");

                    b.Property<int>("SchoolID")
                        .HasColumnType("int");

                    b.HasKey("DepartmentID");

                    b.HasIndex("SchoolID");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("StudyApi.Models.School", b =>
                {
                    b.Property<int>("SchoolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SchoolName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SchoolID");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("StudyApi.Models.Course", b =>
                {
                    b.HasOne("StudyApi.Models.Department", null)
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID");
                });

            modelBuilder.Entity("StudyApi.Models.Department", b =>
                {
                    b.HasOne("StudyApi.Models.School", null)
                        .WithMany("Departments")
                        .HasForeignKey("SchoolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
