using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Web.DataLayer.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Azmoon_Test_Answer",
                table: "User_Azmoon_Test_Answer");

            migrationBuilder.DropIndex(
                name: "IX_User_Azmoon_Test_Answer_AzmoonId",
                table: "User_Azmoon_Test_Answer");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "User_Azmoon_Test_Answer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Azmoon_Test_Answer",
                table: "User_Azmoon_Test_Answer",
                columns: new[] { "AzmoonId", "TestQuestionId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User_Azmoon_Test_Answer",
                table: "User_Azmoon_Test_Answer");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "User_Azmoon_Test_Answer",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User_Azmoon_Test_Answer",
                table: "User_Azmoon_Test_Answer",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_User_Azmoon_Test_Answer_AzmoonId",
                table: "User_Azmoon_Test_Answer",
                column: "AzmoonId");
        }
    }
}
