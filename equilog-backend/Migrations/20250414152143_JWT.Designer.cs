﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using equilog_backend.Data;

#nullable disable

namespace equilog_backend.Migrations
{
    [DbContext(typeof(EquilogDbContext))]
    [Migration("20250414152143_JWT")]
    partial class JWT
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("equilog_backend.Models.CalendarEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("StableIdFk")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("StableIdFk");

                    b.ToTable("CalendarEvents");
                });

            modelBuilder.Entity("equilog_backend.Models.Horse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("Age")
                        .HasColumnType("date");

                    b.Property<string>("Breed")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Color")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Horses");
                });

            modelBuilder.Entity("equilog_backend.Models.Stable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Stables");
                });

            modelBuilder.Entity("equilog_backend.Models.StableHorse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HorseIdFk")
                        .HasColumnType("int");

                    b.Property<int>("StableIdFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HorseIdFk");

                    b.HasIndex("StableIdFk");

                    b.ToTable("StableHorses");
                });

            modelBuilder.Entity("equilog_backend.Models.StablePost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(4094)
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsPinned")
                        .HasColumnType("bit");

                    b.Property<int>("StableIdFk")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(510)
                        .HasColumnType("nvarchar(510)");

                    b.Property<int>("UserIdFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StableIdFk");

                    b.HasIndex("UserIdFk");

                    b.ToTable("StablePosts");
                });

            modelBuilder.Entity("equilog_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("equilog_backend.Models.UserCalendarEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CalendarEventId")
                        .HasColumnType("int");

                    b.Property<int>("EventIdFk")
                        .HasColumnType("int");

                    b.Property<int>("UserIdFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CalendarEventId");

                    b.HasIndex("UserIdFk");

                    b.ToTable("UserCalendarEvents");
                });

            modelBuilder.Entity("equilog_backend.Models.UserHorse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("HorseIdFk")
                        .HasColumnType("int");

                    b.Property<int>("UserIdFk")
                        .HasColumnType("int");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("HorseIdFk");

                    b.HasIndex("UserIdFk");

                    b.ToTable("UserHorses");
                });

            modelBuilder.Entity("equilog_backend.Models.UserStable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("StableIdFk")
                        .HasColumnType("int");

                    b.Property<int>("UserIdFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StableIdFk");

                    b.HasIndex("UserIdFk");

                    b.ToTable("UserStables");
                });

            modelBuilder.Entity("equilog_backend.Models.CalendarEvent", b =>
                {
                    b.HasOne("equilog_backend.Models.Stable", "Stable")
                        .WithMany()
                        .HasForeignKey("StableIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stable");
                });

            modelBuilder.Entity("equilog_backend.Models.StableHorse", b =>
                {
                    b.HasOne("equilog_backend.Models.Horse", "Horse")
                        .WithMany("StableHorses")
                        .HasForeignKey("HorseIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("equilog_backend.Models.Stable", "Stable")
                        .WithMany("StableHorses")
                        .HasForeignKey("StableIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Horse");

                    b.Navigation("Stable");
                });

            modelBuilder.Entity("equilog_backend.Models.StablePost", b =>
                {
                    b.HasOne("equilog_backend.Models.Stable", "Stable")
                        .WithMany("StablePost")
                        .HasForeignKey("StableIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("equilog_backend.Models.User", "User")
                        .WithMany("StablePost")
                        .HasForeignKey("UserIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stable");

                    b.Navigation("User");
                });

            modelBuilder.Entity("equilog_backend.Models.UserCalendarEvent", b =>
                {
                    b.HasOne("equilog_backend.Models.CalendarEvent", "CalendarEvent")
                        .WithMany("UserCalendarEvents")
                        .HasForeignKey("CalendarEventId");

                    b.HasOne("equilog_backend.Models.User", "User")
                        .WithMany("UserEvents")
                        .HasForeignKey("UserIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CalendarEvent");

                    b.Navigation("User");
                });

            modelBuilder.Entity("equilog_backend.Models.UserHorse", b =>
                {
                    b.HasOne("equilog_backend.Models.Horse", "Horse")
                        .WithMany("UserHorses")
                        .HasForeignKey("HorseIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("equilog_backend.Models.User", "User")
                        .WithMany("UserHorses")
                        .HasForeignKey("UserIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Horse");

                    b.Navigation("User");
                });

            modelBuilder.Entity("equilog_backend.Models.UserStable", b =>
                {
                    b.HasOne("equilog_backend.Models.Stable", "Stable")
                        .WithMany("UserStables")
                        .HasForeignKey("StableIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("equilog_backend.Models.User", "User")
                        .WithMany("UserStables")
                        .HasForeignKey("UserIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stable");

                    b.Navigation("User");
                });

            modelBuilder.Entity("equilog_backend.Models.CalendarEvent", b =>
                {
                    b.Navigation("UserCalendarEvents");
                });

            modelBuilder.Entity("equilog_backend.Models.Horse", b =>
                {
                    b.Navigation("StableHorses");

                    b.Navigation("UserHorses");
                });

            modelBuilder.Entity("equilog_backend.Models.Stable", b =>
                {
                    b.Navigation("StableHorses");

                    b.Navigation("StablePost");

                    b.Navigation("UserStables");
                });

            modelBuilder.Entity("equilog_backend.Models.User", b =>
                {
                    b.Navigation("StablePost");

                    b.Navigation("UserEvents");

                    b.Navigation("UserHorses");

                    b.Navigation("UserStables");
                });
#pragma warning restore 612, 618
        }
    }
}
