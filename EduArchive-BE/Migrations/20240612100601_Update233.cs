using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduArchive_BE.Migrations
{
    public partial class Update233 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LinkView",
                table: "documents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LinkView",
                table: "documents");
        }
    }
}
