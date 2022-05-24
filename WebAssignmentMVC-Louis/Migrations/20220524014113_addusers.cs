using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAssignmentMVC.Migrations
{
    public partial class addusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ccea9f8d-508a-47a9-92d1-a02caad16aa8");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ccea9f8d-508a-47a9-92d1-a02caad16aa8", 0, "b057695e-a6d0-4e37-8f31-4d106467f520", new DateTime(2022, 5, 23, 12, 17, 7, 549, DateTimeKind.Local).AddTicks(3456), "admin@gmail.com", true, "Louis", "Lim", false, null, null, null, "AQAAAAEAACcQAAAAEGFbayObOTOry8nKkJ2PqNmW/fx8WWqcQsw/zLQ+LacSMuyjFPUfZlJlp/tQ/tbIhg==", null, false, "7b872933-26fa-4285-877d-d7bbe27c8e13", false, "Admin" });
        }
    }
}
