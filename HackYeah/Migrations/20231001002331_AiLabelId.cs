using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackYeah.Migrations
{
    /// <inheritdoc />
    public partial class AiLabelId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ai_label_id",
                table: "encounter_type",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "encounter_type",
                keyColumn: "id",
                keyValue: new Guid("13c2ca92-6a13-482a-8e0e-62bd6682127b"),
                column: "ai_label_id",
                value: 18);

            migrationBuilder.UpdateData(
                table: "encounter_type",
                keyColumn: "id",
                keyValue: new Guid("cdca0436-2ca1-4cde-8581-b6917333b84f"),
                column: "ai_label_id",
                value: 7);

            migrationBuilder.UpdateData(
                table: "encounter_type",
                keyColumn: "id",
                keyValue: new Guid("d7e923a8-6781-41b0-9929-005d8b0f01d5"),
                column: "ai_label_id",
                value: 9);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ai_label_id",
                table: "encounter_type");
        }
    }
}
