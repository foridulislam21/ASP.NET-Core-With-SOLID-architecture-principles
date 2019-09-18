using Microsoft.EntityFrameworkCore.Migrations;

namespace eCommerce.DatabaseContext.Migrations
{
    public partial class Fixd_Stock_relation_with_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Stocks");

            migrationBuilder.RenameColumn(
                name: "ExpireTime",
                table: "Products",
                newName: "ExpireDate");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ExpireDate",
                table: "Products",
                newName: "ExpireTime");

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Stocks",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_Stocks_ProductId",
                table: "Stocks",
                column: "ProductId");
        }
    }
}
