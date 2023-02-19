using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelpMeApp.DatabaseAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedChatKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Chats_Id",
                table: "Chats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_UserId",
                table: "Chats");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 13, 23, 47, 36, 283, DateTimeKind.Local).AddTicks(5663),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 3, 15, 4, 11, 758, DateTimeKind.Local).AddTicks(3415));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Chats",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Adverts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 13, 23, 47, 36, 282, DateTimeKind.Local).AddTicks(7736),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 3, 15, 4, 11, 756, DateTimeKind.Local).AddTicks(1963));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Chats_UserId_AdvertId",
                table: "Chats",
                columns: new[] { "UserId", "AdvertId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Chats_UserId_AdvertId",
                table: "Chats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Chats",
                table: "Chats");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Messages",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 3, 15, 4, 11, 758, DateTimeKind.Local).AddTicks(3415),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 13, 23, 47, 36, 283, DateTimeKind.Local).AddTicks(5663));

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Chats",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "Adverts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 3, 15, 4, 11, 756, DateTimeKind.Local).AddTicks(1963),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 13, 23, 47, 36, 282, DateTimeKind.Local).AddTicks(7736));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Chats_Id",
                table: "Chats",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Chats",
                table: "Chats",
                columns: new[] { "Id", "UserId", "AdvertId" });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_UserId",
                table: "Chats",
                column: "UserId");
        }
    }
}
