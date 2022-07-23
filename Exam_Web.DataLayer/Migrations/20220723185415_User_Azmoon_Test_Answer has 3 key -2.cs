using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Web.DataLayer.Migrations
{
    public partial class User_Azmoon_Test_Answerhas3key2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Azmoon_Test_Answer",
                table: "User_Azmoon_Test_Answer");

            migrationBuilder.DropColumn(
                name: "id",
                table: "User_Azmoon_Test_Answer");

            migrationBuilder.AlterColumn<string>(
                name: "UserIdentityId",
                table: "User_Azmoon_Test_Answer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Azmoon_Test_Answer",
                table: "User_Azmoon_Test_Answer",
                columns: new[] { "AzmoonId", "TestQuestionId", "UserIdentityId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Azmoon_Test_Answer",
                table: "User_Azmoon_Test_Answer");

            migrationBuilder.AlterColumn<string>(
                name: "UserIdentityId",
                table: "User_Azmoon_Test_Answer",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
    }
}
