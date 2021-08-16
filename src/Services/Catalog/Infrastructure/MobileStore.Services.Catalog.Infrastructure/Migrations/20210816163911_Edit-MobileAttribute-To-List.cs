using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MobileStore.Services.Catalog.Infrastructure.Migrations
{
    public partial class EditMobileAttributeToList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MobileAttributes_MobileId",
                table: "MobileAttributes");

            migrationBuilder.DropColumn(
                name: "MobileAttributeId",
                table: "Mobiles");

            migrationBuilder.CreateIndex(
                name: "IX_MobileAttributes_MobileId",
                table: "MobileAttributes",
                column: "MobileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MobileAttributes_MobileId",
                table: "MobileAttributes");

            migrationBuilder.AddColumn<Guid>(
                name: "MobileAttributeId",
                table: "Mobiles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MobileAttributes_MobileId",
                table: "MobileAttributes",
                column: "MobileId",
                unique: true);
        }
    }
}
