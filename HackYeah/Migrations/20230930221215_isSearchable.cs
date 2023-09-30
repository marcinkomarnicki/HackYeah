using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HackYeah.Migrations
{
    /// <inheritdoc />
    public partial class isSearchable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_searchable",
                table: "encounter_type",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "encounter_type",
                keyColumn: "id",
                keyValue: new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"),
                column: "is_searchable",
                value: true);

            migrationBuilder.UpdateData(
                table: "encounter_type",
                keyColumn: "id",
                keyValue: new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"),
                column: "is_searchable",
                value: true);

            migrationBuilder.InsertData(
                table: "encounter_type",
                columns: new[] { "id", "code", "is_searchable" },
                values: new object[] { new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"), "Dzik", false });

            migrationBuilder.InsertData(
                table: "encounter_type_properties_encounter_types",
                columns: new[] { "encounter_type_id", "encounter_type_property_id" },
                values: new object[,]
                {
                    { new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"), new Guid("5b1c7bf6-93eb-4ecb-8d3d-5b588d931750") },
                    { new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"), new Guid("6e81da60-5186-4983-a180-a0a357fb41f3") },
                    { new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"), new Guid("cb02f908-881a-47cc-85ab-1428d1816a43") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "encounter_type_properties_encounter_types",
                keyColumns: new[] { "encounter_type_id", "encounter_type_property_id" },
                keyValues: new object[] { new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"), new Guid("5b1c7bf6-93eb-4ecb-8d3d-5b588d931750") });

            migrationBuilder.DeleteData(
                table: "encounter_type_properties_encounter_types",
                keyColumns: new[] { "encounter_type_id", "encounter_type_property_id" },
                keyValues: new object[] { new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"), new Guid("6e81da60-5186-4983-a180-a0a357fb41f3") });

            migrationBuilder.DeleteData(
                table: "encounter_type_properties_encounter_types",
                keyColumns: new[] { "encounter_type_id", "encounter_type_property_id" },
                keyValues: new object[] { new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"), new Guid("cb02f908-881a-47cc-85ab-1428d1816a43") });

            migrationBuilder.DeleteData(
                table: "encounter_type",
                keyColumn: "id",
                keyValue: new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"));

            migrationBuilder.DropColumn(
                name: "is_searchable",
                table: "encounter_type");
        }
    }
}
