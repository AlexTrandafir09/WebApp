using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class migration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_echipa_liga_echipe_liga_id",
                table: "echipa_liga");

            migrationBuilder.DropForeignKey(
                name: "FK_echipa_liga_ligi_echipa_id",
                table: "echipa_liga");

            migrationBuilder.DropPrimaryKey(
                name: "PK_echipa_liga",
                table: "echipa_liga");

            migrationBuilder.DropIndex(
                name: "IX_echipa_liga_echipa_id",
                table: "echipa_liga");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "echipa_liga");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "echipa_liga");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "echipa_liga");

            migrationBuilder.RenameColumn(
                name: "liga_id",
                table: "echipa_liga",
                newName: "Liga_id");

            migrationBuilder.RenameColumn(
                name: "echipa_id",
                table: "echipa_liga",
                newName: "Echipa_id");

            migrationBuilder.RenameIndex(
                name: "IX_echipa_liga_liga_id",
                table: "echipa_liga",
                newName: "IX_echipa_liga_Liga_id");

            migrationBuilder.AlterColumn<int>(
                name: "valoare",
                table: "echipe",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_echipa_liga",
                table: "echipa_liga",
                columns: new[] { "Echipa_id", "Liga_id" });

            migrationBuilder.AddForeignKey(
                name: "FK_echipa_liga_echipe_Liga_id",
                table: "echipa_liga",
                column: "Liga_id",
                principalTable: "echipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_echipa_liga_ligi_Echipa_id",
                table: "echipa_liga",
                column: "Echipa_id",
                principalTable: "ligi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_echipa_liga_echipe_Liga_id",
                table: "echipa_liga");

            migrationBuilder.DropForeignKey(
                name: "FK_echipa_liga_ligi_Echipa_id",
                table: "echipa_liga");

            migrationBuilder.DropPrimaryKey(
                name: "PK_echipa_liga",
                table: "echipa_liga");

            migrationBuilder.RenameColumn(
                name: "Liga_id",
                table: "echipa_liga",
                newName: "liga_id");

            migrationBuilder.RenameColumn(
                name: "Echipa_id",
                table: "echipa_liga",
                newName: "echipa_id");

            migrationBuilder.RenameIndex(
                name: "IX_echipa_liga_Liga_id",
                table: "echipa_liga",
                newName: "IX_echipa_liga_liga_id");

            migrationBuilder.AlterColumn<int>(
                name: "valoare",
                table: "echipe",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "echipa_liga",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "echipa_liga",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "echipa_liga",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_echipa_liga",
                table: "echipa_liga",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_echipa_liga_echipa_id",
                table: "echipa_liga",
                column: "echipa_id");

            migrationBuilder.AddForeignKey(
                name: "FK_echipa_liga_echipe_liga_id",
                table: "echipa_liga",
                column: "liga_id",
                principalTable: "echipe",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_echipa_liga_ligi_echipa_id",
                table: "echipa_liga",
                column: "echipa_id",
                principalTable: "ligi",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
