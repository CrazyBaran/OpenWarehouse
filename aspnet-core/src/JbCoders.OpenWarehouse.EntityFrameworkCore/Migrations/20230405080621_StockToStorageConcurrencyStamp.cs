using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JbCoders.OpenWarehouse.Migrations
{
    /// <inheritdoc />
    public partial class StockToStorageConcurrencyStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "InventoryStockToStorages",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "InventoryStockToStorages");
        }
    }
}
