using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First_MVC_App.Migrations
{
    public partial class jgvjgv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguageListLanguageId", "PeopleListId" },
                values: new object[] { 1, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguageListLanguageId", "PeopleListId" },
                keyValues: new object[] { 1, 1 });
        }
    }
}
