using Microsoft.EntityFrameworkCore.Migrations;

namespace hardwarestore.Data.Migrations
{
    public partial class UpgradedDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Queantity",
                table: "ProdDetails",
                newName: "Quantity");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "ProdDetails",
                newName: "ProductName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "ProdDetails",
                newName: "Queantity");

            migrationBuilder.RenameColumn(
                name: "ProductName",
                table: "ProdDetails",
                newName: "Name");
        }
    }
}
