using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cleo.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    IsSuperAdmin = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastActive = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    Status = table.Column<string>(type: "TEXT", nullable: false),
                    Views = table.Column<int>(type: "INTEGER", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CycleTracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsCurrentCycle = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CycleTracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MoodNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Mood = table.Column<string>(type: "TEXT", nullable: false),
                    Note = table.Column<string>(type: "TEXT", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoodNotes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "IsSuperAdmin", "LastActive", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "admin@cleo.app", true, new DateTime(2026, 3, 31, 18, 34, 2, 475, DateTimeKind.Utc).AddTicks(6349), "Admin", "password123" },
                    { 2, "ava@cleo.app", true, new DateTime(2026, 3, 31, 18, 34, 2, 475, DateTimeKind.Utc).AddTicks(6352), "Ava", "password123" },
                    { 3, "hensy@cleo.app", true, new DateTime(2026, 3, 31, 18, 34, 2, 475, DateTimeKind.Utc).AddTicks(6353), "Hensy", "password123" }
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "Category", "Content", "PublishDate", "Status", "Title", "Views" },
                values: new object[,]
                {
                    { 1, "Nutrition", "Detailed analysis...", new DateTime(2026, 3, 31, 18, 34, 2, 475, DateTimeKind.Utc).AddTicks(6467), "Published", "Focus on Iron-Rich Foods", 1240 },
                    { 2, "Exercise", "Detailed analysis...", new DateTime(2026, 3, 31, 18, 34, 2, 475, DateTimeKind.Utc).AddTicks(6469), "Published", "Yoga for Cramp Relief", 952 },
                    { 3, "Science", "Detailed analysis...", new DateTime(2026, 3, 31, 18, 34, 2, 475, DateTimeKind.Utc).AddTicks(6471), "Published", "Understanding LH Surge", 1520 },
                    { 4, "Health", "Detailed analysis...", new DateTime(2026, 3, 31, 18, 34, 2, 475, DateTimeKind.Utc).AddTicks(6471), "Published", "Managing PMS Bloating", 840 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "CycleTracks");

            migrationBuilder.DropTable(
                name: "MoodNotes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
