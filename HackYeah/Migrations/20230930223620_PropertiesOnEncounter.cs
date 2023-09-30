using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackYeah.Migrations
{
    /// <inheritdoc />
    public partial class PropertiesOnEncounter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "encounter_property",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    encounter_type_property_id = table.Column<Guid>(type: "uuid", nullable: false),
                    value = table.Column<string>(type: "text", nullable: false),
                    encounter_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encounter_property", x => x.id);
                    table.ForeignKey(
                        name: "fk_encounter_property_encounter_type_property_encounter_type_p",
                        column: x => x.encounter_type_property_id,
                        principalTable: "encounter_type_property",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_encounter_property_encounters_encounter_id",
                        column: x => x.encounter_id,
                        principalTable: "encounters",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_encounter_property_encounter_id",
                table: "encounter_property",
                column: "encounter_id");

            migrationBuilder.CreateIndex(
                name: "ix_encounter_property_encounter_type_property_id",
                table: "encounter_property",
                column: "encounter_type_property_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "encounter_property");
        }
    }
}
