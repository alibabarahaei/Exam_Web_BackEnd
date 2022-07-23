using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Web.DataLayer.Migrations
{
    public partial class User_Azmoon_Test_AnswerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AzmoonUserIdentity");

            migrationBuilder.CreateTable(
                name: "User_Azmoon_Test_Answer",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AzmoonId = table.Column<long>(type: "bigint", nullable: false),
                    TestQuestionId = table.Column<int>(type: "int", nullable: false),
                    UserIdentityId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Azmoon_Test_Answer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Azmoon_Test_Answer_AspNetUsers_UserIdentityId",
                        column: x => x.UserIdentityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Azmoon_Test_Answer_Azmoons_AzmoonId",
                        column: x => x.AzmoonId,
                        principalTable: "Azmoons",
                        principalColumn: "AzmoonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_Azmoon_Test_Answer_TestQuestions_TestQuestionId",
                        column: x => x.TestQuestionId,
                        principalTable: "TestQuestions",
                        principalColumn: "TestQuestionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_Azmoon_Test_Answer_AzmoonId",
                table: "User_Azmoon_Test_Answer",
                column: "AzmoonId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Azmoon_Test_Answer_TestQuestionId",
                table: "User_Azmoon_Test_Answer",
                column: "TestQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Azmoon_Test_Answer_UserIdentityId",
                table: "User_Azmoon_Test_Answer",
                column: "UserIdentityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User_Azmoon_Test_Answer");

            migrationBuilder.CreateTable(
                name: "AzmoonUserIdentity",
                columns: table => new
                {
                    AzmoonsAzmoonId = table.Column<long>(type: "bigint", nullable: false),
                    UsersId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AzmoonUserIdentity", x => new { x.AzmoonsAzmoonId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_AzmoonUserIdentity_AspNetUsers_UsersId",
                        column: x => x.UsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AzmoonUserIdentity_Azmoons_AzmoonsAzmoonId",
                        column: x => x.AzmoonsAzmoonId,
                        principalTable: "Azmoons",
                        principalColumn: "AzmoonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AzmoonUserIdentity_UsersId",
                table: "AzmoonUserIdentity",
                column: "UsersId");
        }
    }
}
