using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CountieAPI.Migrations
{
    public partial class plannerchange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PlannerId",
                table: "Procedures",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Procedures_PlannerId",
                table: "Procedures",
                column: "PlannerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Procedures_Planners_PlannerId",
                table: "Procedures",
                column: "PlannerId",
                principalTable: "Planners",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Procedures_Planners_PlannerId",
                table: "Procedures");

            migrationBuilder.DropIndex(
                name: "IX_Procedures_PlannerId",
                table: "Procedures");

            migrationBuilder.DropColumn(
                name: "PlannerId",
                table: "Procedures");
        }
    }
}
