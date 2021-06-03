using Microsoft.EntityFrameworkCore.Migrations;

namespace JCP.Ordering.API.Migrations
{
    public partial class addOrderStatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "ordering",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                schema: "ordering",
                table: "order");
        }
    }
}
