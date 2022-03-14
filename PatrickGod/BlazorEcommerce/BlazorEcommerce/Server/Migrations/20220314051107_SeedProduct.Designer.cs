﻿// <auto-generated />
using BlazorEcommerce.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlazorEcommerce.Server.Migrations
{
    [DbContext(typeof(ShopContext))]
    [Migration("20220314051107_SeedProduct")]
    partial class SeedProduct
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlazorEcommerce.Shared.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Access detailed content and examples on Azure SQL, a set of cloud services that allows for SQL Server to be deployed in the cloud. This book teaches the fundamentals of deployment, configuration, security, performance, and availability of Azure SQL from the perspective of these same tasks and capabilities in SQL Server.",
                            ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-5931-3",
                            Price = 26.99m,
                            Title = "Azure SQL Revealed"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Professional developers get ready to produce leaner applications for the ASP.NET Core platform. This edition puts ASP.NET Core 3 into context, and takes a deep dive into the tools and techniques required to build modern, extensible web applications.",
                            ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-5440-0",
                            Price = 49.99m,
                            Title = "Pro ASP.NET Core 3"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Implement design patterns in .NET using the latest versions of the C# and F# languages. This book provides a comprehensive overview of the field of design patterns as they are used in today’s developer toolbox.",
                            ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-4366-4",
                            Price = 29.99m,
                            Title = "Design Patterns in .NET"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Welcome to this one-stop-shop for learning Angular. Pro Angular is the most concise and comprehensive guide available, giving you the knowledge you need to take full advantage of this popular framework for building your own dynamic JavaScript applications.",
                            ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-5998-6",
                            Price = 49.99m,
                            Title = "Pro Angular 9"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Explore data structures and algorithm concepts and their relation to everyday JavaScript development. A basic understanding of these ideas is essential to any JavaScript developer wishing to analyze and build great software solutions.",
                            ImageUrl = "https://media.springernature.com/w306/springer-static/cover-hires/book/978-1-4842-3988-9",
                            Price = 29.99m,
                            Title = "JavaScript Data Structures and Algorithms"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
