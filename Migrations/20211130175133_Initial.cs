using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Proj.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fullName = table.Column<string>(nullable: true),
                    birthDate = table.Column<string>(nullable: true),
                    collegeProgram = table.Column<string>(nullable: true),
                    collegeYear = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "id", "birthDate", "collegeProgram", "collegeYear", "fullName" },
                values: new object[] { 1, "04/18/2001", "IT - Software Application", "Junior", "Chloe Motz" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "id", "birthDate", "collegeProgram", "collegeYear", "fullName" },
                values: new object[] { 2, "12/28/2001", "IT -Game Development", "Sophomore", "Logan Arnett" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "id", "birthDate", "collegeProgram", "collegeYear", "fullName" },
                values: new object[] { 3, "01/22/2002", "IT - Software Development and Technologies Track", "Sophomore", "Srishant Burdhan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
