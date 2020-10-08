using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Api.Migrations
{
    public partial class InitialSlug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "ProjectPlatforms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Platforms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slug",
                table: "ProjectPlatforms");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Platforms");
        }
    }
}
