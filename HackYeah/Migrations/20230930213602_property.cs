using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HackYeah.Migrations
{
    /// <inheritdoc />
    public partial class property : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "encounter_type_property",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value_type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encounter_type_property", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "encounter_type_properties_encounter_types",
                columns: table => new
                {
                    encounter_type_id = table.Column<Guid>(type: "uuid", nullable: false),
                    encounter_type_property_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_encounter_type_properties_encounter_types", x => new { x.encounter_type_id, x.encounter_type_property_id });
                    table.ForeignKey(
                        name: "fk_encounter_type_properties_encounter_types_encounter_type_en",
                        column: x => x.encounter_type_id,
                        principalTable: "encounter_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_encounter_type_properties_encounter_types_encounter_type_pr",
                        column: x => x.encounter_type_property_id,
                        principalTable: "encounter_type_property",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "encounter_type_property",
                columns: new[] { "id", "name", "value_type" },
                values: new object[,]
                {
                    { new Guid("275e942d-8b0a-4c35-8fcf-88649ad67586"), "Kolor", 2 },
                    { new Guid("5b1c7bf6-93eb-4ecb-8d3d-5b588d931750"), "Czy jest w stadzie", 4 },
                    { new Guid("6e81da60-5186-4983-a180-a0a357fb41f3"), "Zachowanie", 6 },
                    { new Guid("8d5ac209-3639-485d-8432-e01ffea199cb"), "Wielkość", 3 },
                    { new Guid("bb8bcc84-164b-4978-a183-05ff505d096e"), "Obroża", 1 },
                    { new Guid("cb02f908-881a-47cc-85ab-1428d1816a43"), "Czy jest z młodymi", 5 },
                    { new Guid("db69c2dd-da68-43b8-9194-19176be90b62"), "Rasa", 0 }
                });

            migrationBuilder.InsertData(
                table: "encounter_type_properties_encounter_types",
                columns: new[] { "encounter_type_id", "encounter_type_property_id" },
                values: new object[,]
                {
                    { new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"), new Guid("275e942d-8b0a-4c35-8fcf-88649ad67586") },
                    { new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"), new Guid("6e81da60-5186-4983-a180-a0a357fb41f3") },
                    { new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"), new Guid("8d5ac209-3639-485d-8432-e01ffea199cb") },
                    { new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"), new Guid("bb8bcc84-164b-4978-a183-05ff505d096e") },
                    { new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"), new Guid("db69c2dd-da68-43b8-9194-19176be90b62") },
                    { new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"), new Guid("275e942d-8b0a-4c35-8fcf-88649ad67586") },
                    { new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"), new Guid("6e81da60-5186-4983-a180-a0a357fb41f3") },
                    { new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"), new Guid("bb8bcc84-164b-4978-a183-05ff505d096e") },
                    { new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"), new Guid("db69c2dd-da68-43b8-9194-19176be90b62") }
                });

            migrationBuilder.CreateIndex(
                name: "ix_encounter_type_properties_encounter_types_encounter_type_pr",
                table: "encounter_type_properties_encounter_types",
                column: "encounter_type_property_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "encounter_type_properties_encounter_types");

            migrationBuilder.DropTable(
                name: "encounter_type_property");
        }
    }
}
