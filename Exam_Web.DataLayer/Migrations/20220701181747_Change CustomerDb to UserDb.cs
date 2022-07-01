using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exam_Web.DataLayer.Migrations
{
    public partial class ChangeCustomerDbtoUserDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Customers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CustomerFamily",
                table: "Customers",
                newName: "Family");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Customers",
                newName: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Customers",
                newName: "CustomerName");

            migrationBuilder.RenameColumn(
                name: "Family",
                table: "Customers",
                newName: "CustomerFamily");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Customers",
                newName: "CustomerID");
        }
    }
}
