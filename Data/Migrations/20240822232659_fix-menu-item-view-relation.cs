using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMS.Migrations
{
    /// <inheritdoc />
    public partial class fixmenuitemviewrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_View_ViewId",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_ViewId",
                table: "MenuItem");

            migrationBuilder.CreateIndex(
                name: "IX_View_MenuItemId",
                table: "View",
                column: "MenuItemId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_View_MenuItem_MenuItemId",
                table: "View",
                column: "MenuItemId",
                principalTable: "MenuItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_View_MenuItem_MenuItemId",
                table: "View");

            migrationBuilder.DropIndex(
                name: "IX_View_MenuItemId",
                table: "View");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_ViewId",
                table: "MenuItem",
                column: "ViewId",
                unique: true,
                filter: "[ViewId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_View_ViewId",
                table: "MenuItem",
                column: "ViewId",
                principalTable: "View",
                principalColumn: "Id");
        }
    }
}
