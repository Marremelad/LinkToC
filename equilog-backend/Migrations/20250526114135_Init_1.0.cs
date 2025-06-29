﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace equilog_backend.Migrations
{
    /// <inheritdoc />
    public partial class Init_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 4094, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Age = table.Column<DateOnly>(type: "date", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Breed = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CoreInformation = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    Weight = table.Column<int>(type: "int", nullable: true),
                    Height = table.Column<int>(type: "int", nullable: true),
                    CurrentBox = table.Column<int>(type: "int", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PasswordResetRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    Token = table.Column<string>(type: "nvarchar(38)", maxLength: 38, nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PasswordResetRequests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StableLocation",
                columns: table => new
                {
                    PostCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MunicipalityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MunicipalityCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Latitude = table.Column<double>(type: "float", nullable: false),
                    Longitude = table.Column<double>(type: "float", nullable: false),
                    GoogleMaps = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StableLocation", x => x.PostCode);
                });

            migrationBuilder.CreateTable(
                name: "Stables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    County = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PostCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    BoxCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    EmergencyContact = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    CoreInformation = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StableHorses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StableIdFk = table.Column<int>(type: "int", nullable: false),
                    HorseIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StableHorses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StableHorses_Horses_HorseIdFk",
                        column: x => x.HorseIdFk,
                        principalTable: "Horses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StableHorses_Stables_StableIdFk",
                        column: x => x.StableIdFk,
                        principalTable: "Stables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CalendarEvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserIdFk = table.Column<int>(type: "int", nullable: false),
                    StableIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarEvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CalendarEvents_Stables_StableIdFk",
                        column: x => x.StableIdFk,
                        principalTable: "Stables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarEvents_Users_UserIdFk",
                        column: x => x.UserIdFk,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false),
                    UserIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserIdFk",
                        column: x => x.UserIdFk,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StableInvites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdFk = table.Column<int>(type: "int", nullable: false),
                    StableIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StableInvites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StableInvites_Stables_StableIdFk",
                        column: x => x.StableIdFk,
                        principalTable: "Stables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StableInvites_Users_UserIdFk",
                        column: x => x.UserIdFk,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StableJoinRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdFk = table.Column<int>(type: "int", nullable: false),
                    StableIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StableJoinRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StableJoinRequests_Stables_StableIdFk",
                        column: x => x.StableIdFk,
                        principalTable: "Stables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StableJoinRequests_Users_UserIdFk",
                        column: x => x.UserIdFk,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StablePosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdFk = table.Column<int>(type: "int", nullable: false),
                    StableIdFk = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(510)", maxLength: 510, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", maxLength: 4094, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsPinned = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StablePosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StablePosts_Stables_StableIdFk",
                        column: x => x.StableIdFk,
                        principalTable: "Stables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StablePosts_Users_UserIdFk",
                        column: x => x.UserIdFk,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdFk = table.Column<int>(type: "int", nullable: false),
                    CommentIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComments_Comments_CommentIdFk",
                        column: x => x.CommentIdFk,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserComments_Users_UserIdFk",
                        column: x => x.UserIdFk,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserHorses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdFk = table.Column<int>(type: "int", nullable: false),
                    HorseIdFk = table.Column<int>(type: "int", nullable: false),
                    UserRole = table.Column<int>(type: "int", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHorses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHorses_Horses_HorseIdFk",
                        column: x => x.HorseIdFk,
                        principalTable: "Horses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserHorses_Users_UserIdFk",
                        column: x => x.UserIdFk,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserStables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIdFk = table.Column<int>(type: "int", nullable: false),
                    StableIdFk = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserStables_Stables_StableIdFk",
                        column: x => x.StableIdFk,
                        principalTable: "Stables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserStables_Users_UserIdFk",
                        column: x => x.UserIdFk,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StablePostComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StablePostIdFk = table.Column<int>(type: "int", nullable: false),
                    CommentIdFk = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StablePostComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StablePostComments_Comments_CommentIdFk",
                        column: x => x.CommentIdFk,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StablePostComments_StablePosts_StablePostIdFk",
                        column: x => x.StablePostIdFk,
                        principalTable: "StablePosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvents_StableIdFk",
                table: "CalendarEvents",
                column: "StableIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvents_UserIdFk",
                table: "CalendarEvents",
                column: "UserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserIdFk",
                table: "RefreshTokens",
                column: "UserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_StableHorses_HorseIdFk",
                table: "StableHorses",
                column: "HorseIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_StableHorses_StableIdFk",
                table: "StableHorses",
                column: "StableIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_StableInvites_StableIdFk",
                table: "StableInvites",
                column: "StableIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_StableInvites_UserIdFk",
                table: "StableInvites",
                column: "UserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_StableJoinRequests_StableIdFk",
                table: "StableJoinRequests",
                column: "StableIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_StableJoinRequests_UserIdFk",
                table: "StableJoinRequests",
                column: "UserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_StablePostComments_CommentIdFk",
                table: "StablePostComments",
                column: "CommentIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_StablePostComments_StablePostIdFk",
                table: "StablePostComments",
                column: "StablePostIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_StablePosts_StableIdFk",
                table: "StablePosts",
                column: "StableIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_StablePosts_UserIdFk",
                table: "StablePosts",
                column: "UserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_CommentIdFk",
                table: "UserComments",
                column: "CommentIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_UserIdFk",
                table: "UserComments",
                column: "UserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_UserHorses_HorseIdFk",
                table: "UserHorses",
                column: "HorseIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_UserHorses_UserIdFk",
                table: "UserHorses",
                column: "UserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_UserStables_StableIdFk",
                table: "UserStables",
                column: "StableIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_UserStables_UserIdFk",
                table: "UserStables",
                column: "UserIdFk");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarEvents");

            migrationBuilder.DropTable(
                name: "PasswordResetRequests");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "StableHorses");

            migrationBuilder.DropTable(
                name: "StableInvites");

            migrationBuilder.DropTable(
                name: "StableJoinRequests");

            migrationBuilder.DropTable(
                name: "StableLocation");

            migrationBuilder.DropTable(
                name: "StablePostComments");

            migrationBuilder.DropTable(
                name: "UserComments");

            migrationBuilder.DropTable(
                name: "UserHorses");

            migrationBuilder.DropTable(
                name: "UserStables");

            migrationBuilder.DropTable(
                name: "StablePosts");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Horses");

            migrationBuilder.DropTable(
                name: "Stables");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
