using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Web.DataLayer.Migrations
{
    public partial class User_Azmoon_Test_Answerhas3key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Azmoon_Test_Answer",
                table: "User_Azmoon_Test_Answer");

            migrationBuilder.AddColumn<int>(
                name: "id",
                table: "User_Azmoon_Test_Answer",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Azmoon_Test_Answer",
                table: "User_Azmoon_Test_Answer",
                columns: new[] { "AzmoonId", "TestQuestionId", "id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Azmoon_Test_Answer",
                table: "User_Azmoon_Test_Answer");

            migrationBuilder.DropColumn(
                name: "id",
                table: "User_Azmoon_Test_Answer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Azmoon_Test_Answer",
                table: "User_Azmoon_Test_Answer",
                columns: new[] { "AzmoonId", "TestQuestionId" });
        }
    }
}
