using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MaxCinema.Migrations
{
    /// <inheritdoc />
    public partial class changeNamesMO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orderRows_Orders_OrderId",
                table: "orderRows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orderRows",
                table: "orderRows");

            migrationBuilder.RenameTable(
                name: "orderRows",
                newName: "OrderRows");

            migrationBuilder.RenameIndex(
                name: "IX_orderRows_OrderId",
                table: "OrderRows",
                newName: "IX_OrderRows_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderRows",
                table: "OrderRows",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderRows_Orders_OrderId",
                table: "OrderRows",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderRows_Orders_OrderId",
                table: "OrderRows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderRows",
                table: "OrderRows");

            migrationBuilder.RenameTable(
                name: "OrderRows",
                newName: "orderRows");

            migrationBuilder.RenameIndex(
                name: "IX_OrderRows_OrderId",
                table: "orderRows",
                newName: "IX_orderRows_OrderId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orderRows",
                table: "orderRows",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orderRows_Orders_OrderId",
                table: "orderRows",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
