﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using equilog_backend.Data;

#nullable disable

namespace equilog_backend.Migrations
{
    [DbContext(typeof(EquilogDbContext))]
    partial class EquilogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("UserIdFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StableIdFk");

                    b.HasIndex("UserIdFk");

                    b.ToTable("CalendarEvents");
                });

            modelBuilder.Entity("equilog_backend.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CommentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasMaxLength(4094)
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Comments");
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

                    b.Property<string>("CoreInformation")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<int?>("CurrentBox")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ProfilePicture")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Horses");
                });

            modelBuilder.Entity("equilog_backend.Models.PasswordResetRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(38)
                        .HasColumnType("nvarchar(38)");

                    b.HasKey("Id");

                    b.ToTable("PasswordResetRequests");
                });

            modelBuilder.Entity("equilog_backend.Models.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRevoked")
                        .HasColumnType("bit");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("bit");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<int>("UserIdFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserIdFk");

                    b.ToTable("RefreshTokens");
                });

            modelBuilder.Entity("equilog_backend.Models.Stable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("BoxCount")
                        .HasColumnType("int");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PostCode")
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("Type")
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

            modelBuilder.Entity("equilog_backend.Models.StableInvite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("StableIdFk")
                        .HasColumnType("int");

                    b.Property<int>("UserIdFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StableIdFk");

                    b.HasIndex("UserIdFk");

                    b.ToTable("StableInvites");
                });

            modelBuilder.Entity("equilog_backend.Models.StableJoinRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("StableIdFk")
                        .HasColumnType("int");

                    b.Property<int>("UserIdFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("StableIdFk");

                    b.HasIndex("UserIdFk");

                    b.ToTable("StableJoinRequests");
                });

            modelBuilder.Entity("equilog_backend.Models.StableLocation", b =>
                {
                    b.Property<string>("PostCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoogleMaps")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("MunicipalityCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MunicipalityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PostCode");

                    b.ToTable("StableLocation");
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

            modelBuilder.Entity("equilog_backend.Models.StablePostComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommentIdFk")
                        .HasColumnType("int");

                    b.Property<int>("StablePostIdFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentIdFk");

                    b.HasIndex("StablePostIdFk");

                    b.ToTable("StablePostComments");
                });

            modelBuilder.Entity("equilog_backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CoreInformation")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("Description")
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(254)
                        .HasColumnType("nvarchar(254)");

                    b.Property<string>("EmergencyContact")
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

                    b.Property<string>("ProfilePicture")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("equilog_backend.Models.UserComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CommentIdFk")
                        .HasColumnType("int");

                    b.Property<int>("UserIdFk")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CommentIdFk");

                    b.HasIndex("UserIdFk");

                    b.ToTable("UserComments");
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

                    b.Property<int>("UserRole")
                        .HasMaxLength(20)
                        .HasColumnType("int");

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

                    b.HasOne("equilog_backend.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stable");

                    b.Navigation("User");
                });

            modelBuilder.Entity("equilog_backend.Models.RefreshToken", b =>
                {
                    b.HasOne("equilog_backend.Models.User", "User")
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
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

            modelBuilder.Entity("equilog_backend.Models.StableInvite", b =>
                {
                    b.HasOne("equilog_backend.Models.Stable", "Stable")
                        .WithMany("StableInvites")
                        .HasForeignKey("StableIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("equilog_backend.Models.User", "User")
                        .WithMany("StableInvites")
                        .HasForeignKey("UserIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stable");

                    b.Navigation("User");
                });

            modelBuilder.Entity("equilog_backend.Models.StableJoinRequest", b =>
                {
                    b.HasOne("equilog_backend.Models.Stable", "Stable")
                        .WithMany("StableJoinRequests")
                        .HasForeignKey("StableIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("equilog_backend.Models.User", "User")
                        .WithMany("StableJoinRequests")
                        .HasForeignKey("UserIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Stable");

                    b.Navigation("User");
                });

            modelBuilder.Entity("equilog_backend.Models.StablePost", b =>
                {
                    b.HasOne("equilog_backend.Models.Stable", "Stable")
                        .WithMany("StablePosts")
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

            modelBuilder.Entity("equilog_backend.Models.StablePostComment", b =>
                {
                    b.HasOne("equilog_backend.Models.Comment", "Comment")
                        .WithMany("StablePostComments")
                        .HasForeignKey("CommentIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("equilog_backend.Models.StablePost", "StablePost")
                        .WithMany("StablePostComments")
                        .HasForeignKey("StablePostIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

                    b.Navigation("StablePost");
                });

            modelBuilder.Entity("equilog_backend.Models.UserComment", b =>
                {
                    b.HasOne("equilog_backend.Models.Comment", "Comment")
                        .WithMany("UserComments")
                        .HasForeignKey("CommentIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("equilog_backend.Models.User", "User")
                        .WithMany("UserComments")
                        .HasForeignKey("UserIdFk")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");

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

            modelBuilder.Entity("equilog_backend.Models.Comment", b =>
                {
                    b.Navigation("StablePostComments");

                    b.Navigation("UserComments");
                });

            modelBuilder.Entity("equilog_backend.Models.Horse", b =>
                {
                    b.Navigation("StableHorses");

                    b.Navigation("UserHorses");
                });

            modelBuilder.Entity("equilog_backend.Models.Stable", b =>
                {
                    b.Navigation("StableHorses");

                    b.Navigation("StableInvites");

                    b.Navigation("StableJoinRequests");

                    b.Navigation("StablePosts");

                    b.Navigation("UserStables");
                });

            modelBuilder.Entity("equilog_backend.Models.StablePost", b =>
                {
                    b.Navigation("StablePostComments");
                });

            modelBuilder.Entity("equilog_backend.Models.User", b =>
                {
                    b.Navigation("RefreshTokens");

                    b.Navigation("StableInvites");

                    b.Navigation("StableJoinRequests");

                    b.Navigation("StablePost");

                    b.Navigation("UserComments");

                    b.Navigation("UserHorses");

                    b.Navigation("UserStables");
                });
#pragma warning restore 612, 618
        }
    }
}
