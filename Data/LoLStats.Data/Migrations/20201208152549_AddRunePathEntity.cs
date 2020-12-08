using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoLStats.Data.Migrations
{
    public partial class AddRunePathEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RunePath",
                table: "Runes",
                newName: "RunePathId");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "SummonerSpells",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RunePath",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RunePath", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Runes_RunePathId",
                table: "Runes",
                column: "RunePathId");

            migrationBuilder.CreateIndex(
                name: "IX_RunePath_IsDeleted",
                table: "RunePath",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Runes_RunePath_RunePathId",
                table: "Runes",
                column: "RunePathId",
                principalTable: "RunePath",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Runes_RunePath_RunePathId",
                table: "Runes");

            migrationBuilder.DropTable(
                name: "RunePath");

            migrationBuilder.DropIndex(
                name: "IX_Runes_RunePathId",
                table: "Runes");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "SummonerSpells");

            migrationBuilder.RenameColumn(
                name: "RunePathId",
                table: "Runes",
                newName: "RunePath");
        }
    }
}
