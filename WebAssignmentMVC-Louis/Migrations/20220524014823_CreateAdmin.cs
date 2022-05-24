using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAssignmentMVC.Migrations
{
    public partial class CreateAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "23e42b09-b3f1-43c7-89aa-98c372767c5f", 0, "fa721658-1c48-4f5e-b810-159b07c00820", new DateTime(2022, 5, 24, 3, 48, 22, 815, DateTimeKind.Local).AddTicks(852), "admin@gmail.com", true, "Louis", "Lim", false, null, null, null, "AQAAAAEAACcQAAAAEKuqxf0OqPzDbi2SXd6sI2UgZ9usib3ozgJ7Rq03PobOQ2mSTh361+hVjcezztRn7g==", null, false, "aa14b3d9-e0e9-4521-84af-f88f6d58b749", false, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "23e42b09-b3f1-43c7-89aa-98c372767c5f");
        }
    }
}
