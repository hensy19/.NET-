using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cleo.Migrations
{
    /// <inheritdoc />
    public partial class AddSymptomLog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SymptomLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    Symptoms = table.Column<string>(type: "TEXT", nullable: false),
                    Notes = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymptomLogs", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastActive",
                value: new DateTime(2026, 3, 31, 18, 36, 54, 429, DateTimeKind.Utc).AddTicks(4632));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastActive",
                value: new DateTime(2026, 3, 31, 18, 36, 54, 429, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastActive",
                value: new DateTime(2026, 3, 31, 18, 36, 54, 429, DateTimeKind.Utc).AddTicks(4637));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2026, 3, 31, 18, 36, 54, 429, DateTimeKind.Utc).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2026, 3, 31, 18, 36, 54, 429, DateTimeKind.Utc).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2026, 3, 31, 18, 36, 54, 429, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishDate",
                value: new DateTime(2026, 3, 31, 18, 36, 54, 429, DateTimeKind.Utc).AddTicks(4722));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SymptomLogs");

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1,
                column: "LastActive",
                value: new DateTime(2026, 3, 31, 18, 34, 2, 475, DateTimeKind.Utc).AddTicks(6349));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 2,
                column: "LastActive",
                value: new DateTime(2026, 3, 31, 18, 34, 2, 475, DateTimeKind.Utc).AddTicks(6352));

            migrationBuilder.UpdateData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 3,
                column: "LastActive",
                value: new DateTime(2026, 3, 31, 18, 34, 2, 475, DateTimeKind.Utc).AddTicks(6353));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2026, 3, 31, 18, 34, 2, 475, DateTimeKind.Utc).AddTicks(6467));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2026, 3, 31, 18, 34, 2, 475, DateTimeKind.Utc).AddTicks(6469));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2026, 3, 31, 18, 34, 2, 475, DateTimeKind.Utc).AddTicks(6471));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                column: "PublishDate",
                value: new DateTime(2026, 3, 31, 18, 34, 2, 475, DateTimeKind.Utc).AddTicks(6471));
        }
    }
}
