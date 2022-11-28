using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstMVCApp.Migrations
{
    public partial class AddedCountryList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_People",
                table: "People");

            migrationBuilder.RenameTable(
                name: "People",
                newName: "PeopleList");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "PeopleList",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "PeopleList",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PeopleList",
                table: "PeopleList",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CountryList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capital = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryList", x => x.Id);
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityList", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityList_CountryList_CountryId",
                        column: x => x.CountryId,
                        principalTable: "CountryList",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "CityList",
                columns: new[] { "Id", "CityName", "CountryId", "CountryName" },
                values: new object[,]
                {
                    { 1, "Stockholm", null, "Sweden" },
                    { 2, "Los Angeles", null, "USA" }
                });

            migrationBuilder.InsertData(
                table: "CountryList",
                columns: new[] { "Id", "Capital", "CountryName" },
                values: new object[,]
                {
                    { 1, "Stockholm", "Sweden" },
                    { 2, "Washington", "USA" }
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
                table: "PeopleList",
                columns: new[] { "Id", "City", "CityId", "LanguageId", "Name", "PhoneNumber" },
                values: new object[] { 2, "Los Angeles", null, null, "Ronnie Coleman", "0976 123 321" });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleList_CityId",
                table: "PeopleList",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PeopleList_LanguageId",
                table: "PeopleList",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_CityList_CountryId",
                table: "CityList",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleList_CityList_CityId",
                table: "PeopleList",
                column: "CityId",
                principalTable: "CityList",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleList_LanguageList_LanguageId",
                table: "PeopleList",
                column: "LanguageId",
                principalTable: "LanguageList",
                principalColumn: "LanguageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeopleList_CityList_CityId",
                table: "PeopleList");

            migrationBuilder.DropForeignKey(
                name: "FK_PeopleList_LanguageList_LanguageId",
                table: "PeopleList");

            migrationBuilder.DropTable(
                name: "CityList");

            migrationBuilder.DropTable(
                name: "LanguageList");

            migrationBuilder.DropTable(
                name: "CountryList");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PeopleList",
                table: "PeopleList");

            migrationBuilder.DropIndex(
                name: "IX_PeopleList_CityId",
                table: "PeopleList");

            migrationBuilder.DropIndex(
                name: "IX_PeopleList_LanguageId",
                table: "PeopleList");

            migrationBuilder.DeleteData(
                table: "PeopleList",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "PeopleList");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "PeopleList");

            migrationBuilder.RenameTable(
                name: "PeopleList",
                newName: "People");

            migrationBuilder.AddPrimaryKey(
                name: "PK_People",
                table: "People",
                column: "Id");
        }
    }
}
