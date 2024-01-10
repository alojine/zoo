using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoo.Migrations
{
    /// <inheritdoc />
    public partial class ChangeEnclosuresToIsOutside : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Enclosures");

            migrationBuilder.AddColumn<bool>(
                name: "isOutside",
                table: "Enclosures",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isOutside",
                table: "Enclosures");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Enclosures",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
