using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoLStats.Data.Migrations
{
    public partial class UpdateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GeneratesResource",
                table: "AbilitiesPerLevel");

            migrationBuilder.RenameColumn(
                name: "ChampionTier",
                table: "Champions",
                newName: "Title");

            migrationBuilder.AlterColumn<double>(
                name: "BaseCooldown",
                table: "SummonerSpells",
                type: "float",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "SummonerSpells",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tooltip",
                table: "SummonerSpells",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Runes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPurchasable",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SellingCost",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "WinRate",
                table: "Champions",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "PickRate",
                table: "Champions",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<double>(
                name: "BanRate",
                table: "Champions",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "ChampionId",
                table: "Champions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Champions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InfoId",
                table: "Champions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Champions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Lore",
                table: "Champions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Partype",
                table: "Champions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Tier",
                table: "Champions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "BaseChampionAbilities",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AllyTip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChampionId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllyTip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllyTip_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Armor = table.Column<double>(type: "float", nullable: false),
                    ArmorPerLevel = table.Column<double>(type: "float", nullable: false),
                    AttackDamage = table.Column<double>(type: "float", nullable: false),
                    AttackDamagePerLevel = table.Column<double>(type: "float", nullable: false),
                    AttackRange = table.Column<double>(type: "float", nullable: false),
                    AttackSpeedOffset = table.Column<double>(type: "float", nullable: false),
                    AttackSpeedPerLevel = table.Column<double>(type: "float", nullable: false),
                    Crit = table.Column<double>(type: "float", nullable: false),
                    CritPerLevel = table.Column<double>(type: "float", nullable: false),
                    Hp = table.Column<double>(type: "float", nullable: false),
                    HpPerLevel = table.Column<double>(type: "float", nullable: false),
                    HpRegen = table.Column<double>(type: "float", nullable: false),
                    HpRegenPerLevel = table.Column<double>(type: "float", nullable: false),
                    MoveSpeed = table.Column<double>(type: "float", nullable: false),
                    Mp = table.Column<double>(type: "float", nullable: false),
                    MpPerLevel = table.Column<double>(type: "float", nullable: false),
                    MpRegen = table.Column<double>(type: "float", nullable: false),
                    MpRegenPerLevel = table.Column<double>(type: "float", nullable: false),
                    SpellBlock = table.Column<double>(type: "float", nullable: false),
                    SpellBlockPerLevel = table.Column<double>(type: "float", nullable: false),
                    ChampionId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionStats_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnemyTip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChampionId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnemyTip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnemyTip_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Info",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attack = table.Column<byte>(type: "tinyint", nullable: false),
                    Defense = table.Column<byte>(type: "tinyint", nullable: false),
                    Difficulty = table.Column<byte>(type: "tinyint", nullable: false),
                    Magic = table.Column<byte>(type: "tinyint", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Info", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Passive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChampionId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passive", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passive_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatRune",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChampionRunesId = table.Column<int>(type: "int", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatRune", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatRune_ChampionRunes_ChampionRunesId",
                        column: x => x.ChampionRunesId,
                        principalTable: "ChampionRunes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChampionTag",
                columns: table => new
                {
                    ChampionsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionTag", x => new { x.ChampionsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_ChampionTag_Champions_ChampionsId",
                        column: x => x.ChampionsId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionTag_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Champions_ChampionId",
                table: "Champions",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_Champions_InfoId",
                table: "Champions",
                column: "InfoId");

            migrationBuilder.CreateIndex(
                name: "IX_AllyTip_ChampionId",
                table: "AllyTip",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_AllyTip_IsDeleted",
                table: "AllyTip",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionStats_ChampionId",
                table: "ChampionStats",
                column: "ChampionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChampionStats_IsDeleted",
                table: "ChampionStats",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionTag_TagsId",
                table: "ChampionTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyTip_ChampionId",
                table: "EnemyTip",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyTip_IsDeleted",
                table: "EnemyTip",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Info_IsDeleted",
                table: "Info",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Passive_ChampionId",
                table: "Passive",
                column: "ChampionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passive_IsDeleted",
                table: "Passive",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StatRune_ChampionRunesId",
                table: "StatRune",
                column: "ChampionRunesId");

            migrationBuilder.CreateIndex(
                name: "IX_StatRune_IsDeleted",
                table: "StatRune",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_IsDeleted",
                table: "Tag",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_Champions_Champions_ChampionId",
                table: "Champions",
                column: "ChampionId",
                principalTable: "Champions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Champions_Info_InfoId",
                table: "Champions",
                column: "InfoId",
                principalTable: "Info",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Champions_Champions_ChampionId",
                table: "Champions");

            migrationBuilder.DropForeignKey(
                name: "FK_Champions_Info_InfoId",
                table: "Champions");

            migrationBuilder.DropTable(
                name: "AllyTip");

            migrationBuilder.DropTable(
                name: "ChampionStats");

            migrationBuilder.DropTable(
                name: "ChampionTag");

            migrationBuilder.DropTable(
                name: "EnemyTip");

            migrationBuilder.DropTable(
                name: "Info");

            migrationBuilder.DropTable(
                name: "Passive");

            migrationBuilder.DropTable(
                name: "StatRune");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropIndex(
                name: "IX_Champions_ChampionId",
                table: "Champions");

            migrationBuilder.DropIndex(
                name: "IX_Champions_InfoId",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "SummonerSpells");

            migrationBuilder.DropColumn(
                name: "Tooltip",
                table: "SummonerSpells");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Runes");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "IsPurchasable",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "SellingCost",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ChampionId",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "InfoId",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "Lore",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "Partype",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "Tier",
                table: "Champions");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "BaseChampionAbilities");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Champions",
                newName: "ChampionTier");

            migrationBuilder.AlterColumn<int>(
                name: "BaseCooldown",
                table: "SummonerSpells",
                type: "int",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "WinRate",
                table: "Champions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "PickRate",
                table: "Champions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<decimal>(
                name: "BanRate",
                table: "Champions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<bool>(
                name: "GeneratesResource",
                table: "AbilitiesPerLevel",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
