using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    public partial class SeedMoreProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "databases");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Price", "Title" },
                values: new object[,]
                {
                    { 6, 3, "Write optimized queries. This book helps you write queries that perform fast and deliver results on time. You will learn that query optimization is not a dark art practiced by a small, secretive cabal of sorcerers. Any motivated professional can learn to write efficient queries from the get-go and capably optimize existing queries. You will learn to look at the process of writing a query from the database engine’s point of view, and know how to think like the database optimizer.", "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-6885-8", 36.99m, "PostgreSQL Query Optimization" },
                    { 7, 3, "Use this fast and complete guide to optimize the performance of MongoDB databases and the applications that depend on them. You will be able to turbo-charge the performance of your MongoDB applications to provide a better experience for your users, reduce your running costs, and avoid application growing pains. MongoDB is the world’s most popular document database and the foundation for thousands of mission-critical applications.", "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-6879-7", 29.99m, "MongoDB Performance Tuning" },
                    { 8, 2, "Agile Visualization with Pharo focuses on the Roassal visualization engine and first presents the basic and necessary tools to visualize data, including an introduction to the Pharo programming language. Once you’ve grasped the basics, you’ll learn all about the development environment offered by Roassal. The book provides numerous ready-to-use examples.", "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-7161-2", 26.99m, "Agile Visualization with Pharo" },
                    { 9, 2, "Programming Algorithms in Lisp shows real-world engineering considerations and constraints that influence the programs that use these algorithms. It includes practical use cases of the applications of the algorithms to a variety of real-world problems.", "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-6428-7", 22.99m, "Programming Algorithms in Lisp" },
                    { 10, 1, "Learn to leverage the power of Svelte to produce web applications that are efficient and fast. This project-oriented book simplifies creating sites using Svelte from start to finish, with little more than a text editor and familiar languages such as HTML, CSS, and JavaScript. It equips you with a starting toolset that you can use to develop future projects, incorporate into your existing workflow, and allow you to take your websites to the next level.", "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-7374-6", 35.99m, "Practical Svelte" },
                    { 11, 1, "Quickly discover solutions to common problems, best practices you can follow, and everything jQuery has to offer. Using a problem-solution approach, this book begins with small initial problems that developers typically face while working with jQuery, and gradually goes deeper to explore more complex problems. The solutions include illustrations and clear, concise explanations of the code.", "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-7304-3", 15.99m, "jQuery Recipes" },
                    { 12, 1, "Make your websites more dynamic by adding a feedback form, creating a private area where members can upload images that are automatically resized, or storing all your content in a database. David Powers has updated his definitive book to incorporate the latest techniques and changes to PHP with the arrival of PHP 8. New features include named attributes, constructor property promotion, the stricter and more concise match expression, union types, and more.​", "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-7141-4", 39.99m, "PHP 8 Solutions" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "database");
        }
    }
}
