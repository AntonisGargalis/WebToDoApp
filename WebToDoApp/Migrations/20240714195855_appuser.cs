using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebToDoApp.Migrations
{
    /// <inheritdoc />
    public partial class appuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_AspNetUsers_ApplUserId",
                table: "ToDos");

            migrationBuilder.RenameColumn(
                name: "ApplUserId",
                table: "ToDos",
                newName: "AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDos_ApplUserId",
                table: "ToDos",
                newName: "IX_ToDos_AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_AspNetUsers_AppUserId",
                table: "ToDos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_AspNetUsers_AppUserId",
                table: "ToDos");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "ToDos",
                newName: "ApplUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ToDos_AppUserId",
                table: "ToDos",
                newName: "IX_ToDos_ApplUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_AspNetUsers_ApplUserId",
                table: "ToDos",
                column: "ApplUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
