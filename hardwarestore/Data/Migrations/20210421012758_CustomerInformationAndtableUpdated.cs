using Microsoft.EntityFrameworkCore.Migrations;

namespace hardwarestore.Data.Migrations
{
    public partial class CustomerInformationAndtableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateViewed",
                table: "ProdHistories",
                newName: "Datesold");

            migrationBuilder.RenameColumn(
                name: "productNameId",
                table: "Customers",
                newName: "CustomerNAme");

            migrationBuilder.RenameColumn(
                name: "DatePurchased",
                table: "Customers",
                newName: "Membership");

            migrationBuilder.AddColumn<string>(
                name: "productId",
                table: "ProdHistories",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "totalPaid",
                table: "ProdHistories",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "CellNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "productId",
                table: "ProdHistories");

            migrationBuilder.DropColumn(
                name: "totalPaid",
                table: "ProdHistories");

            migrationBuilder.DropColumn(
                name: "CellNumber",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "Datesold",
                table: "ProdHistories",
                newName: "DateViewed");

            migrationBuilder.RenameColumn(
                name: "Membership",
                table: "Customers",
                newName: "DatePurchased");

            migrationBuilder.RenameColumn(
                name: "CustomerNAme",
                table: "Customers",
                newName: "productNameId");
        }
    }
}
