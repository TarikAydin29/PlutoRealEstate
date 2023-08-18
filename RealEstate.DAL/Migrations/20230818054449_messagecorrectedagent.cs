using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RealEstate.DAL.Migrations
{
    public partial class messagecorrectedagent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<Guid>(
                name: "AgentId",
                table: "Messages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7504a104-a72a-40d6-97b2-22113b305241"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("c7cb80fe-233a-4689-836f-a43ba5bd7fd0"));

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("7f25c865-28bf-4cbc-9d9e-cb2a379d3d10"), new Guid("8abb1dfe-d48d-4c76-9446-620529ea2044") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("7f25c865-28bf-4cbc-9d9e-cb2a379d3d10"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8abb1dfe-d48d-4c76-9446-620529ea2044"));

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Messages");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("2cd8166c-4993-4eef-af6f-ba816b67d10b"), "d79f2250-2e48-4457-8ff7-87c83d087ded", "Agent", "AGENT" },
                    { new Guid("3ade6ff9-9fe3-4f02-94dc-d45f91136a33"), "48f7863d-a009-4675-9556-b07c35365786", "Customer", "CUSTOMER" },
                    { new Guid("ee89bf04-1707-4acf-b13d-c9ef33dcf5a8"), "f584b65a-2822-4ae5-94db-f95c0d08f647", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "ConfirmCode", "Email", "EmailConfirmed", "ImageUrl", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Surname", "TwoFactorEnabled", "UserName" },
                values: new object[] { new Guid("beb0af59-8c1a-422e-a7d0-960c53d3177f"), 0, "3899d85d-3269-403d-b284-db03f914e6c8", null, "admin@example.com", true, "bb.jpg", false, null, "Bill", "ADMIN@EXAMPLE.COM", "ADMIN1", "AQAAAAEAACcQAAAAEFRaEsTRtbtwj1c/W76m8hQMcIHSved8OYZbem4Xe9pV3XGnNPaeDLtG34Jf146lCw==", "123456789", false, null, "Gates", false, "admin1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { new Guid("ee89bf04-1707-4acf-b13d-c9ef33dcf5a8"), new Guid("beb0af59-8c1a-422e-a7d0-960c53d3177f") });
        }
    }
}
