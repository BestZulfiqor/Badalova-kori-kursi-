using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SorPizza.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePizzaImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQWt2tl4rRCdXNhdwV5zC-jf9ki2Ipg_Ceh_Q&s");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSn_BFLxdQLqiqJOtDwS5Jm6D2Mg2OVkMGpGw&s");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImageUrl",
                value: "/images/pizzas/margherita.jpg");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImageUrl",
                value: "/images/pizzas/pepperoni.jpg");
        }
    }
}
