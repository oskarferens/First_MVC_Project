using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace First_MVC_App.Migrations
{
    public partial class AddedsomeRolesandDefoultAdminaccount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "220a0a10-1588-4901-82aa-8f37b188344e", "5d252606-e506-4e85-ba73-43c86cb4bf3b", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bb64209f-468e-42b0-b53b-f1eb72ad0f4a", "8624d768-d76d-4e2f-88db-9457455a18b7", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "CheckAdmin", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8084583c-f695-40d1-8d3d-c041c23d0fa5", 0, "1995-01-01", false, "fe2b2f09-e6f3-4a4a-a439-692b41685e68", "admin@admin.com", false, "Mark", "SockerBerg", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEML1mplk7j9f5cNuMoICoknX2DbjTj3KES41wsmZjuZcu9fdkA+e6djUn80o1LHjlQ==", null, false, "2db440f3-425b-4d1c-9d13-e20d71e2d541", false, "admin@admin.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "220a0a10-1588-4901-82aa-8f37b188344e", "8084583c-f695-40d1-8d3d-c041c23d0fa5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bb64209f-468e-42b0-b53b-f1eb72ad0f4a");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "220a0a10-1588-4901-82aa-8f37b188344e", "8084583c-f695-40d1-8d3d-c041c23d0fa5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "220a0a10-1588-4901-82aa-8f37b188344e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8084583c-f695-40d1-8d3d-c041c23d0fa5");
        }
    }
}
