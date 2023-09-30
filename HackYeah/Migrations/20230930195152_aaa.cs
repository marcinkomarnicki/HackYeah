using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HackYeah.Migrations
{
    /// <inheritdoc />
    public partial class aaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "encounter_category",
                table: "encounters");

            migrationBuilder.AddColumn<bool>(
                name: "is_wild",
                table: "encounters",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_wild",
                table: "encounters");

            migrationBuilder.AddColumn<int>(
                name: "encounter_category",
                table: "encounters",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
