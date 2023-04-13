using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JbCoders.OpenWarehouse.Migrations
{
    /// <inheritdoc />
    public partial class AdjustLocationInPutAwayProcess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PutAwayProcessLocations",
                table: "PutAwayProcessLocations");

            migrationBuilder.AddColumn<Guid>(
                name: "StorageUnitId",
                table: "PutAwayProcessLocations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PutAwayProcessLocations",
                table: "PutAwayProcessLocations",
                columns: new[] { "OrderId", "ProductId", "StorageUnitId" });

            migrationBuilder.CreateIndex(
                name: "IX_PutAwayProcessLocations_TenantId_OrderId_ProductId_StorageUnitId",
                table: "PutAwayProcessLocations",
                columns: new[] { "TenantId", "OrderId", "ProductId", "StorageUnitId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PutAwayProcessLocations",
                table: "PutAwayProcessLocations");

            migrationBuilder.DropIndex(
                name: "IX_PutAwayProcessLocations_TenantId_OrderId_ProductId_StorageUnitId",
                table: "PutAwayProcessLocations");

            migrationBuilder.DropColumn(
                name: "StorageUnitId",
                table: "PutAwayProcessLocations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PutAwayProcessLocations",
                table: "PutAwayProcessLocations",
                columns: new[] { "OrderId", "ProductId", "HierarchyId" });
        }
    }
}
