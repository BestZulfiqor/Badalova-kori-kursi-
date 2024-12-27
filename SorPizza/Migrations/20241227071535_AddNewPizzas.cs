using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SorPizza.Migrations
{
    /// <inheritdoc />
    public partial class AddNewPizzas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "IsAvailable", "Name", "Price" },
                values: new object[,]
                {
                    { 3, 2, "Соус альфредо, моцарелла, горгонзола, пармезан, чеддер", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSwu3kmyVWPPE6ks6GyY6P61nhueZfXkCPa6w&s", true, "Четыре сыра", 109.0m },
                    { 4, 3, "Острый томатный соус, пепперони, халапеньо, красный перец", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSeRy4cMBDqKYYkzPUR-kqKsPIBqXYuCxUG_Q&s", true, "Дьябло", 105.0m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
