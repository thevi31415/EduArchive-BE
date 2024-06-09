using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EduArchive_BE.Migrations
{
    public partial class Update344 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "documents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameAuthor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdAuthor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkDownload = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    View = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    YearSchool = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdSubject = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameSubject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdChool = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NameSchool = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Like = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_documents", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "documents");
        }
    }
}
