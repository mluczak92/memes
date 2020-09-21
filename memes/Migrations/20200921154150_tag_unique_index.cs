using Microsoft.EntityFrameworkCore.Migrations;

namespace memes.Migrations
{
    public partial class tag_unique_index : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Tag",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tag_Value",
                table: "Tag",
                column: "Value",
                unique: true,
                filter: "[Value] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Tag_Value",
                table: "Tag");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
