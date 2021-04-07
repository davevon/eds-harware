using Microsoft.EntityFrameworkCore.Migrations;

namespace hardwarestore.Data.Migrations
{
    public partial class NewAddedProductDetailsDataset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdDetails_Products_ProductId",
                table: "ProdDetails");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropIndex(
                name: "IX_ProdDetails_ProductId",
                table: "ProdDetails");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "ProdDetails");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ProdDetails",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ProdDetails");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "ProdDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdDetails_ProductId",
                table: "ProdDetails",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdDetails_Products_ProductId",
                table: "ProdDetails",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
