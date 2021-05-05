using Microsoft.EntityFrameworkCore.Migrations;

namespace hardwarestore.Data.Migrations
{
    public partial class changedProductFKToSalesItemTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_ProdDetails_ProdDetailsId",
                table: "SalesItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesItems_ProdDetailsId",
                table: "SalesItems");

            migrationBuilder.DropColumn(
                name: "ProdDetailsId",
                table: "SalesItems");

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_ProductId",
                table: "SalesItems",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_ProdDetails_ProductId",
                table: "SalesItems",
                column: "ProductId",
                principalTable: "ProdDetails",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SalesItems_ProdDetails_ProductId",
                table: "SalesItems");

            migrationBuilder.DropIndex(
                name: "IX_SalesItems_ProductId",
                table: "SalesItems");

            migrationBuilder.AddColumn<int>(
                name: "ProdDetailsId",
                table: "SalesItems",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_ProdDetailsId",
                table: "SalesItems",
                column: "ProdDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SalesItems_ProdDetails_ProdDetailsId",
                table: "SalesItems",
                column: "ProdDetailsId",
                principalTable: "ProdDetails",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
