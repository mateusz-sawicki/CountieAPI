using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CountieAPI.Migrations
{
    public partial class planneruserIdadd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Planners",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Planners_CreatedById",
                table: "Planners",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Planners_Users_CreatedById",
                table: "Planners",
                column: "CreatedById",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planners_Users_CreatedById",
                table: "Planners");

            migrationBuilder.DropIndex(
                name: "IX_Planners_CreatedById",
                table: "Planners");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Planners");
        }
    }
}
