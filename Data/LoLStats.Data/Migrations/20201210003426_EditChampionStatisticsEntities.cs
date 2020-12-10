using Microsoft.EntityFrameworkCore.Migrations;

namespace LoLStats.Data.Migrations
{
    public partial class EditChampionStatisticsEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PickRate",
                table: "ChampionSummonerSpells");

            migrationBuilder.DropColumn(
                name: "BanRate",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "PickRate",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "Tier",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "WinRate",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "PickRate",
                table: "ChampionRunes");

            migrationBuilder.DropColumn(
                name: "PickRate",
                table: "ChampionItems");

            migrationBuilder.DropColumn(
                name: "PickRate",
                table: "ChampionAbilities");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "StatRune",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalMatches",
                table: "ChampionSummonerSpells",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "WinRate",
                table: "ChampionStarterItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<int>(
                name: "PickRate",
                table: "ChampionStarterItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "MainRuneTree",
                table: "ChampionRunes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SecondaryRuneTree",
                table: "ChampionRunes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalMatches",
                table: "ChampionRunes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "BanRate",
                table: "ChampionRoles",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Tier",
                table: "ChampionRoles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TotalMatches",
                table: "ChampionRoles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "WinRate",
                table: "ChampionItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "TotalMatches",
                table: "ChampionAbilities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "StatRune");

            migrationBuilder.DropColumn(
                name: "TotalMatches",
                table: "ChampionSummonerSpells");

            migrationBuilder.DropColumn(
                name: "MainRuneTree",
                table: "ChampionRunes");

            migrationBuilder.DropColumn(
                name: "SecondaryRuneTree",
                table: "ChampionRunes");

            migrationBuilder.DropColumn(
                name: "TotalMatches",
                table: "ChampionRunes");

            migrationBuilder.DropColumn(
                name: "BanRate",
                table: "ChampionRoles");

            migrationBuilder.DropColumn(
                name: "Tier",
                table: "ChampionRoles");

            migrationBuilder.DropColumn(
                name: "TotalMatches",
                table: "ChampionRoles");

            migrationBuilder.DropColumn(
                name: "TotalMatches",
                table: "ChampionAbilities");

            migrationBuilder.AddColumn<double>(
                name: "PickRate",
                table: "ChampionSummonerSpells",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "WinRate",
                table: "ChampionStarterItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<double>(
                name: "PickRate",
                table: "ChampionStarterItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "BanRate",
                table: "Champions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PickRate",
                table: "Champions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Tier",
                table: "Champions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "WinRate",
                table: "Champions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PickRate",
                table: "ChampionRunes",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<double>(
                name: "WinRate",
                table: "ChampionItems",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "PickRate",
                table: "ChampionItems",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "PickRate",
                table: "ChampionAbilities",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
