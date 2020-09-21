using Microsoft.EntityFrameworkCore.Migrations;

namespace memes.Migrations
{
    public partial class posts_tags_relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tag_Posts_PostId",
                table: "Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Tag_PostId",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Tag");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Tag",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tag",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "PostTagRelation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagRelation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTagRelation_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagRelation_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostTagRelation_PostId",
                table: "PostTagRelation",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagRelation_TagId",
                table: "PostTagRelation",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTagRelation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tag",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tag");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "Tag",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostId",
                table: "Tag",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tag",
                table: "Tag",
                column: "Value");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_PostId",
                table: "Tag",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tag_Posts_PostId",
                table: "Tag",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
