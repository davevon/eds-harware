using Microsoft.EntityFrameworkCore.Migrations;

namespace hardwarestore.Data.Migrations
{
    public partial class UpdateProductsAndsalesItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SalesItems",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ProdDetails",
                newName: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "SalesItems",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "ProdDetails",
                newName: "Id");
        }
    }
}
