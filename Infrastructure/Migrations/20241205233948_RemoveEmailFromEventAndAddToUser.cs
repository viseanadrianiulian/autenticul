using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autenticul.Gaming.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveEmailFromEventAndAddToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
