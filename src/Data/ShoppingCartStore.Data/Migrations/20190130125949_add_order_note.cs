using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingCartStore.Data.Migrations
{
    public partial class add_order_note : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderNote",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderNote",
                table: "Orders");
        }
    }
}
