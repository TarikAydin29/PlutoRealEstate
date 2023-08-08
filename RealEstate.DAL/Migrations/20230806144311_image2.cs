using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.DAL.Migrations
{
    public partial class image2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyPhoto_Properties_PropertyId",
                table: "PropertyPhoto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyPhoto",
                table: "PropertyPhoto");

            migrationBuilder.RenameTable(
                name: "PropertyPhoto",
                newName: "PropertyPhotos");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyPhoto_PropertyId",
                table: "PropertyPhotos",
                newName: "IX_PropertyPhotos_PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyPhotos",
                table: "PropertyPhotos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyPhotos_Properties_PropertyId",
                table: "PropertyPhotos",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PropertyPhotos_Properties_PropertyId",
                table: "PropertyPhotos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PropertyPhotos",
                table: "PropertyPhotos");

            migrationBuilder.RenameTable(
                name: "PropertyPhotos",
                newName: "PropertyPhoto");

            migrationBuilder.RenameIndex(
                name: "IX_PropertyPhotos_PropertyId",
                table: "PropertyPhoto",
                newName: "IX_PropertyPhoto_PropertyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PropertyPhoto",
                table: "PropertyPhoto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PropertyPhoto_Properties_PropertyId",
                table: "PropertyPhoto",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
