using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Web.DataLayer.Migrations
{
    public partial class recreatedb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "SubTitle",
                table: "TestQuestions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Azmoons",
                columns: table => new
                {
                    AzmoonId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    UsedTime = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Azmoons", x => x.AzmoonId);
                });

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
                name: "IX_AzmoonTestQuestion_TestQuestionsTestQuestionId",
                table: "AzmoonTestQuestion",
                column: "TestQuestionsTestQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AzmoonUserIdentity_UsersId",
                table: "AzmoonUserIdentity",
                column: "UsersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AzmoonTestQuestion");

            migrationBuilder.DropTable(
                name: "AzmoonUserIdentity");

            migrationBuilder.DropTable(
                name: "Azmoons");

            migrationBuilder.AlterColumn<string>(
                name: "SubTitle",
                table: "TestQuestions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });
        }
    }
}
