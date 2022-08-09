using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Web.DataLayer.Migrations
{
    public partial class AddanswertoUser_Azmoon_Test_Answer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Azmoon_Test_Answer_AspNetUsers_UserIdentityId",
                table: "User_Azmoon_Test_Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Azmoon_Test_Answer_Azmoons_AzmoonId",
                table: "User_Azmoon_Test_Answer");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Azmoon_Test_Answer_TestQuestions_TestQuestionId",
                table: "User_Azmoon_Test_Answer");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Azmoon_Test_Answer",
                table: "User_Azmoon_Test_Answer");

            migrationBuilder.RenameTable(
                name: "User_Azmoon_Test_Answer",
                newName: "User_Azmoon_Test_Answers");

            migrationBuilder.RenameIndex(
                name: "IX_User_Azmoon_Test_Answer_UserIdentityId",
                table: "User_Azmoon_Test_Answers",
                newName: "IX_User_Azmoon_Test_Answers_UserIdentityId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Azmoon_Test_Answer_TestQuestionId",
                table: "User_Azmoon_Test_Answers",
                newName: "IX_User_Azmoon_Test_Answers_TestQuestionId");

            migrationBuilder.AddColumn<int>(
                name: "Answer",
                table: "User_Azmoon_Test_Answers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Azmoon_Test_Answers",
                table: "User_Azmoon_Test_Answers",
                columns: new[] { "AzmoonId", "TestQuestionId", "UserIdentityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Azmoon_Test_Answers_AspNetUsers_UserIdentityId",
                table: "User_Azmoon_Test_Answers",
                column: "UserIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Azmoon_Test_Answers_Azmoons_AzmoonId",
                table: "User_Azmoon_Test_Answers",
                column: "AzmoonId",
                principalTable: "Azmoons",
                principalColumn: "AzmoonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Azmoon_Test_Answers_TestQuestions_TestQuestionId",
                table: "User_Azmoon_Test_Answers",
                column: "TestQuestionId",
                principalTable: "TestQuestions",
                principalColumn: "TestQuestionId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Azmoon_Test_Answers_AspNetUsers_UserIdentityId",
                table: "User_Azmoon_Test_Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Azmoon_Test_Answers_Azmoons_AzmoonId",
                table: "User_Azmoon_Test_Answers");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Azmoon_Test_Answers_TestQuestions_TestQuestionId",
                table: "User_Azmoon_Test_Answers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Azmoon_Test_Answers",
                table: "User_Azmoon_Test_Answers");

            migrationBuilder.DropColumn(
                name: "Answer",
                table: "User_Azmoon_Test_Answers");

            migrationBuilder.RenameTable(
                name: "User_Azmoon_Test_Answers",
                newName: "User_Azmoon_Test_Answer");

            migrationBuilder.RenameIndex(
                name: "IX_User_Azmoon_Test_Answers_UserIdentityId",
                table: "User_Azmoon_Test_Answer",
                newName: "IX_User_Azmoon_Test_Answer_UserIdentityId");

            migrationBuilder.RenameIndex(
                name: "IX_User_Azmoon_Test_Answers_TestQuestionId",
                table: "User_Azmoon_Test_Answer",
                newName: "IX_User_Azmoon_Test_Answer_TestQuestionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Azmoon_Test_Answer",
                table: "User_Azmoon_Test_Answer",
                columns: new[] { "AzmoonId", "TestQuestionId", "UserIdentityId" });

            migrationBuilder.AddForeignKey(
                name: "FK_User_Azmoon_Test_Answer_AspNetUsers_UserIdentityId",
                table: "User_Azmoon_Test_Answer",
                column: "UserIdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Azmoon_Test_Answer_Azmoons_AzmoonId",
                table: "User_Azmoon_Test_Answer",
                column: "AzmoonId",
                principalTable: "Azmoons",
                principalColumn: "AzmoonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Azmoon_Test_Answer_TestQuestions_TestQuestionId",
                table: "User_Azmoon_Test_Answer",
                column: "TestQuestionId",
                principalTable: "TestQuestions",
                principalColumn: "TestQuestionId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
