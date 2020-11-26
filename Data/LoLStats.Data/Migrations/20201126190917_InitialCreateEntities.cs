using Microsoft.EntityFrameworkCore.Migrations;

namespace LoLStats.Data.Migrations
{
    public partial class InitialCreateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SummonerSpell_ChampionSummonerSpells_ChampionSummonerSpellsId",
                table: "SummonerSpell");

            migrationBuilder.DropTable(
                name: "ChampionItemsItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SummonerSpell",
                table: "SummonerSpell");

            migrationBuilder.RenameTable(
                name: "SummonerSpell",
                newName: "SummonerSpells");

            migrationBuilder.RenameIndex(
                name: "IX_SummonerSpell_IsDeleted",
                table: "SummonerSpells",
                newName: "IX_SummonerSpells_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_SummonerSpell_ChampionSummonerSpellsId",
                table: "SummonerSpells",
                newName: "IX_SummonerSpells_ChampionSummonerSpellsId");

            migrationBuilder.AddColumn<int>(
                name: "ChampionItemsId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SummonerSpells",
                table: "SummonerSpells",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ChampionItemsId",
                table: "Items",
                column: "ChampionItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ChampionItems_ChampionItemsId",
                table: "Items",
                column: "ChampionItemsId",
                principalTable: "ChampionItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SummonerSpells_ChampionSummonerSpells_ChampionSummonerSpellsId",
                table: "SummonerSpells",
                column: "ChampionSummonerSpellsId",
                principalTable: "ChampionSummonerSpells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ChampionItems_ChampionItemsId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_SummonerSpells_ChampionSummonerSpells_ChampionSummonerSpellsId",
                table: "SummonerSpells");

            migrationBuilder.DropIndex(
                name: "IX_Items_ChampionItemsId",
                table: "Items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SummonerSpells",
                table: "SummonerSpells");

            migrationBuilder.DropColumn(
                name: "ChampionItemsId",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "SummonerSpells",
                newName: "SummonerSpell");

            migrationBuilder.RenameIndex(
                name: "IX_SummonerSpells_IsDeleted",
                table: "SummonerSpell",
                newName: "IX_SummonerSpell_IsDeleted");

            migrationBuilder.RenameIndex(
                name: "IX_SummonerSpells_ChampionSummonerSpellsId",
                table: "SummonerSpell",
                newName: "IX_SummonerSpell_ChampionSummonerSpellsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SummonerSpell",
                table: "SummonerSpell",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ChampionItemsItem",
                columns: table => new
                {
                    ChampionItemsId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionItemsItem", x => new { x.ChampionItemsId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_ChampionItemsItem_ChampionItems_ChampionItemsId",
                        column: x => x.ChampionItemsId,
                        principalTable: "ChampionItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionItemsItem_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChampionItemsItem_ItemsId",
                table: "ChampionItemsItem",
                column: "ItemsId");

            migrationBuilder.AddForeignKey(
                name: "FK_SummonerSpell_ChampionSummonerSpells_ChampionSummonerSpellsId",
                table: "SummonerSpell",
                column: "ChampionSummonerSpellsId",
                principalTable: "ChampionSummonerSpells",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
