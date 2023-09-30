using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackYeah.Migrations
{
    /// <inheritdoc />
    public partial class AddEncounterCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "encounter_category",
                table: "encounters",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "encounter_category",
                table: "encounters");
        }
    }
}
