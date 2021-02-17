using Microsoft.EntityFrameworkCore.Migrations;

namespace My.Otomasyon.DataAccess.Migrations
{
    public partial class AddedDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departman_DepartmanId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FaturaKalem_Bills_BillsId",
                table: "FaturaKalem");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_SellingMoves_AspNetUsers_AppUserId",
                table: "SellingMoves");

            migrationBuilder.DropForeignKey(
                name: "FK_SellingMoves_Product_ProductId",
                table: "SellingMoves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SellingMoves",
                table: "SellingMoves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KargoTrack",
                table: "KargoTrack");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KargoDetay",
                table: "KargoDetay");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FaturaKalem",
                table: "FaturaKalem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departman",
                table: "Departman");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "SellingMoves",
                newName: "sellingMoves");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "KargoTrack",
                newName: "KargoTracks");

            migrationBuilder.RenameTable(
                name: "KargoDetay",
                newName: "KargoDetays");

            migrationBuilder.RenameTable(
                name: "FaturaKalem",
                newName: "FaturaKalems");

            migrationBuilder.RenameTable(
                name: "Departman",
                newName: "Departmen");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_SellingMoves_ProductId",
                table: "sellingMoves",
                newName: "IX_sellingMoves_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_SellingMoves_AppUserId",
                table: "sellingMoves",
                newName: "IX_sellingMoves_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_FaturaKalem_BillsId",
                table: "FaturaKalems",
                newName: "IX_FaturaKalems_BillsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_sellingMoves",
                table: "sellingMoves",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KargoTracks",
                table: "KargoTracks",
                column: "KargoDetailid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KargoDetays",
                table: "KargoDetays",
                column: "CargoDetailid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FaturaKalems",
                table: "FaturaKalems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departmen",
                table: "Departmen",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Stoks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Stock = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stoks", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departmen_DepartmanId",
                table: "AspNetUsers",
                column: "DepartmanId",
                principalTable: "Departmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FaturaKalems_Bills_BillsId",
                table: "FaturaKalems",
                column: "BillsId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sellingMoves_AspNetUsers_AppUserId",
                table: "sellingMoves",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_sellingMoves_Products_ProductId",
                table: "sellingMoves",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Departmen_DepartmanId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FaturaKalems_Bills_BillsId",
                table: "FaturaKalems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_sellingMoves_AspNetUsers_AppUserId",
                table: "sellingMoves");

            migrationBuilder.DropForeignKey(
                name: "FK_sellingMoves_Products_ProductId",
                table: "sellingMoves");

            migrationBuilder.DropTable(
                name: "Stoks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_sellingMoves",
                table: "sellingMoves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KargoTracks",
                table: "KargoTracks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_KargoDetays",
                table: "KargoDetays");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FaturaKalems",
                table: "FaturaKalems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Departmen",
                table: "Departmen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "sellingMoves",
                newName: "SellingMoves");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "KargoTracks",
                newName: "KargoTrack");

            migrationBuilder.RenameTable(
                name: "KargoDetays",
                newName: "KargoDetay");

            migrationBuilder.RenameTable(
                name: "FaturaKalems",
                newName: "FaturaKalem");

            migrationBuilder.RenameTable(
                name: "Departmen",
                newName: "Departman");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_sellingMoves_ProductId",
                table: "SellingMoves",
                newName: "IX_SellingMoves_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_sellingMoves_AppUserId",
                table: "SellingMoves",
                newName: "IX_SellingMoves_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_FaturaKalems_BillsId",
                table: "FaturaKalem",
                newName: "IX_FaturaKalem_BillsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SellingMoves",
                table: "SellingMoves",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KargoTrack",
                table: "KargoTrack",
                column: "KargoDetailid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_KargoDetay",
                table: "KargoDetay",
                column: "CargoDetailid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FaturaKalem",
                table: "FaturaKalem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Departman",
                table: "Departman",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Departman_DepartmanId",
                table: "AspNetUsers",
                column: "DepartmanId",
                principalTable: "Departman",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FaturaKalem_Bills_BillsId",
                table: "FaturaKalem",
                column: "BillsId",
                principalTable: "Bills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellingMoves_AspNetUsers_AppUserId",
                table: "SellingMoves",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SellingMoves_Product_ProductId",
                table: "SellingMoves",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
