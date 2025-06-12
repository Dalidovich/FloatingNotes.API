using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FloatingNotes.API.DAL.Migrations
{
    /// <inheritdoc />
    public partial class connectedNote : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "connected_floating_notes",
                columns: table => new
                {
                    master_floating_note_id = table.Column<Guid>(type: "uuid", nullable: false),
                    connected_floating_note_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_connected_floating_notes", x => new { x.master_floating_note_id, x.connected_floating_note_id });
                    table.ForeignKey(
                        name: "FK_connected_floating_notes_floating_notes_connected_floating_~",
                        column: x => x.connected_floating_note_id,
                        principalTable: "floating_notes",
                        principalColumn: "pk_floating_note_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_connected_floating_notes_floating_notes_master_floating_not~",
                        column: x => x.master_floating_note_id,
                        principalTable: "floating_notes",
                        principalColumn: "pk_floating_note_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_connected_floating_notes_connected_floating_note_id",
                table: "connected_floating_notes",
                column: "connected_floating_note_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "connected_floating_notes");
        }
    }
}
