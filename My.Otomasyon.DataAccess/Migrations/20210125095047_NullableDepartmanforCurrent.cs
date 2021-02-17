using Microsoft.EntityFrameworkCore.Migrations;

namespace My.Otomasyon.DataAccess.Migrations
{
    public partial class NullableDepartmanforCurrent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departmen_DepartmanId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmanId",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departmen_DepartmanId",
                table: "AspNetUsers",
                column: "DepartmanId",
                principalTable: "Departmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departmen_DepartmanId",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmanId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departmen_DepartmanId",
                table: "AspNetUsers",
                column: "DepartmanId",
                principalTable: "Departmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
