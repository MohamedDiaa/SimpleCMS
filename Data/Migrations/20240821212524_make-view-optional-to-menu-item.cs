using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SimpleCMS.Migrations
{
    /// <inheritdoc />
    public partial class makeviewoptionaltomenuitem : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "ViewId",
                table: "MenuItem",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuItem_View_ViewId",
                table: "MenuItem");

            migrationBuilder.DropIndex(
                name: "IX_MenuItem_ViewId",
                table: "MenuItem");

            migrationBuilder.AlterColumn<int>(
                name: "ViewId",
                table: "MenuItem",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_ViewId",
                table: "MenuItem",
                column: "ViewId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuItem_View_ViewId",
                table: "MenuItem",
                column: "ViewId",
                principalTable: "View",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
