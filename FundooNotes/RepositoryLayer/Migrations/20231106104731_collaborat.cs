using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class collaborat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "collaborat",
                columns: table => new
                {
                    collaboratId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    collaboratEmail = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false),
                    NoteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_collaborat", x => x.collaboratId);
                    table.ForeignKey(
                        name: "FK_collaborat_Note_NoteId",
                        column: x => x.NoteId,
                        principalTable: "Note",
                        principalColumn: "NoteId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_collaborat_user_UserId",
                        column: x => x.Id,
                        principalTable: "user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_collaborat_NoteId",
                table: "collaborat",
                column: "NoteId");

            migrationBuilder.CreateIndex(
                name: "IX_collaborat_UserId",
                table: "collaborat",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "collaborat");
        }
    }
}
