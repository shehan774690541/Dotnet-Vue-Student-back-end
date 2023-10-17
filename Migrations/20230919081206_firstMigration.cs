using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learnMySQL.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "contact_number",
                table: "students",
                newName: "phone_number");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phone_number",
                table: "students",
                newName: "contact_number");
        }
    }
}
