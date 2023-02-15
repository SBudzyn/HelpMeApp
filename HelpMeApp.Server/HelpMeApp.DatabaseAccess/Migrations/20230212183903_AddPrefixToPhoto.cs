using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpMeApp.DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddPrefixToPhoto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Prefix",
                table: "Photos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 12, 20, 39, 2, 993, DateTimeKind.Local).AddTicks(8658),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 3, 15, 4, 11, 758, DateTimeKind.Local).AddTicks(3415));

            migrationBuilder.AddColumn<string>(
                name: "PhotoPrefix",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Adverts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 12, 20, 39, 2, 992, DateTimeKind.Local).AddTicks(1953),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 3, 15, 4, 11, 756, DateTimeKind.Local).AddTicks(1963));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Prefix",
                table: "Photos");

            migrationBuilder.DropColumn(
                name: "PhotoPrefix",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 3, 15, 4, 11, 758, DateTimeKind.Local).AddTicks(3415),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 12, 20, 39, 2, 993, DateTimeKind.Local).AddTicks(8658));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Adverts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 3, 15, 4, 11, 756, DateTimeKind.Local).AddTicks(1963),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 12, 20, 39, 2, 992, DateTimeKind.Local).AddTicks(1953));
        }
    }
}
