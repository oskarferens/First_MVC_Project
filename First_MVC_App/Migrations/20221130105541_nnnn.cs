using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First_MVC_App.Migrations
{
    public partial class nnnn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CountryList",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryList", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "LanguageList",
                columns: table => new
                {
                    LanguageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageList", x => x.LanguageId);
                });

            migrationBuilder.CreateTable(
                name: "CityList",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityList", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_CityList_CountryList_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryList",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeopleList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeopleList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeopleList_CityList_CityId",
                        column: x => x.CityId,
                        principalTable: "CityList",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LanguagePerson",
                columns: table => new
                {
                    LanguageListLanguageId = table.Column<int>(type: "int", nullable: false),
                    PeopleListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguagePerson", x => new { x.LanguageListLanguageId, x.PeopleListId });
                    table.ForeignKey(
                        name: "FK_LanguagePerson_LanguageList_LanguageListLanguageId",
                        column: x => x.LanguageListLanguageId,
                        principalTable: "LanguageList",
                        principalColumn: "LanguageId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanguagePerson_PeopleList_PeopleListId",
                        column: x => x.PeopleListId,
                        principalTable: "PeopleList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CountryList",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[,]
                {
                    { 1, "Sweden" },
                    { 2, "USA" }
                });

            migrationBuilder.InsertData(
                table: "LanguageList",
                columns: new[] { "LanguageId", "Name" },
                values: new object[,]
                {
                    { 1, "Swedish" },
                    { 2, "English" },
                    { 3, "Polish" },
                    { 4, "Tagalog" }
                });

            migrationBuilder.InsertData(
                table: "CityList",
                columns: new[] { "CityId", "CityName", "CountryId" },
                values: new object[] { 1, "Stockholm", 1 });

            migrationBuilder.InsertData(
                table: "CityList",
                columns: new[] { "CityId", "CityName", "CountryId" },
                values: new object[] { 2, "Los Angeles", 2 });

            migrationBuilder.InsertData(
                table: "PeopleList",
                columns: new[] { "Id", "CityId", "Name", "PhoneNumber" },
                values: new object[] { 1, 1, "Oskar F", "031 123 345" });

            migrationBuilder.InsertData(
                table: "PeopleList",
                columns: new[] { "Id", "CityId", "Name", "PhoneNumber" },
                values: new object[] { 2, 2, "Ronnie Coleman", "0976 123 321" });

            migrationBuilder.CreateIndex(
                name: "IX_CityList_CountryId",
                table: "CityList",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePerson_PeopleListId",
                table: "LanguagePerson",
                column: "PeopleListId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleList_CityId",
                table: "PeopleList",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguagePerson");

            migrationBuilder.DropTable(
                name: "LanguageList");

            migrationBuilder.DropTable(
                name: "PeopleList");

            migrationBuilder.DropTable(
                name: "CityList");

            migrationBuilder.DropTable(
                name: "CountryList");
        }
    }
}
