using Microsoft.EntityFrameworkCore.Migrations;

namespace My.Otomasyon.DataAccess.Migrations
{
    public partial class AddedCategoryLimitState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "LimitState",
                table: "Categories",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LimitState",
                table: "Categories");
        }
    }
}
