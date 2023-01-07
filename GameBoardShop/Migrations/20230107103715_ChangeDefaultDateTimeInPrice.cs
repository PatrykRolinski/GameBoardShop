using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameBoardShop.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDefaultDateTimeInPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Prices",
                type: "smalldatetime",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValueSql: "convert(smalldatetime, GETUTCDATE())");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Prices",
                type: "smalldatetime",
                nullable: false,
                defaultValueSql: "convert(smalldatetime, GETUTCDATE())",
                oldClrType: typeof(DateTime),
                oldType: "smalldatetime",
                oldDefaultValueSql: "GETUTCDATE()");
        }
    }
}
