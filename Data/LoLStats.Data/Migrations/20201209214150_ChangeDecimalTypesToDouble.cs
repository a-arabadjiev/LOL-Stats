using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoLStats.Data.Migrations
{
    public partial class ChangeDecimalTypesToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChampionInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attack = table.Column<byte>(type: "tinyint", nullable: false),
                    Defense = table.Column<byte>(type: "tinyint", nullable: false),
                    Difficulty = table.Column<byte>(type: "tinyint", nullable: false),
                    Magic = table.Column<byte>(type: "tinyint", nullable: false),
                    ChampionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChampionPassive",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChampionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionPassive", x => x.Id);
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
                    ChampionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullCost = table.Column<int>(type: "int", nullable: false),
                    IndividualCost = table.Column<int>(type: "int", nullable: false),
                    SellingCost = table.Column<int>(type: "int", nullable: false),
                    IsPurchasable = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RunePath",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatRuneRow",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatRuneRow", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SummonerSpells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tooltip = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BaseCooldown = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummonerSpells", x => x.Id);
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Champions",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lore = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Partype = table.Column<int>(type: "int", nullable: false),
                    WinRate = table.Column<double>(type: "float", nullable: false),
                    PickRate = table.Column<double>(type: "float", nullable: false),
                    BanRate = table.Column<double>(type: "float", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    PassiveId = table.Column<int>(type: "int", nullable: false),
                    InfoId = table.Column<int>(type: "int", nullable: false),
                    StatsId = table.Column<int>(type: "int", nullable: false),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Champions_ChampionInfo_InfoId",
                        column: x => x.InfoId,
                        principalTable: "ChampionInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Champions_ChampionPassive_PassiveId",
                        column: x => x.PassiveId,
                        principalTable: "ChampionPassive",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Champions_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Champions_ChampionStats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "ChampionStats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Runes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsKeystone = table.Column<bool>(type: "bit", nullable: false),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RunePathId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Runes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Runes_RunePath_RunePathId",
                        column: x => x.RunePathId,
                        principalTable: "RunePath",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatRune",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatRune", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatRune_StatRuneRow_RowId",
                        column: x => x.RowId,
                        principalTable: "StatRuneRow",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllyTip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                name: "BaseChampionAbilities",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AbilityType = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxRank = table.Column<byte>(type: "tinyint", nullable: false),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseChampionAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseChampionAbilities_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionAbilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickRate = table.Column<double>(type: "float", nullable: false),
                    WinRate = table.Column<double>(type: "float", nullable: false),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionAbilities_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PickRate = table.Column<double>(type: "float", nullable: false),
                    WinRate = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionItems_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickRate = table.Column<double>(type: "float", nullable: false),
                    WinRate = table.Column<double>(type: "float", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionRoles_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionRunes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickRate = table.Column<double>(type: "float", nullable: false),
                    WinRate = table.Column<double>(type: "float", nullable: false),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionRunes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionRunes_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionStarterItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PickRate = table.Column<double>(type: "float", nullable: false),
                    WinRate = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionStarterItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionStarterItems_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionSummonerSpells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickRate = table.Column<double>(type: "float", nullable: false),
                    WinRate = table.Column<double>(type: "float", nullable: false),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionSummonerSpells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionSummonerSpells_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionTag",
                columns: table => new
                {
                    ChampionsId = table.Column<string>(type: "nvarchar(450)", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "EnemyTip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
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
                name: "AbilitiesPerLevel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseChampionAbilityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Cooldown = table.Column<double>(type: "float", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false),
                    CostsPerSecond = table.Column<bool>(type: "bit", nullable: false),
                    Range = table.Column<double>(type: "float", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AbilitiesPerLevel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AbilitiesPerLevel_BaseChampionAbilities_BaseChampionAbilityId",
                        column: x => x.BaseChampionAbilityId,
                        principalTable: "BaseChampionAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaseChampionAbilityChampionAbilities",
                columns: table => new
                {
                    AbilitiesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChampionAbilitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseChampionAbilityChampionAbilities", x => new { x.AbilitiesId, x.ChampionAbilitiesId });
                    table.ForeignKey(
                        name: "FK_BaseChampionAbilityChampionAbilities_BaseChampionAbilities_AbilitiesId",
                        column: x => x.AbilitiesId,
                        principalTable: "BaseChampionAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseChampionAbilityChampionAbilities_ChampionAbilities_ChampionAbilitiesId",
                        column: x => x.ChampionAbilitiesId,
                        principalTable: "ChampionAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateTable(
                name: "ChampionRunesRune",
                columns: table => new
                {
                    ChampionRunesId = table.Column<int>(type: "int", nullable: false),
                    RunesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionRunesRune", x => new { x.ChampionRunesId, x.RunesId });
                    table.ForeignKey(
                        name: "FK_ChampionRunesRune_ChampionRunes_ChampionRunesId",
                        column: x => x.ChampionRunesId,
                        principalTable: "ChampionRunes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionRunesRune_Runes_RunesId",
                        column: x => x.RunesId,
                        principalTable: "Runes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionRunesStatRune",
                columns: table => new
                {
                    ChampionRunesId = table.Column<int>(type: "int", nullable: false),
                    StatRunesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionRunesStatRune", x => new { x.ChampionRunesId, x.StatRunesId });
                    table.ForeignKey(
                        name: "FK_ChampionRunesStatRune_ChampionRunes_ChampionRunesId",
                        column: x => x.ChampionRunesId,
                        principalTable: "ChampionRunes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionRunesStatRune_StatRune_StatRunesId",
                        column: x => x.StatRunesId,
                        principalTable: "StatRune",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionStarterItemsItem",
                columns: table => new
                {
                    ChampionStarterItemsId = table.Column<int>(type: "int", nullable: false),
                    ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionStarterItemsItem", x => new { x.ChampionStarterItemsId, x.ItemsId });
                    table.ForeignKey(
                        name: "FK_ChampionStarterItemsItem_ChampionStarterItems_ChampionStarterItemsId",
                        column: x => x.ChampionStarterItemsId,
                        principalTable: "ChampionStarterItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionStarterItemsItem_Items_ItemsId",
                        column: x => x.ItemsId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionSummonerSpellsSummonerSpell",
                columns: table => new
                {
                    ChampionSummonerSpellsId = table.Column<int>(type: "int", nullable: false),
                    SummonerSpellsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionSummonerSpellsSummonerSpell", x => new { x.ChampionSummonerSpellsId, x.SummonerSpellsId });
                    table.ForeignKey(
                        name: "FK_ChampionSummonerSpellsSummonerSpell_ChampionSummonerSpells_ChampionSummonerSpellsId",
                        column: x => x.ChampionSummonerSpellsId,
                        principalTable: "ChampionSummonerSpells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionSummonerSpellsSummonerSpell_SummonerSpells_SummonerSpellsId",
                        column: x => x.SummonerSpellsId,
                        principalTable: "SummonerSpells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AbilitiesPerLevel_BaseChampionAbilityId",
                table: "AbilitiesPerLevel",
                column: "BaseChampionAbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilitiesPerLevel_IsDeleted",
                table: "AbilitiesPerLevel",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_AllyTip_ChampionId",
                table: "AllyTip",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_AllyTip_IsDeleted",
                table: "AllyTip",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoles_IsDeleted",
                table: "AspNetRoles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IsDeleted",
                table: "AspNetUsers",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BaseChampionAbilities_ChampionId",
                table: "BaseChampionAbilities",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseChampionAbilities_IsDeleted",
                table: "BaseChampionAbilities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BaseChampionAbilityChampionAbilities_ChampionAbilitiesId",
                table: "BaseChampionAbilityChampionAbilities",
                column: "ChampionAbilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionAbilities_ChampionId",
                table: "ChampionAbilities",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionAbilities_IsDeleted",
                table: "ChampionAbilities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionInfo_IsDeleted",
                table: "ChampionInfo",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionItems_ChampionId",
                table: "ChampionItems",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionItems_IsDeleted",
                table: "ChampionItems",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionItemsItem_ItemsId",
                table: "ChampionItemsItem",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionPassive_IsDeleted",
                table: "ChampionPassive",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionRoles_ChampionId",
                table: "ChampionRoles",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionRoles_IsDeleted",
                table: "ChampionRoles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionRunes_ChampionId",
                table: "ChampionRunes",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionRunes_IsDeleted",
                table: "ChampionRunes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionRunesRune_RunesId",
                table: "ChampionRunesRune",
                column: "RunesId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionRunesStatRune_StatRunesId",
                table: "ChampionRunesStatRune",
                column: "StatRunesId");

            migrationBuilder.CreateIndex(
                name: "IX_Champions_ChampionId",
                table: "Champions",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_Champions_InfoId",
                table: "Champions",
                column: "InfoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Champions_IsDeleted",
                table: "Champions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Champions_PassiveId",
                table: "Champions",
                column: "PassiveId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Champions_StatsId",
                table: "Champions",
                column: "StatsId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChampionStarterItems_ChampionId",
                table: "ChampionStarterItems",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionStarterItems_IsDeleted",
                table: "ChampionStarterItems",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionStarterItemsItem_ItemsId",
                table: "ChampionStarterItemsItem",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionStats_IsDeleted",
                table: "ChampionStats",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionSummonerSpells_ChampionId",
                table: "ChampionSummonerSpells",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionSummonerSpells_IsDeleted",
                table: "ChampionSummonerSpells",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionSummonerSpellsSummonerSpell_SummonerSpellsId",
                table: "ChampionSummonerSpellsSummonerSpell",
                column: "SummonerSpellsId");

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
                name: "IX_Items_IsDeleted",
                table: "Items",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RunePath_IsDeleted",
                table: "RunePath",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Runes_IsDeleted",
                table: "Runes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Runes_RunePathId",
                table: "Runes",
                column: "RunePathId");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_IsDeleted",
                table: "Settings",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StatRune_IsDeleted",
                table: "StatRune",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StatRune_RowId",
                table: "StatRune",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_StatRuneRow_IsDeleted",
                table: "StatRuneRow",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_SummonerSpells_IsDeleted",
                table: "SummonerSpells",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_IsDeleted",
                table: "Tag",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilitiesPerLevel");

            migrationBuilder.DropTable(
                name: "AllyTip");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BaseChampionAbilityChampionAbilities");

            migrationBuilder.DropTable(
                name: "ChampionItemsItem");

            migrationBuilder.DropTable(
                name: "ChampionRoles");

            migrationBuilder.DropTable(
                name: "ChampionRunesRune");

            migrationBuilder.DropTable(
                name: "ChampionRunesStatRune");

            migrationBuilder.DropTable(
                name: "ChampionStarterItemsItem");

            migrationBuilder.DropTable(
                name: "ChampionSummonerSpellsSummonerSpell");

            migrationBuilder.DropTable(
                name: "ChampionTag");

            migrationBuilder.DropTable(
                name: "EnemyTip");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BaseChampionAbilities");

            migrationBuilder.DropTable(
                name: "ChampionAbilities");

            migrationBuilder.DropTable(
                name: "ChampionItems");

            migrationBuilder.DropTable(
                name: "Runes");

            migrationBuilder.DropTable(
                name: "ChampionRunes");

            migrationBuilder.DropTable(
                name: "StatRune");

            migrationBuilder.DropTable(
                name: "ChampionStarterItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ChampionSummonerSpells");

            migrationBuilder.DropTable(
                name: "SummonerSpells");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "RunePath");

            migrationBuilder.DropTable(
                name: "StatRuneRow");

            migrationBuilder.DropTable(
                name: "Champions");

            migrationBuilder.DropTable(
                name: "ChampionInfo");

            migrationBuilder.DropTable(
                name: "ChampionPassive");

            migrationBuilder.DropTable(
                name: "ChampionStats");
        }
    }
}
