using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autenticul.Gaming.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddIsFinishedToBet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFinished",
                table: "Bets",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFinished",
                table: "Bets");
        }
    }
}
