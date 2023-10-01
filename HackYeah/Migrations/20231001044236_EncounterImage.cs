using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackYeah.Migrations
{
    /// <inheritdoc />
    public partial class EncounterImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "encounter_images",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    mime_type = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    encounter_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encounter_images", x => x.id);
                    table.ForeignKey(
                        name: "fk_encounter_images_encounters_encounter_id",
                        column: x => x.encounter_id,
                        principalTable: "encounters",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_encounter_images_encounter_id",
                table: "encounter_images",
                column: "encounter_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "encounter_images");
        }
    }
}
