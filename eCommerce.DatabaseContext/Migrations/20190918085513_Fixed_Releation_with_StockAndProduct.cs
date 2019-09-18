using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.DatabaseContext.Migrations
{
    public partial class Fixed_Releation_with_StockAndProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stocks_StockId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_StockId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "StockId",
                table: "Products");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Stocks",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Stocks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stocks_Products_ProductId",
                table: "Stocks",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stocks_Products_ProductId",
                table: "Stocks");

            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Stocks");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "StockId",
                table: "Products",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_StockId",
                table: "Products",
                column: "StockId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stocks_StockId",
                table: "Products",
                column: "StockId",
                principalTable: "Stocks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
