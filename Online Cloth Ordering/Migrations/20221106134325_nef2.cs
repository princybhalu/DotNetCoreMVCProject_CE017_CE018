using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Cloth_Ordering.Migrations
{
    public partial class nef2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Cart",
                newName: "ProductIdInCart");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductIdInCart",
                table: "Cart",
                newName: "ProductId");
        }
    }
}
