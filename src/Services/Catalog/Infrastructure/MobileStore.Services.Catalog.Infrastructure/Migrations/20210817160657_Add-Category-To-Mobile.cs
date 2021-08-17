using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileStore.Services.Catalog.Infrastructure.Migrations
{
    public partial class AddCategoryToMobile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Mobiles_CategoryId",
                table: "Mobiles",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Mobiles_Categories_CategoryId",
                table: "Mobiles",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Mobiles_Categories_CategoryId",
                table: "Mobiles");

            migrationBuilder.DropIndex(
                name: "IX_Mobiles_CategoryId",
                table: "Mobiles");
        }
    }
}
