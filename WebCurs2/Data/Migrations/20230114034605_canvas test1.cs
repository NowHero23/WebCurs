using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebCurs2.Data.Migrations
{
    /// <inheritdoc />
    public partial class canvastest1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "ShopCartItems");

            migrationBuilder.AddColumn<long>(
                name: "Count",
                table: "ShopCartItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "ShopCartItems");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ShopCartItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
