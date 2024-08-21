using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMS.Migrations
{
    /// <inheritdoc />
    public partial class updaterelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1302f7cb-baee-470a-8860-50cdbf2d128e");

            migrationBuilder.AddColumn<int>(
                name: "ViewId",
                table: "MenuItem",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "View",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_View", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContentBlock",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    ViewId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContentBlock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContentBlock_View_ViewId",
                        column: x => x.ViewId,
                        principalTable: "View",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_ViewId",
                table: "MenuItem",
                column: "ViewId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ContentBlock_ViewId",
                table: "ContentBlock",
                column: "ViewId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_View_ViewId",
                table: "MenuItem",
                column: "ViewId",
                principalTable: "View",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_View_ViewId",
                table: "MenuItem");

            migrationBuilder.DropTable(
                name: "ContentBlock");

            migrationBuilder.DropTable(
                name: "View");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_ViewId",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "ViewId",
                table: "MenuItem");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1302f7cb-baee-470a-8860-50cdbf2d128e", 0, "672dad83-ff9f-4113-88f1-8cc24e120e12", "mdalwakil@outlook.com", false, false, null, null, null, "xxxxxxx", null, false, "971f4800-3b89-42f8-93d4-3b04bf967350", false, "Mohamed Alwakil" });
        }
    }
}
