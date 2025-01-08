using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Autenticul.Gaming.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddStreamerEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Streamers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interests = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UsualHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeChannel1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeChannel1Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeChannel2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YoutubeChannel2Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitchChannel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TwitchUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstagramName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InstagramUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacebookUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiktokName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TiktokUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Streamers", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Streamers");
        }
    }
}
