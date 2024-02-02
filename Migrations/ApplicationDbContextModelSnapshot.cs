﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelDeskAPI.DataContext;

#nullable disable

namespace TravelDeskAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TravelDeskAPI.Models.Department", b =>
                {
                    b.Property<int>("DeptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DeptId"));

                    b.Property<int>("CreateBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("DeptId");

                    b.ToTable("Department");

                    b.HasData(
                        new
                        {
                            DeptId = 1,
                            CreateBy = 0,
                            CreatedOn = new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7942),
                            DepartmentName = "HR",
                            IsActive = false
                        },
                        new
                        {
                            DeptId = 2,
                            CreateBy = 0,
                            CreatedOn = new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7944),
                            DepartmentName = "Admin",
                            IsActive = false
                        },
                        new
                        {
                            DeptId = 3,
                            CreateBy = 0,
                            CreatedOn = new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7944),
                            DepartmentName = "IT",
                            IsActive = false
                        },
                        new
                        {
                            DeptId = 4,
                            CreateBy = 0,
                            CreatedOn = new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7945),
                            DepartmentName = "Sales",
                            IsActive = false
                        });
                });

            modelBuilder.Entity("TravelDeskAPI.Models.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<int>("CreateBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("RoleId");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            CreateBy = 0,
                            CreatedOn = new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7820),
                            IsActive = false,
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 2,
                            CreateBy = 0,
                            CreatedOn = new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7831),
                            IsActive = false,
                            RoleName = "HRAdmin"
                        },
                        new
                        {
                            RoleId = 3,
                            CreateBy = 0,
                            CreatedOn = new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7832),
                            IsActive = false,
                            RoleName = "Employee"
                        },
                        new
                        {
                            RoleId = 4,
                            CreateBy = 0,
                            CreatedOn = new DateTime(2024, 2, 2, 11, 55, 30, 971, DateTimeKind.Local).AddTicks(7833),
                            IsActive = false,
                            RoleName = "Manager"
                        });
                });

            modelBuilder.Entity("TravelDeskAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CreateBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ManagerId")
                        .HasColumnType("int");

                    b.Property<string>("MobileNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdateBy")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("ManagerId");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("TravelDeskAPI.Models.User", b =>
                {
                    b.HasOne("TravelDeskAPI.Models.Department", "Department")
                        .WithMany("Users")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("TravelDeskAPI.Models.User", "user")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.HasOne("TravelDeskAPI.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Role");

                    b.Navigation("user");
                });

            modelBuilder.Entity("TravelDeskAPI.Models.Department", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("TravelDeskAPI.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
