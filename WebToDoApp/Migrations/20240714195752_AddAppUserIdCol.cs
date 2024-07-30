using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebToDoApp.Migrations
{
    /// <inheritdoc />
    public partial class AddAppUserIdCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplUserId",
                table: "ToDos",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ToDos_ApplUserId",
                table: "ToDos",
                column: "ApplUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ToDos_AspNetUsers_ApplUserId",
                table: "ToDos",
                column: "ApplUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ToDos_AspNetUsers_ApplUserId",
                table: "ToDos");

            migrationBuilder.DropIndex(
                name: "IX_ToDos_ApplUserId",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "ApplUserId",
                table: "ToDos");
        }
    }
}
