using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMS.Migrations
{
    /// <inheritdoc />
    public partial class removeuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ca4e8c8c-030b-452c-8575-7dd1cef79ad6");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ca4e8c8c-030b-452c-8575-7dd1cef79ad6", 0, "4df46381-7332-44a7-89f8-188ddf927dbc", "mdalwakil@outlook.com", true, false, null, null, null, "AQAAAAIAAYagAAAAEPgqnfaenqevPxZoUUNfay2nKhn8zKEa/CC+nnnEp/0Zflm21Ddg2TACfyX0ImzLNQ==", null, false, "cf770a14-4805-4816-a3aa-093e7b61efbc", false, "Mohamed Alwakil" });
        }
    }
}
