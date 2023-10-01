using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackYeah.Migrations
{
    /// <inheritdoc />
    public partial class MissingPetRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "missing_pets_reports",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    encounter_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    rase = table.Column<string>(type: "text", nullable: false),
                    pet_name = table.Column<string>(type: "text", nullable: false),
                    reporter_name = table.Column<string>(type: "text", nullable: false),
                    telephone_number = table.Column<string>(type: "text", nullable: false),
                    longitude_report = table.Column<string>(type: "text", nullable: false),
                    latitude_report = table.Column<string>(type: "text", nullable: false),
                    has_collar = table.Column<bool>(type: "boolean", nullable: false),
                    special_features = table.Column<string>(type: "text", nullable: false),
                    color = table.Column<string>(type: "text", nullable: false),
                    pet_size = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_missing_pets_reports", x => x.id);
                    table.ForeignKey(
                        name: "fk_missing_pets_reports_encounter_type_encounter_type_id",
                        column: x => x.encounter_type_id,
                        principalTable: "encounter_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_missing_pets_reports_encounter_type_id",
                table: "missing_pets_reports",
                column: "encounter_type_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "missing_pets_reports");
        }
    }
}
