using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    public partial class SeedProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "Access detailed content and examples on Azure SQL, a set of cloud services that allows for SQL Server to be deployed in the cloud. This book teaches the fundamentals of deployment, configuration, security, performance, and availability of Azure SQL from the perspective of these same tasks and capabilities in SQL Server.", "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-5931-3", 26.99m, "Azure SQL Revealed" },
                    { 2, "Professional developers get ready to produce leaner applications for the ASP.NET Core platform. This edition puts ASP.NET Core 3 into context, and takes a deep dive into the tools and techniques required to build modern, extensible web applications.", "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-5440-0", 49.99m, "Pro ASP.NET Core 3" },
                    { 3, "Implement design patterns in .NET using the latest versions of the C# and F# languages. This book provides a comprehensive overview of the field of design patterns as they are used in today’s developer toolbox.", "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-4366-4", 29.99m, "Design Patterns in .NET" },
                    { 4, "Welcome to this one-stop-shop for learning Angular. Pro Angular is the most concise and comprehensive guide available, giving you the knowledge you need to take full advantage of this popular framework for building your own dynamic JavaScript applications.", "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-5998-6", 49.99m, "Pro Angular 9" },
                    { 5, "Explore data structures and algorithm concepts and their relation to everyday JavaScript development. A basic understanding of these ideas is essential to any JavaScript developer wishing to analyze and build great software solutions.", "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-3988-9", 29.99m, "JavaScript Data Structures and Algorithms" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
