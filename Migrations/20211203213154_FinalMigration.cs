using Microsoft.EntityFrameworkCore.Migrations;

namespace Final_Proj.Migrations
{
    public partial class FinalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "songYear",
                table: "Musicians",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Musicians",
                keyColumn: "id",
                keyValue: 1,
                column: "songYear",
                value: "2021");

            migrationBuilder.UpdateData(
                table: "Musicians",
                keyColumn: "id",
                keyValue: 2,
                column: "songYear",
                value: "2012");

            migrationBuilder.UpdateData(
                table: "Musicians",
                keyColumn: "id",
                keyValue: 3,
                column: "songYear",
                value: "2021");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "songYear",
                table: "Musicians");
        }
    }
}
