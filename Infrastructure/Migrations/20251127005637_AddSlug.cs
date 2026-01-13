using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autenticul.Gaming.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddSlug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Summary",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Summary",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "Articles");
        }
    }
}
