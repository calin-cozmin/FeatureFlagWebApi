using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeatureFlags.DataLayer.Migrations
{
    public partial class Change_Table_Name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Flags");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flags",
                table: "Flags",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Flags",
                table: "Flags");

            migrationBuilder.RenameTable(
                name: "Flags",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");
        }
    }
}
