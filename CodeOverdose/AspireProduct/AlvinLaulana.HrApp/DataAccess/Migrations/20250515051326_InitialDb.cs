using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AlvinLaulana.HrApp.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Age", "DateOfBirth", "Department", "FullName", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 33, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "John Doe", "1234567890" },
                    { 2, 38, new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR", "Jane Smith", "0987654321" },
                    { 3, 31, new DateTime(1992, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finance", "Alice Johnson", "5551234567" },
                    { 4, 32, new DateTime(1991, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "Diana Evans", "2223456789" },
                    { 5, 30, new DateTime(1993, 4, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finance", "Fiona Harris", "6661234567" },
                    { 6, 36, new DateTime(1987, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR", "Ethan Green", "1112345678" },
                    { 7, 35, new DateTime(1988, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marketing", "Bob Brown", "4449876543" },
                    { 8, 34, new DateTime(1989, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marketing", "George King", "7779876543" },
                    { 9, 29, new DateTime(1994, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sales", "Hannah Lee", "8884567890" },
                    { 10, 37, new DateTime(1986, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR", "Julia Nelson", "0002345678" },
                    { 11, 28, new DateTime(1995, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sales", "Charlie Davis", "3334567890" },
                    { 12, 32, new DateTime(1990, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "Ian Miller", "9993456789" },
                    { 13, 31, new DateTime(1992, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finance", "Kevin Ortiz", "1111234567" },
                    { 14, 35, new DateTime(1988, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marketing", "Laura Perez", "2229876543" },
                    { 15, 28, new DateTime(1995, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sales", "Michael Roberts", "3334567890" },
                    { 16, 32, new DateTime(1991, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "Nina Scott", "4443456789" },
                    { 17, 36, new DateTime(1987, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR", "Oscar Taylor", "5552345678" },
                    { 18, 30, new DateTime(1993, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finance", "Paula White", "6661234567" },
                    { 19, 34, new DateTime(1989, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marketing", "Quentin Young", "7779876543" },
                    { 20, 29, new DateTime(1994, 9, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sales", "Rachel Adams", "8884567890" },
                    { 21, 32, new DateTime(1990, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "Steve Baker", "9993456789" },
                    { 22, 37, new DateTime(1986, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR", "Tina Clark", "0002345678" },
                    { 23, 31, new DateTime(1992, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finance", "Ursula Diaz", "1111234567" },
                    { 24, 35, new DateTime(1988, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marketing", "Victor Evans", "2229876543" },
                    { 25, 28, new DateTime(1995, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sales", "Wendy Foster", "3334567890" },
                    { 26, 32, new DateTime(1991, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "IT", "Xander Garcia", "4443456789" },
                    { 27, 36, new DateTime(1987, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "HR", "Yara Harris", "5552345678" },
                    { 28, 30, new DateTime(1993, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Finance", "Zachary Johnson", "6661234567" },
                    { 29, 34, new DateTime(1989, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Marketing", "Alice Smith", "7779876543" },
                    { 30, 29, new DateTime(1994, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sales", "Bob Johnson", "8884567890" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
