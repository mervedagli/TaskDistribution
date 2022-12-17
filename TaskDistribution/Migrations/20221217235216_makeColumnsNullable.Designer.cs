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
    [Migration("20221217235216_makeColumnsNullable")]
    partial class makeColumnsNullable
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

                    b.Property<string>("Task_DSC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Task_NM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserID")
                        .HasColumnType("int");

                    b.HasKey("TaskID");

                    b.HasIndex("TaskDifficultTypeID");

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

                    b.Property<int>("UserRoleID")
                        .HasColumnType("int");

                    b.Property<string>("User_NM")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("UserRoleID");

                    b.ToTable("Users");
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
                });

            modelBuilder.Entity("TaskDistribution.Data.Modals.Task", b =>
                {
                    b.HasOne("TaskDistribution.Data.Modals.TaskDifficultType", "TaskDifficultType")
                        .WithMany("Tasks")
                        .HasForeignKey("TaskDifficultTypeID");

                    b.HasOne("TaskDistribution.Data.Modals.User", "User")
                        .WithMany("Tasks")
                        .HasForeignKey("UserID");

                    b.Navigation("TaskDifficultType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TaskDistribution.Data.Modals.User", b =>
                {
                    b.HasOne("TaskDistribution.Data.Modals.UserRole", "UserRole")
                        .WithMany("Users")
                        .HasForeignKey("UserRoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("TaskDistribution.Data.Modals.TaskDifficultType", b =>
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
