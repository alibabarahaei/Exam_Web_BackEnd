using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Web.DataLayer.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AzmoonTestQuestion",
                columns: table => new
                {
                    AzmoonsAzmoonId = table.Column<long>(type: "bigint", nullable: false),
                    TestQuestionsTestQuestionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AzmoonTestQuestion", x => new { x.AzmoonsAzmoonId, x.TestQuestionsTestQuestionId });
                    table.ForeignKey(
                        name: "FK_AzmoonTestQuestion_Azmoons_AzmoonsAzmoonId",
                        column: x => x.AzmoonsAzmoonId,
                        principalTable: "Azmoons",
                        principalColumn: "AzmoonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AzmoonTestQuestion_TestQuestions_TestQuestionsTestQuestionId",
                        column: x => x.TestQuestionsTestQuestionId,
                        principalTable: "TestQuestions",
                        principalColumn: "TestQuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AzmoonTestQuestion_TestQuestionsTestQuestionId",
                table: "AzmoonTestQuestion",
                column: "TestQuestionsTestQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AzmoonTestQuestion");
        }
    }
}
