using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MTG295NTermProject.Migrations
{
    /// <inheritdoc />
    public partial class test3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CardColor2",
                table: "Cards",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CardColor3",
                table: "Cards",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CardColor4",
                table: "Cards",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "CardColor5",
                table: "Cards",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardColor2",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardColor3",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardColor4",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardColor5",
                table: "Cards");
        }
    }
}
