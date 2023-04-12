using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JbCoders.OpenWarehouse.Migrations
{
    /// <inheritdoc />
    public partial class PutAwayFirstLook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PutAwayProcessOrders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExtraProperties = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
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
                    table.PrimaryKey("PK_PutAwayProcessOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PutAwayProcessOrderItems",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_PutAwayProcessOrderItems", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_PutAwayProcessOrderItems_PutAwayProcessOrders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "PutAwayProcessOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PutAwayProcessLocations",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HierarchyId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TenantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
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
                    table.PrimaryKey("PK_PutAwayProcessLocations", x => new { x.OrderId, x.ProductId, x.HierarchyId });
                    table.ForeignKey(
                        name: "FK_PutAwayProcessLocations_PutAwayProcessOrderItems_OrderId_ProductId",
                        columns: x => new { x.OrderId, x.ProductId },
                        principalTable: "PutAwayProcessOrderItems",
                        principalColumns: new[] { "OrderId", "ProductId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PutAwayProcessLocations_TenantId_OrderId_ProductId_HierarchyId",
                table: "PutAwayProcessLocations",
                columns: new[] { "TenantId", "OrderId", "ProductId", "HierarchyId" });

            migrationBuilder.CreateIndex(
                name: "IX_PutAwayProcessOrderItems_TenantId_OrderId_ProductId",
                table: "PutAwayProcessOrderItems",
                columns: new[] { "TenantId", "OrderId", "ProductId" });

            migrationBuilder.CreateIndex(
                name: "IX_PutAwayProcessOrders_TenantId_Id",
                table: "PutAwayProcessOrders",
                columns: new[] { "TenantId", "Id" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PutAwayProcessLocations");

            migrationBuilder.DropTable(
                name: "PutAwayProcessOrderItems");

            migrationBuilder.DropTable(
                name: "PutAwayProcessOrders");
        }
    }
}
