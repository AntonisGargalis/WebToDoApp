using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebToDoApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateOnly>(
                name: "DatePick",
                table: "ToDos",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePick",
                table: "ToDos");
        }
    }
}
