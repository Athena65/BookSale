using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookSale.Migrations
{
    public partial class newBooks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Genre", "Price", "PublishDate", "Title" },
                values: new object[] { new Guid("50bb4276-0388-4049-8525-84216857d593"), "History", 30.0, new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "SecondBook" });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Genre", "Price", "PublishDate", "Title" },
                values: new object[] { new Guid("bd70dbd9-1227-4681-af8b-465dd00d5266"), "Fiction", 20.0, new DateTime(2023, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "NewBook" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("50bb4276-0388-4049-8525-84216857d593"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("bd70dbd9-1227-4681-af8b-465dd00d5266"));
        }
    }
}
