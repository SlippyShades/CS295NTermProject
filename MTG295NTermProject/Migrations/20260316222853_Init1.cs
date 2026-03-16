using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace MTG295NTermProject.Migrations
{
    /// <inheritdoc />
    public partial class Init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    PriceUSD = table.Column<double>(type: "double", nullable: true),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: true),
                    CardName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    ManaCost = table.Column<int>(type: "int", nullable: false),
                    CardType = table.Column<int>(type: "int", nullable: false),
                    CardType2 = table.Column<string>(type: "longtext", nullable: true),
                    CardType3 = table.Column<string>(type: "longtext", nullable: true),
                    CardColor = table.Column<int>(type: "int", nullable: false),
                    CardColor2 = table.Column<string>(type: "longtext", nullable: true),
                    CardColor3 = table.Column<string>(type: "longtext", nullable: true),
                    CardColor4 = table.Column<string>(type: "longtext", nullable: true),
                    CardColor5 = table.Column<string>(type: "longtext", nullable: true),
                    OracleText = table.Column<string>(type: "longtext", nullable: false),
                    Legendary = table.Column<string>(type: "longtext", nullable: true),
                    Kindred = table.Column<string>(type: "longtext", nullable: true),
                    CreatureType = table.Column<string>(type: "longtext", nullable: true),
                    CreatureType2 = table.Column<string>(type: "longtext", nullable: true),
                    CreatureType3 = table.Column<string>(type: "longtext", nullable: true),
                    CreatureType4 = table.Column<string>(type: "longtext", nullable: true),
                    Toughness = table.Column<string>(type: "longtext", nullable: true),
                    Power = table.Column<string>(type: "longtext", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardModelId);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WantedCards",
                columns: table => new
                {
                    CardName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WantedCards", x => x.CardName);
                })
                .Annotation("MySQL:Charset", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "WantedCards");
        }
    }
}
