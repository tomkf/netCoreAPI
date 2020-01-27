using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace netCoreAPI.Migrations
{
    public partial class PutPostRoutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 1, 26, 22, 34, 49, 53, DateTimeKind.Local).AddTicks(8596));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 1, 26, 22, 34, 49, 55, DateTimeKind.Local).AddTicks(8728));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2020, 1, 26, 19, 59, 19, 128, DateTimeKind.Local).AddTicks(8095));

            migrationBuilder.UpdateData(
                table: "ToDos",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2020, 1, 26, 19, 59, 19, 132, DateTimeKind.Local).AddTicks(8173));
        }
    }
}
