﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskDistribution.Data.Modals;

#nullable disable

namespace TaskDistribution.Migrations
{
    [DbContext(typeof(TaskDistributionContext))]
    [Migration("20221220185005_conf")]
    partial class conf
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskDistribution.Data.Modals.Task", b =>
                {
                    b.Property<int>("TaskID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskID"));

                    b.Property<bool>("IsDeleted_FL")
                        .HasColumnType("bit");

                    b.Property<int?>("TaskDifficultTypeID")
                        .HasColumnType("int");

                    b.Property<int?>("TaskTypeID")
                        .HasColumnType("int");

                    b.Property<string>("Task_DSC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Task_NM")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("TaskID");

                    b.HasIndex("TaskDifficultTypeID");

                    b.HasIndex("TaskTypeID");

                    b.HasIndex("UserID");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("TaskDistribution.Data.Modals.TaskDifficultType", b =>
                {
                    b.Property<int>("TaskDifficultTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskDifficultTypeID"));

                    b.Property<bool>("IsDeleted_FL")
                        .HasColumnType("bit");

                    b.Property<string>("TaskDifficultType_NM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskDifficultType_NO")
                        .HasColumnType("int");

                    b.HasKey("TaskDifficultTypeID");

                    b.ToTable("TaskDifficultTypes");

                    b.HasData(
                        new
                        {
                            TaskDifficultTypeID = 1,
                            IsDeletedFL = false,
                            TaskDifficultTypeNM = "Kolay",
                            TaskDifficultTypeNO = 1
                        },
                        new
                        {
                            TaskDifficultTypeID = 2,
                            IsDeletedFL = false,
                            TaskDifficultTypeNM = "Orta",
                            TaskDifficultTypeNO = 2
                        },
                        new
                        {
                            TaskDifficultTypeID = 3,
                            IsDeletedFL = false,
                            TaskDifficultTypeNM = "Zor",
                            TaskDifficultTypeNO = 3
                        });
                });

            modelBuilder.Entity("TaskDistribution.Data.Modals.TaskType", b =>
                {
                    b.Property<int>("TaskTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TaskTypeID"));

                    b.Property<bool>("IsDeleted_FL")
                        .HasColumnType("bit");

                    b.Property<string>("TaskType_NM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TaskType_NO")
                        .HasColumnType("int");

                    b.HasKey("TaskTypeID");

                    b.ToTable("TaskTypes");

                    b.HasData(
                        new
                        {
                            TaskTypeID = 1,
                            IsDeletedFL = false,
                            TaskTypeNM = "BugFix",
                            TaskTypeNO = 1
                        },
                        new
                        {
                            TaskTypeID = 2,
                            IsDeletedFL = false,
                            TaskTypeNM = "Test",
                            TaskTypeNO = 2
                        },
                        new
                        {
                            TaskTypeID = 3,
                            IsDeletedFL = false,
                            TaskTypeNM = "Geliştirme",
                            TaskTypeNO = 3
                        },
                        new
                        {
                            TaskTypeID = 4,
                            IsDeletedFL = false,
                            TaskTypeNM = "Veritabanı İşlemleri",
                            TaskTypeNO = 4
                        },
                        new
                        {
                            TaskTypeID = 5,
                            IsDeletedFL = false,
                            TaskTypeNM = "Frontend Geliştirme",
                            TaskTypeNO = 5
                        },
                        new
                        {
                            TaskTypeID = 6,
                            IsDeletedFL = false,
                            TaskTypeNM = "Refactor",
                            TaskTypeNO = 6
                        },
                        new
                        {
                            TaskTypeID = 7,
                            IsDeletedFL = false,
                            TaskTypeNM = "Güvenlik taraması",
                            TaskTypeNO = 7
                        },
                        new
                        {
                            TaskTypeID = 8,
                            IsDeletedFL = false,
                            TaskTypeNM = "Analiz",
                            TaskTypeNO = 8
                        });
                });

            modelBuilder.Entity("TaskDistribution.Data.Modals.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<bool>("IsDeleted_FL")
                        .HasColumnType("bit");

                    b.Property<string>("Password_TXT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserRoleID")
                        .HasColumnType("int");

                    b.Property<string>("User_NM")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("UserRoleID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            IsDeletedFL = false,
                            PasswordTXT = "1234",
                            UserRoleID = 1,
                            UserNM = "Cansu"
                        },
                        new
                        {
                            UserId = 2,
                            IsDeletedFL = false,
                            PasswordTXT = "1234",
                            UserRoleID = 2,
                            UserNM = "Merve"
                        },
                        new
                        {
                            UserId = 3,
                            IsDeletedFL = false,
                            PasswordTXT = "1234",
                            UserRoleID = 3,
                            UserNM = "Yasemin"
                        },
                        new
                        {
                            UserId = 4,
                            IsDeletedFL = false,
                            PasswordTXT = "1234",
                            UserRoleID = 2,
                            UserNM = "Betül"
                        },
                        new
                        {
                            UserId = 5,
                            IsDeletedFL = false,
                            PasswordTXT = "1234",
                            UserRoleID = 2,
                            UserNM = "Murat"
                        },
                        new
                        {
                            UserId = 6,
                            IsDeletedFL = false,
                            PasswordTXT = "1234",
                            UserRoleID = 2,
                            UserNM = "Zeynep"
                        },
                        new
                        {
                            UserId = 7,
                            IsDeletedFL = false,
                            PasswordTXT = "1234",
                            UserRoleID = 2,
                            UserNM = "Dilan"
                        },
                        new
                        {
                            UserId = 8,
                            IsDeletedFL = false,
                            PasswordTXT = "1234",
                            UserRoleID = 2,
                            UserNM = "Aysu"
                        },
                        new
                        {
                            UserId = 9,
                            IsDeletedFL = false,
                            PasswordTXT = "1234",
                            UserRoleID = 2,
                            UserNM = "Melisa"
                        },
                        new
                        {
                            UserId = 10,
                            IsDeletedFL = false,
                            PasswordTXT = "1234",
                            UserRoleID = 2,
                            UserNM = "Hilal"
                        });
                });

            modelBuilder.Entity("TaskDistribution.Data.Modals.UserRole", b =>
                {
                    b.Property<int>("UserRoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserRoleID"));

                    b.Property<bool>("IsDeleted_FL")
                        .HasColumnType("bit");

                    b.Property<string>("UserRole_NM")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserRoleID");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            UserRoleID = 1,
                            IsDeletedFL = false,
                            UserRoleNM = "Software Analyst"
                        },
                        new
                        {
                            UserRoleID = 2,
                            IsDeletedFL = false,
                            UserRoleNM = "User"
                        },
                        new
                        {
                            UserRoleID = 3,
                            IsDeletedFL = false,
                            UserRoleNM = "Software Manager"
                        });
                });

            modelBuilder.Entity("TaskDistribution.Data.Modals.Task", b =>
                {
                    b.HasOne("TaskDistribution.Data.Modals.TaskDifficultType", "TaskDifficultType")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskDifficultTypeID");

                    b.HasOne("TaskDistribution.Data.Modals.TaskType", "TaskType")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskTypeID");

                    b.HasOne("TaskDistribution.Data.Modals.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserID");

                    b.Navigation("TaskDifficultType");

                    b.Navigation("TaskType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskDistribution.Data.Modals.User", b =>
                {
                    b.HasOne("TaskDistribution.Data.Modals.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleID");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("TaskDistribution.Data.Modals.TaskDifficultType", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskDistribution.Data.Modals.TaskType", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskDistribution.Data.Modals.User", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("TaskDistribution.Data.Modals.UserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}