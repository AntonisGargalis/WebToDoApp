using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebToDoApp.Migrations
{
    /// <inheritdoc />
    public partial class delete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_AspNetUsers_AppUserId",
                table: "ToDos");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_AppUserId",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ToDos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "ToDos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_AppUserId",
                table: "ToDos",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_AspNetUsers_AppUserId",
                table: "ToDos",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
