using Microsoft.EntityFrameworkCore.Migrations;

namespace ResumeMangaer.Migrations
{
    public partial class Profilephoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoUlr",
                table: "Applicants",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhotoUlr",
                table: "Applicants");
        }
    }
}
