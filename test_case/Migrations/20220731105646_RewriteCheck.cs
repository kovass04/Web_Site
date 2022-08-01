using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_case.Migrations
{
    public partial class RewriteCheck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Check");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "Check",
                newName: "Roles");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Check",
                newName: "Order");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Check",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Check",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Check",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Check");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Check");

            migrationBuilder.RenameColumn(
                name: "Roles",
                table: "Check",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "Order",
                table: "Check",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Check",
                newName: "Description");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Check",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldNullable: true);
        }
    }
}
