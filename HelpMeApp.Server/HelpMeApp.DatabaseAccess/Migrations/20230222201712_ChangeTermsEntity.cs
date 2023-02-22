using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpMeApp.DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTermsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Days",
                table: "Terms",
                newName: "From");

            migrationBuilder.AddColumn<string>(
                name: "Till",
                table: "Terms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 22, 17, 12, 349, DateTimeKind.Local).AddTicks(522),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 12, 20, 39, 2, 993, DateTimeKind.Local).AddTicks(8658));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Adverts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 22, 22, 17, 12, 348, DateTimeKind.Local).AddTicks(4092),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 12, 20, 39, 2, 992, DateTimeKind.Local).AddTicks(1953));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Till",
                table: "Terms");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "Terms",
                newName: "Days");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 12, 20, 39, 2, 993, DateTimeKind.Local).AddTicks(8658),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 22, 17, 12, 349, DateTimeKind.Local).AddTicks(522));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Adverts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 12, 20, 39, 2, 992, DateTimeKind.Local).AddTicks(1953),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 22, 22, 17, 12, 348, DateTimeKind.Local).AddTicks(4092));
        }
    }
}
