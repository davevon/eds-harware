using Microsoft.EntityFrameworkCore.Migrations;

namespace hardwarestore.Data.Migrations
{
    public partial class AddedSalesItemTabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalesItems",
                columns: table => new
                {
                    SalesItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    CustomerNAme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProdDetailsId = table.Column<int>(type: "int", nullable: true),
                    Id = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesItems", x => x.SalesItemId);
                    table.ForeignKey(
                        name: "FK_SalesItems_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesItems_ProdDetails_ProdDetailsId",
                        column: x => x.ProdDetailsId,
                        principalTable: "ProdDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_CustomerId",
                table: "SalesItems",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesItems_ProdDetailsId",
                table: "SalesItems",
                column: "ProdDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalesItems");
        }
    }
}
