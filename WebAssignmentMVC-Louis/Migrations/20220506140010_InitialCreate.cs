using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAssignmentMVC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonList",
                table: "PersonList");

            migrationBuilder.DropColumn(
                name: "City",
                table: "PersonList");

            migrationBuilder.RenameTable(
                name: "PersonList",
                newName: "Persons");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Persons",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cname = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CityId",
                table: "Persons",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CountryId",
                table: "Persons",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Cities_CityId",
                table: "Persons",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Countries_CountryId",
                table: "Persons",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Cities_CityId",
                table: "Persons");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Countries_CountryId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CityId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CountryId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Persons",
                newName: "PersonList");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PersonList",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonList",
                table: "PersonList",
                column: "Id");
        }
    }
}
