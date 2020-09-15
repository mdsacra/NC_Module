using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NC_Module.Migrations
{
    public partial class ManyToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "corrActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_corrActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nonConfs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Version = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nonConfs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "nonConfCorrActions",
                columns: table => new
                {
                    NonconfId = table.Column<int>(nullable: false),
                    CorractionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nonConfCorrActions", x => new { x.NonconfId, x.CorractionId });
                    table.ForeignKey(
                        name: "FK_nonConfCorrActions_corrActions_CorractionId",
                        column: x => x.CorractionId,
                        principalTable: "corrActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_nonConfCorrActions_nonConfs_NonconfId",
                        column: x => x.NonconfId,
                        principalTable: "nonConfs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nonConfCorrActions_CorractionId",
                table: "nonConfCorrActions",
                column: "CorractionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nonConfCorrActions");

            migrationBuilder.DropTable(
                name: "corrActions");

            migrationBuilder.DropTable(
                name: "nonConfs");
        }
    }
}
