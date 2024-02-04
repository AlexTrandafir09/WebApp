using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Migrations
{
    /// <inheritdoc />
    public partial class migrare1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "echipe",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    antrenor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    manager = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    valoare = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_echipe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ligi",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    presedinte = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    esalon = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ligi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "baze_sportive",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nume_baza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    capacitate = table.Column<int>(type: "int", nullable: false),
                    echipa_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_baze_sportive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_baze_sportive_echipe_echipa_id",
                        column: x => x.echipa_id,
                        principalTable: "echipe",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "jucatori",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numar_tricou = table.Column<int>(type: "int", nullable: false),
                    data_nasterii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    echipa_id = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_jucatori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_jucatori_echipe_echipa_id",
                        column: x => x.echipa_id,
                        principalTable: "echipe",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "echipa_liga",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    echipa_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    liga_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    esalon = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_echipa_liga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_echipa_liga_echipe_liga_id",
                        column: x => x.liga_id,
                        principalTable: "echipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_echipa_liga_ligi_echipa_id",
                        column: x => x.echipa_id,
                        principalTable: "ligi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_baze_sportive_echipa_id",
                table: "baze_sportive",
                column: "echipa_id",
                unique: true,
                filter: "[echipa_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_echipa_liga_echipa_id",
                table: "echipa_liga",
                column: "echipa_id");

            migrationBuilder.CreateIndex(
                name: "IX_echipa_liga_liga_id",
                table: "echipa_liga",
                column: "liga_id");

            migrationBuilder.CreateIndex(
                name: "IX_jucatori_echipa_id",
                table: "jucatori",
                column: "echipa_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "baze_sportive");

            migrationBuilder.DropTable(
                name: "echipa_liga");

            migrationBuilder.DropTable(
                name: "jucatori");

            migrationBuilder.DropTable(
                name: "ligi");

            migrationBuilder.DropTable(
                name: "echipe");
        }
    }
}
