using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.DAL.Migrations
{
    public partial class messagecorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Customers_CustomerId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_Properties_PropertyId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CustomerId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_PropertyId",
                table: "Messages");

          

            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Messages",
                newName: "UserMessage");

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("2cd8166c-4993-4eef-af6f-ba816b67d10b"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("3ade6ff9-9fe3-4f02-94dc-d45f91136a33"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("ee89bf04-1707-4acf-b13d-c9ef33dcf5a8"), new Guid("beb0af59-8c1a-422e-a7d0-960c53d3177f") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ee89bf04-1707-4acf-b13d-c9ef33dcf5a8"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("beb0af59-8c1a-422e-a7d0-960c53d3177f"));

            migrationBuilder.RenameColumn(
                name: "UserMessage",
                table: "Messages",
                newName: "Content");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("4a686170-2166-495c-b51a-27e637752d74"), "07928c97-1953-405e-807a-f0115ad8fad0", "Customer", "CUSTOMER" },
                    { new Guid("660e13fb-51fd-4b28-8f34-cd583767831d"), "8433efb9-0650-4314-920a-19a9bcd55b47", "Agent", "AGENT" },
                    { new Guid("b9dac480-a1f2-4d33-8c36-3bf75f51cd9c"), "720b36a9-4dea-4148-8279-524f587b40f5", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConfirmCode", "Email", "EmailConfirmed", "ImageUrl", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("0fbb3ea8-d7d3-44c4-ae74-6f2fab6648b6"), 0, "dd6c856a-091b-4b48-a76b-1d98305eccbe", null, "admin@example.com", true, "bb.jpg", false, null, "Bill", "ADMIN@EXAMPLE.COM", "ADMIN1", "AQAAAAEAACcQAAAAEFtvGf1Q8WgTuFjujg2Ca2haq7uWijpAjeSZSwsyZ6w4XK3130X50U60D/1yG8kCGA==", "123456789", false, null, "Gates", false, "admin1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("b9dac480-a1f2-4d33-8c36-3bf75f51cd9c"), new Guid("0fbb3ea8-d7d3-44c4-ae74-6f2fab6648b6") });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CustomerId",
                table: "Messages",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_PropertyId",
                table: "Messages",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Customers_CustomerId",
                table: "Messages",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Properties_PropertyId",
                table: "Messages",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
