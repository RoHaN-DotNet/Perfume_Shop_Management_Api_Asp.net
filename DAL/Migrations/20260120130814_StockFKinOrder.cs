using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class StockFKinOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PerfumeId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PerfumeId",
                table: "Orders",
                column: "PerfumeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Perfumes_PerfumeId",
                table: "Orders",
                column: "PerfumeId",
                principalTable: "Perfumes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Perfumes_PerfumeId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PerfumeId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PerfumeId",
                table: "Orders");
        }
    }
}
