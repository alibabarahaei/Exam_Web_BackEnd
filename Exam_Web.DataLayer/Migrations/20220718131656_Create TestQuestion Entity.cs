using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Web.DataLayer.Migrations
{
    public partial class CreateTestQuestionEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestQuestions",
                columns: table => new
                {
                    TestQuestionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gozine1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gozine2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gozine3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gozine4 = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestQuestions", x => x.TestQuestionId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestQuestions");
        }
    }
}
