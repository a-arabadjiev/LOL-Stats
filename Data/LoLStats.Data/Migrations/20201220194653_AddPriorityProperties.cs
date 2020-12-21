using Microsoft.EntityFrameworkCore.Migrations;

namespace LoLStats.Data.Migrations
{
    public partial class AddPriorityProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemPriority",
                table: "ChampionStarterItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SummonerSpellPriority",
                table: "ChampionsSummonerSpell",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemPriority",
                table: "ChampionsItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SkillPriority",
                table: "ChampionsAbilities",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemPriority",
                table: "ChampionStarterItems");

            migrationBuilder.DropColumn(
                name: "SummonerSpellPriority",
                table: "ChampionsSummonerSpell");

            migrationBuilder.DropColumn(
                name: "ItemPriority",
                table: "ChampionsItems");

            migrationBuilder.DropColumn(
                name: "SkillPriority",
                table: "ChampionsAbilities");
        }
    }
}
