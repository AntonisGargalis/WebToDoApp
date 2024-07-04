using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebToDoApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTimeCol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeOnly>(
                name: "TimePick",
                table: "ToDos",
                type: "time",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimePick",
                table: "ToDos");
        }
    }
}
