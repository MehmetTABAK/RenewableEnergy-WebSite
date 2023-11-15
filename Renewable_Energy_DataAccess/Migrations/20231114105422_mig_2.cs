using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Renewable_Energy_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Filter",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                table: "ProjectCategories");

            migrationBuilder.DropColumn(
                name: "Filter",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogId",
                table: "BlogCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Filter",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProjectID",
                table: "ProjectCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Filter",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "BlogId",
                table: "BlogCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
