using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.DAL.Migrations
{
    public partial class propertytitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<string>(
                name: "PropertyTitle",
                table: "Properties",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyTitle",
                table: "Properties");

            migrationBuilder.RenameColumn(
                name: "mahalle_ilcekey",
                table: "mahalle",
                newName: "mahalle_sehirkey");
        }
    }
}
