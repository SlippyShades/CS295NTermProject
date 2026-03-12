using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTG295NTermProject.Migrations
{
    /// <inheritdoc />
    public partial class TypesAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardType2",
                table: "Cards",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CardType3",
                table: "Cards",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CreatureType2",
                table: "Cards",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CreatureType3",
                table: "Cards",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CreatureType4",
                table: "Cards",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardType2",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardType3",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CreatureType2",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CreatureType3",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CreatureType4",
                table: "Cards");
        }
    }
}
