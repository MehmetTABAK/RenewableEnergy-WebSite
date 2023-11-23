using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Renewable_Energy_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "References",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "References");
        }
    }
}
