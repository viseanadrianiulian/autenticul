using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autenticul.Gaming.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddBetsActiveToEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BetsActive",
                table: "Events",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BetsActive",
                table: "Events");
        }
    }
}
