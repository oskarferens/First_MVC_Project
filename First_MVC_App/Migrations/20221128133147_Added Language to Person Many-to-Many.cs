using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstMVCApp.Migrations
{
    public partial class AddedLanguagetoPersonManytoMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeopleList_CityList_CityId",
                table: "PeopleList");

            migrationBuilder.DropForeignKey(
                name: "FK_PeopleList_LanguageList_LanguageId",
                table: "PeopleList");

            migrationBuilder.DropIndex(
                name: "IX_PeopleList_LanguageId",
                table: "PeopleList");

            migrationBuilder.DropColumn(
                name: "City",
                table: "PeopleList");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "PeopleList");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "PeopleList",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "PeopleList",
                keyColumn: "Id",
                keyValue: 1,
                column: "CityId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "PeopleList",
                keyColumn: "Id",
                keyValue: 2,
                column: "CityId",
                value: 2);

            migrationBuilder.CreateIndex(
                name: "IX_LanguagePerson_PeopleListId",
                table: "LanguagePerson",
                column: "PeopleListId");

            migrationBuilder.AddForeignKey(
                name: "FK_PeopleList_CityList_CityId",
                table: "PeopleList",
                column: "CityId",
                principalTable: "CityList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PeopleList_CityList_CityId",
                table: "PeopleList");

            migrationBuilder.DropTable(
                name: "LanguagePerson");

            migrationBuilder.AlterColumn<int>(
                name: "CityId",
                table: "PeopleList",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "PeopleList",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "PeopleList",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "PeopleList",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "City", "CityId" },
                values: new object[] { "Göteborg", null });

            migrationBuilder.UpdateData(
                table: "PeopleList",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "City", "CityId" },
                values: new object[] { "Los Angeles", null });

            migrationBuilder.CreateIndex(
                name: "IX_PeopleList_LanguageId",
                table: "PeopleList",
                column: "LanguageId");

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
    }
}
