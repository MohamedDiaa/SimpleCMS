using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMS.Migrations
{
    /// <inheritdoc />
    public partial class addrelationship2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b4f0866-4436-43da-a361-6f19fe6c8eba");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1302f7cb-baee-470a-8860-50cdbf2d128e", 0, "672dad83-ff9f-4113-88f1-8cc24e120e12", "mdalwakil@outlook.com", false, false, null, null, null, "xxxxxxx", null, false, "971f4800-3b89-42f8-93d4-3b04bf967350", false, "Mohamed Alwakil" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1302f7cb-baee-470a-8860-50cdbf2d128e");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1b4f0866-4436-43da-a361-6f19fe6c8eba", 0, "d659962d-8aa7-4c2b-8543-ab4daf14216c", "mdalwakil@outlook.com", false, false, null, null, null, "xxxxxxx", null, false, "c863e8b6-c208-46cc-9632-9fcec174b83f", false, "Mohamed Alwakil" });
        }
    }
}
