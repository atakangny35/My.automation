using Microsoft.EntityFrameworkCore.Migrations;

namespace My.Otomasyon.DataAccess.Migrations
{
    public partial class MarkaClomunTypeUodated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Marka",
                table: "Products",
                type: "Varchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar",
                oldMaxLength: 30,
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Marka",
                table: "Products",
                type: "Varchar",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "Varchar(30)",
                oldMaxLength: 30,
                oldNullable: true);
        }
    }
}
