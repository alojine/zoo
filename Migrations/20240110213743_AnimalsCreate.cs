using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Zoo.Migrations
{
    /// <inheritdoc />
    public partial class AnimalsCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnclosureId = table.Column<int>(type: "int", nullable: false),
                    Species = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsVegetarian = table.Column<bool>(type: "bit", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Animals");
        }
    }
}
