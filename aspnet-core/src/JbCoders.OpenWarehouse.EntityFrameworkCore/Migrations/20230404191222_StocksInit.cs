using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JbCoders.OpenWarehouse.Migrations
{
    /// <inheritdoc />
    public partial class StocksInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InventoryStockUnits",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    DeleterId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryStockUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InventoryStockToStorages",
                columns: table => new
                {
                    StockUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StorageUnitId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryStockToStorages", x => new { x.StockUnitId, x.StorageUnitId });
                    table.ForeignKey(
                        name: "FK_InventoryStockToStorages_InventoryStockUnits_StockUnitId",
                        column: x => x.StockUnitId,
                        principalTable: "InventoryStockUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryStockToStorages_InventoryStorageUnits_StorageUnitId",
                        column: x => x.StorageUnitId,
                        principalTable: "InventoryStorageUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryStockToStorages_StorageUnitId",
                table: "InventoryStockToStorages",
                column: "StorageUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryStockToStorages_TenantId_StockUnitId_StorageUnitId",
                table: "InventoryStockToStorages",
                columns: new[] { "TenantId", "StockUnitId", "StorageUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryStockUnits_TenantId_Id",
                table: "InventoryStockUnits",
                columns: new[] { "TenantId", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryStockToStorages");

            migrationBuilder.DropTable(
                name: "InventoryStockUnits");
        }
    }
}
