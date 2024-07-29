using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bs_data.Migrations
{
    public partial class AddPriceToPriceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "BookPriceTable",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "BookPriceTable");
        }
    }
}
