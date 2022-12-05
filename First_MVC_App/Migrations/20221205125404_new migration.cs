using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First_MVC_App.Migrations
{
    public partial class newmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CountryList",
                columns: new[] { "CountryId", "CountryName" },
                values: new object[] { 3, "Germany" });

            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguageListLanguageId", "PeopleListId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 4, 1 }
                });

            migrationBuilder.UpdateData(
                table: "PeopleList",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Ronnie C");

            migrationBuilder.InsertData(
                table: "CityList",
                columns: new[] { "CityId", "CityName", "CountryId" },
                values: new object[] { 3, "Berlin", 3 });

            migrationBuilder.InsertData(
                table: "PeopleList",
                columns: new[] { "Id", "CityId", "LanguageId", "Name", "PhoneNumber" },
                values: new object[] { 3, 3, 0, "Niklas A", "846 346 836" });

            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguageListLanguageId", "PeopleListId" },
                values: new object[] { 1, 3 });

            migrationBuilder.InsertData(
                table: "LanguagePerson",
                columns: new[] { "LanguageListLanguageId", "PeopleListId" },
                values: new object[] { 2, 3 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguageListLanguageId", "PeopleListId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguageListLanguageId", "PeopleListId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguageListLanguageId", "PeopleListId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "LanguagePerson",
                keyColumns: new[] { "LanguageListLanguageId", "PeopleListId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "PeopleList",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CityList",
                keyColumn: "CityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CountryList",
                keyColumn: "CountryId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "PeopleList",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Ronnie Coleman");
        }
    }
}
