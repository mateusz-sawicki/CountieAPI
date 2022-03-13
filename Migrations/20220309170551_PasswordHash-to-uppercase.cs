using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CountieAPI.Migrations
{
    public partial class PasswordHashtouppercase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "passwordHash",
                table: "Users",
                newName: "PasswordHash");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "Users",
                newName: "passwordHash");
        }
    }
}
