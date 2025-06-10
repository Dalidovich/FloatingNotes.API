using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloatingNotes.API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "floating_notes",
                columns: table => new
                {
                    pk_floating_note_id = table.Column<Guid>(type: "uuid", nullable: false),
                    content = table.Column<string>(type: "character varying", nullable: false),
                    title = table.Column<string>(type: "character varying", nullable: false),
                    ai_title = table.Column<string>(type: "character varying", nullable: false),
                    ai_content = table.Column<string>(type: "character varying", nullable: false),
                    number = table.Column<short>(type: "smallint", nullable: false),
                    type = table.Column<short>(type: "smallint", nullable: false),
                    create_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    status = table.Column<short>(type: "smallint", nullable: false),
                    is_included_in_response_processing = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_floating_notes", x => x.pk_floating_note_id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_floating_notes_title",
                table: "floating_notes",
                column: "title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "floating_notes");
        }
    }
}
