using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Renewable_Energy_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "References",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "ProjectCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "BlogCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "References");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "ProjectCategories");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "BlogCategories");
        }
    }
}
