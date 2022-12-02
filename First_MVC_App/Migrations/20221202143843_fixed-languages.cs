using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First_MVC_App.Migrations
{
    public partial class fixedlanguages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguageListLanguageId", "PeopleListId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguageListLanguageId", "PeopleListId" },
                values: new object[] { 3, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguageListLanguageId", "PeopleListId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguageListLanguageId", "PeopleListId" },
                keyValues: new object[] { 3, 2 });
        }
    }
}
