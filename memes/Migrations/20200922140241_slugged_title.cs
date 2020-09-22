using Microsoft.EntityFrameworkCore.Migrations;

namespace memes.Migrations
{
    public partial class slugged_title : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SluggedTitle",
                table: "Posts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SluggedTitle",
                table: "Posts");
        }
    }
}
