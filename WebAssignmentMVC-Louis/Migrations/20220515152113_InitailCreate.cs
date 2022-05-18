using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAssignmentMVC.Migrations
{
    public partial class InitailCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LangName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    CtyId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cname = table.Column<string>(nullable: true),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Countries_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PersonLanguage",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    LanguageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonLanguage", x => new { x.PersonId, x.LanguageId });
                    table.ForeignKey(
                        name: "FK_PersonLanguage_Language_LanguageId",
                        column: x => x.LanguageId,
                        principalTable: "Language",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonLanguage_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountryFiD = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Countries_CountryFiD",
                        column: x => x.CountryFiD,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Cities_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Cname", "PersonId" },
                values: new object[,]
                {
                    { 1, "Sweden", null },
                    { 2, "France", null },
                    { 3, "Germany", null }
                });

            migrationBuilder.InsertData(
                table: "Language",
                columns: new[] { "Id", "LangName" },
                values: new object[,]
                {
                    { 1, "Swedish" },
                    { 2, "English" },
                    { 3, "Chinese" }
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "CountryId", "CtyId", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, 1, 1, "Louis", "Lim", "0765551111" },
                    { 2, 1, 2, "Michael", "Kent", "0733338888" },
                    { 3, 1, 3, "Åsa", "Jason", "0721231234" },
                    { 4, 2, 0, "Andy", "Birch", "0744448888" },
                    { 5, 2, 0, "Johnny", "Walker", "0751244674" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryFiD", "Name", "PersonId" },
                values: new object[,]
                {
                    { 1, 1, "Stockholm", null },
                    { 2, 1, "Helsingborg", null },
                    { 3, 1, "Växjö", null },
                    { 4, 1, "Gävle", null },
                    { 5, 1, "Trollhättan", null },
                    { 6, 3, "Berlin", null },
                    { 7, 3, "Hamburg", null },
                    { 8, 3, "Munich", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_CountryFiD",
                table: "Cities",
                column: "CountryFiD");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_PersonId",
                table: "Cities",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Countries_PersonId",
                table: "Countries",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonLanguage_LanguageId",
                table: "PersonLanguage",
                column: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "PersonLanguage");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropTable(
                name: "Persons");
        }
    }
}
