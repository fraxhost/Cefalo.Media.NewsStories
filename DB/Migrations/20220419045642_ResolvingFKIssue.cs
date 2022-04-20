using Microsoft.EntityFrameworkCore.Migrations;

namespace DB.Migrations
{
    public partial class ResolvingFKIssue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "86dec1a6-8d2c-4ddb-a94d-9dadb8515bc6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b86d79d7-a138-402b-854b-d8bfa3229afe");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d4d5b3c2-57bd-45a1-8b50-76e7c791b7e6", "15d793c8-afe6-472b-9e16-ec0fca1c7fdb", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "64e5277e-4edd-4717-9f7c-abf0a03e33bd", "c3c1000c-de1f-46d7-b614-95d906afd907", "General", "GENERAL" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64e5277e-4edd-4717-9f7c-abf0a03e33bd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d4d5b3c2-57bd-45a1-8b50-76e7c791b7e6");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "86dec1a6-8d2c-4ddb-a94d-9dadb8515bc6", "863aa59a-963d-4ded-9c75-7089d44cf515", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "b86d79d7-a138-402b-854b-d8bfa3229afe", "374a779d-2088-4c78-bed0-2514a42d6988", "General", "GENERAL" });
        }
    }
}
