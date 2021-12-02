using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Proj.Migrations
{
    public partial class Final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    activityType = table.Column<string>(nullable: true),
                    mainInterest = table.Column<string>(nullable: true),
                    avgTimeSpent = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Musicians",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    songTitle = table.Column<string>(nullable: true),
                    artistName = table.Column<string>(nullable: true),
                    musicGenre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicians", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(nullable: true),
                    foodType = table.Column<string>(nullable: true),
                    founder = table.Column<string>(nullable: true),
                    foundingYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "id", "activityType", "avgTimeSpent", "mainInterest", "name" },
                values: new object[,]
                {
                    { 1, "Active", 4, "Graphical", "Designing" },
                    { 2, "Passive", 7, "Thrillers", "Reading" },
                    { 3, "Active", 2, "Soccer/Table Tennis", "Club Sports" }
                });

            migrationBuilder.InsertData(
                table: "Musicians",
                columns: new[] { "id", "artistName", "musicGenre", "songTitle" },
                values: new object[,]
                {
                    { 1, "Lovejoy", "Indie Rock", "Taunt" },
                    { 2, "The Crane Wives", "American Folk Rock", "Tongues & Teeth" },
                    { 3, "Scream Queen", "Screamo", "Pretty In Pink" }
                });

            migrationBuilder.InsertData(
                table: "Restaurants",
                columns: new[] { "id", "foodType", "founder", "foundingYear", "name" },
                values: new object[,]
                {
                    { 1, "Burgers", "Richard McDonald and Maurice McDonald", 1955, "McDonalds" },
                    { 2, "Burgers", "Dave Thomas", 1969, "Wendys" },
                    { 3, "Spaghetti", "Bill Darden", 1982, "Olive Garden" }
                });

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 2,
                column: "collegeProgram",
                value: "IT - Game Development");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "Musicians");

            migrationBuilder.DropTable(
                name: "Restaurants");

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "id",
                keyValue: 2,
                column: "collegeProgram",
                value: "IT -Game Development");
        }
    }
}
