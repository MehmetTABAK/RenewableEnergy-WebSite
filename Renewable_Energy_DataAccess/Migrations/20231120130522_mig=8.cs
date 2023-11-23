﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Renewable_Energy_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProjectCategories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProjectCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}