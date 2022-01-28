using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CountieAPI.Migrations
{
    public partial class changedplanner : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planners_Procedures_ProcedureId",
                table: "Planners");

            migrationBuilder.DropIndex(
                name: "IX_Planners_ProcedureId",
                table: "Planners");

            migrationBuilder.DropColumn(
                name: "ProcedureId",
                table: "Planners");

            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "Planners",
                newName: "Date");

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

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Planners",
                newName: "DateTime");

            migrationBuilder.AddColumn<int>(
                name: "ProcedureId",
                table: "Planners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Planners_ProcedureId",
                table: "Planners",
                column: "ProcedureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Planners_Procedures_ProcedureId",
                table: "Planners",
                column: "ProcedureId",
                principalTable: "Procedures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
