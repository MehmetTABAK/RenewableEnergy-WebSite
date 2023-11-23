using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Renewable_Energy_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "References");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "References");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "References",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "References",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
