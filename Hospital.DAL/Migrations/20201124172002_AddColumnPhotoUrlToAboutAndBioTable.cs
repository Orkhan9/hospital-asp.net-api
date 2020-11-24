using Microsoft.EntityFrameworkCore.Migrations;

namespace Hospital.DAL.Migrations
{
    public partial class AddColumnPhotoUrlToAboutAndBioTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Bios",
                newName: "LogoUrl");

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReplyToComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplyToComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReplyToComments_Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReplyToComments_CommentId",
                table: "ReplyToComments",
                column: "CommentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReplyToComments");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "LogoUrl",
                table: "Bios",
                newName: "Logo");
        }
    }
}
