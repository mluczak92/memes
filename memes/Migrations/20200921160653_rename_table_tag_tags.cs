using Microsoft.EntityFrameworkCore.Migrations;

namespace memes.Migrations
{
    public partial class rename_table_tag_tags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTagRelation_Tag_TagId",
                table: "PostTagRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.RenameTable(
                name: "Tag",
                newName: "Tags");

            migrationBuilder.RenameIndex(
                name: "IX_Tag_Value",
                table: "Tags",
                newName: "IX_Tags_Value");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tags",
                table: "Tags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTagRelation_Tags_TagId",
                table: "PostTagRelation",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTagRelation_Tags_TagId",
                table: "PostTagRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tags",
                table: "Tags");

            migrationBuilder.RenameTable(
                name: "Tags",
                newName: "Tag");

            migrationBuilder.RenameIndex(
                name: "IX_Tags_Value",
                table: "Tag",
                newName: "IX_Tag_Value");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PostTagRelation_Tag_TagId",
                table: "PostTagRelation",
                column: "TagId",
                principalTable: "Tag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
