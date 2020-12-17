using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoLStats.Data.Migrations
{
    public partial class Create : Migration
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
                name: "ChampionPassives",
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
                    table.PrimaryKey("PK_ChampionPassives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChampionsInfo",
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
                    table.PrimaryKey("PK_ChampionsInfo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChampionsStats",
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
                    table.PrimaryKey("PK_ChampionsStats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChampionTags",
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
                    table.PrimaryKey("PK_ChampionTags", x => x.Id);
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
                name: "RunePaths",
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
                    table.PrimaryKey("PK_RunePaths", x => x.Id);
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
                name: "StatRuneRows",
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
                    table.PrimaryKey("PK_StatRuneRows", x => x.Id);
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
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsFree = table.Column<bool>(type: "bit", nullable: false),
                    PassiveId = table.Column<int>(type: "int", nullable: false),
                    InfoId = table.Column<int>(type: "int", nullable: false),
                    StatsId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Champions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Champions_ChampionPassives_PassiveId",
                        column: x => x.PassiveId,
                        principalTable: "ChampionPassives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Champions_ChampionsInfo_InfoId",
                        column: x => x.InfoId,
                        principalTable: "ChampionsInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Champions_ChampionsStats_StatsId",
                        column: x => x.StatsId,
                        principalTable: "ChampionsStats",
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
                        name: "FK_Runes_RunePaths_RunePathId",
                        column: x => x.RunePathId,
                        principalTable: "RunePaths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StatRunes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuneType = table.Column<int>(type: "int", nullable: false),
                    RowId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatRunes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StatRunes_StatRuneRows_RowId",
                        column: x => x.RowId,
                        principalTable: "StatRuneRows",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AllyTips",
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
                    table.PrimaryKey("PK_AllyTips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllyTips_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaseAbilities",
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
                    table.PrimaryKey("PK_BaseAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BaseAbilities_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionCounters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CounterChampionName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CounterChapmionKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WinRate = table.Column<double>(type: "float", nullable: false),
                    TotalMatches = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionCounters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionCounters_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionsAbilities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalMatches = table.Column<int>(type: "int", nullable: false),
                    WinRate = table.Column<double>(type: "float", nullable: false),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionsAbilities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionsAbilities_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionsItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WinRate = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionsItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionsItems_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionsRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<int>(type: "int", nullable: false),
                    Tier = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PickRate = table.Column<double>(type: "float", nullable: false),
                    WinRate = table.Column<double>(type: "float", nullable: false),
                    TotalMatches = table.Column<int>(type: "int", nullable: false),
                    BanRate = table.Column<double>(type: "float", nullable: false),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionsRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionsRoles_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionsRunes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalMatches = table.Column<int>(type: "int", nullable: false),
                    WinRate = table.Column<double>(type: "float", nullable: false),
                    MainRuneTree = table.Column<int>(type: "int", nullable: false),
                    SecondaryRuneTree = table.Column<int>(type: "int", nullable: false),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionsRunes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionsRunes_Champions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "Champions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionsSummonerSpell",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalMatches = table.Column<int>(type: "int", nullable: false),
                    WinRate = table.Column<double>(type: "float", nullable: false),
                    ChampionId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionsSummonerSpell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionsSummonerSpell_Champions_ChampionId",
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
                    PickRate = table.Column<int>(type: "int", nullable: false),
                    WinRate = table.Column<int>(type: "int", nullable: false),
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
                        name: "FK_ChampionTag_ChampionTags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "ChampionTags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EnemyTips",
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
                    table.PrimaryKey("PK_EnemyTips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EnemyTips_Champions_ChampionId",
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
                    BaseChampionAbilityId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbilityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Level = table.Column<byte>(type: "tinyint", nullable: false),
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
                        name: "FK_AbilitiesPerLevel_BaseAbilities_AbilityId",
                        column: x => x.AbilityId,
                        principalTable: "BaseAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BaseAbilityChampionAbilities",
                columns: table => new
                {
                    AbilitiesId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChampionAbilitiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BaseAbilityChampionAbilities", x => new { x.AbilitiesId, x.ChampionAbilitiesId });
                    table.ForeignKey(
                        name: "FK_BaseAbilityChampionAbilities_BaseAbilities_AbilitiesId",
                        column: x => x.AbilitiesId,
                        principalTable: "BaseAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BaseAbilityChampionAbilities_ChampionsAbilities_ChampionAbilitiesId",
                        column: x => x.ChampionAbilitiesId,
                        principalTable: "ChampionsAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionsAbilitiesAbility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChampionAbilitiesId = table.Column<int>(type: "int", nullable: false),
                    BaseAbilityId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionsAbilitiesAbility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionsAbilitiesAbility_BaseAbilities_BaseAbilityId",
                        column: x => x.BaseAbilityId,
                        principalTable: "BaseAbilities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionsAbilitiesAbility_ChampionsAbilities_ChampionAbilitiesId",
                        column: x => x.ChampionAbilitiesId,
                        principalTable: "ChampionsAbilities",
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
                        name: "FK_ChampionItemsItem_ChampionsItems_ChampionItemsId",
                        column: x => x.ChampionItemsId,
                        principalTable: "ChampionsItems",
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
                name: "ChampionsItemsItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ChampionItemsId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionsItemsItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionsItemsItem_ChampionsItems_ChampionItemsId",
                        column: x => x.ChampionItemsId,
                        principalTable: "ChampionsItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionsItemsItem_Items_ItemId",
                        column: x => x.ItemId,
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
                        name: "FK_ChampionRunesRune_ChampionsRunes_ChampionRunesId",
                        column: x => x.ChampionRunesId,
                        principalTable: "ChampionsRunes",
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
                        name: "FK_ChampionRunesStatRune_ChampionsRunes_ChampionRunesId",
                        column: x => x.ChampionRunesId,
                        principalTable: "ChampionsRunes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionRunesStatRune_StatRunes_StatRunesId",
                        column: x => x.StatRunesId,
                        principalTable: "StatRunes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionsRunesRune",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RuneId = table.Column<int>(type: "int", nullable: false),
                    ChampionRunesId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionsRunesRune", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionsRunesRune_ChampionsRunes_ChampionRunesId",
                        column: x => x.ChampionRunesId,
                        principalTable: "ChampionsRunes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionsRunesRune_Runes_RuneId",
                        column: x => x.RuneId,
                        principalTable: "Runes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionsRunesStatRune",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatRuneId = table.Column<int>(type: "int", nullable: false),
                    ChampionRunesId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionsRunesStatRune", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionsRunesStatRune_ChampionsRunes_ChampionRunesId",
                        column: x => x.ChampionRunesId,
                        principalTable: "ChampionsRunes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionsRunesStatRune_StatRunes_StatRuneId",
                        column: x => x.StatRuneId,
                        principalTable: "StatRunes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionsSummonerSpellsSummonerSpell",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SummonerSpellId = table.Column<int>(type: "int", nullable: false),
                    ChampionSummonerSpellsId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionsSummonerSpellsSummonerSpell", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionsSummonerSpellsSummonerSpell_ChampionsSummonerSpell_ChampionSummonerSpellsId",
                        column: x => x.ChampionSummonerSpellsId,
                        principalTable: "ChampionsSummonerSpell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionsSummonerSpellsSummonerSpell_SummonerSpells_SummonerSpellId",
                        column: x => x.SummonerSpellId,
                        principalTable: "SummonerSpells",
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
                        name: "FK_ChampionSummonerSpellsSummonerSpell_ChampionsSummonerSpell_ChampionSummonerSpellsId",
                        column: x => x.ChampionSummonerSpellsId,
                        principalTable: "ChampionsSummonerSpell",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionSummonerSpellsSummonerSpell_SummonerSpells_SummonerSpellsId",
                        column: x => x.SummonerSpellsId,
                        principalTable: "SummonerSpells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChampionsStarterItemsItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    ChampionStarterItemsId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChampionsStarterItemsItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChampionsStarterItemsItem_ChampionStarterItems_ChampionStarterItemsId",
                        column: x => x.ChampionStarterItemsId,
                        principalTable: "ChampionStarterItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ChampionsStarterItemsItem_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
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

            migrationBuilder.CreateIndex(
                name: "IX_AbilitiesPerLevel_AbilityId",
                table: "AbilitiesPerLevel",
                column: "AbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_AbilitiesPerLevel_IsDeleted",
                table: "AbilitiesPerLevel",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_AllyTips_ChampionId",
                table: "AllyTips",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_AllyTips_IsDeleted",
                table: "AllyTips",
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
                name: "IX_BaseAbilities_ChampionId",
                table: "BaseAbilities",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAbilities_IsDeleted",
                table: "BaseAbilities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_BaseAbilityChampionAbilities_ChampionAbilitiesId",
                table: "BaseAbilityChampionAbilities",
                column: "ChampionAbilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionCounters_ChampionId",
                table: "ChampionCounters",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionCounters_IsDeleted",
                table: "ChampionCounters",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionItemsItem_ItemsId",
                table: "ChampionItemsItem",
                column: "ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionPassives_IsDeleted",
                table: "ChampionPassives",
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
                name: "IX_ChampionsAbilities_ChampionId",
                table: "ChampionsAbilities",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsAbilities_IsDeleted",
                table: "ChampionsAbilities",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsAbilitiesAbility_BaseAbilityId",
                table: "ChampionsAbilitiesAbility",
                column: "BaseAbilityId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsAbilitiesAbility_ChampionAbilitiesId",
                table: "ChampionsAbilitiesAbility",
                column: "ChampionAbilitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsAbilitiesAbility_IsDeleted",
                table: "ChampionsAbilitiesAbility",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsInfo_IsDeleted",
                table: "ChampionsInfo",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsItems_ChampionId",
                table: "ChampionsItems",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsItems_IsDeleted",
                table: "ChampionsItems",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsItemsItem_ChampionItemsId",
                table: "ChampionsItemsItem",
                column: "ChampionItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsItemsItem_IsDeleted",
                table: "ChampionsItemsItem",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsItemsItem_ItemId",
                table: "ChampionsItemsItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsRoles_ChampionId",
                table: "ChampionsRoles",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsRoles_IsDeleted",
                table: "ChampionsRoles",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsRunes_ChampionId",
                table: "ChampionsRunes",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsRunes_IsDeleted",
                table: "ChampionsRunes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsRunesRune_ChampionRunesId",
                table: "ChampionsRunesRune",
                column: "ChampionRunesId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsRunesRune_IsDeleted",
                table: "ChampionsRunesRune",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsRunesRune_RuneId",
                table: "ChampionsRunesRune",
                column: "RuneId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsRunesStatRune_ChampionRunesId",
                table: "ChampionsRunesStatRune",
                column: "ChampionRunesId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsRunesStatRune_IsDeleted",
                table: "ChampionsRunesStatRune",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsRunesStatRune_StatRuneId",
                table: "ChampionsRunesStatRune",
                column: "StatRuneId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsStarterItemsItem_ChampionStarterItemsId",
                table: "ChampionsStarterItemsItem",
                column: "ChampionStarterItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsStarterItemsItem_IsDeleted",
                table: "ChampionsStarterItemsItem",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsStarterItemsItem_ItemId",
                table: "ChampionsStarterItemsItem",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsStats_IsDeleted",
                table: "ChampionsStats",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsSummonerSpell_ChampionId",
                table: "ChampionsSummonerSpell",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsSummonerSpell_IsDeleted",
                table: "ChampionsSummonerSpell",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsSummonerSpellsSummonerSpell_ChampionSummonerSpellsId",
                table: "ChampionsSummonerSpellsSummonerSpell",
                column: "ChampionSummonerSpellsId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsSummonerSpellsSummonerSpell_IsDeleted",
                table: "ChampionsSummonerSpellsSummonerSpell",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionsSummonerSpellsSummonerSpell_SummonerSpellId",
                table: "ChampionsSummonerSpellsSummonerSpell",
                column: "SummonerSpellId");

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
                name: "IX_ChampionSummonerSpellsSummonerSpell_SummonerSpellsId",
                table: "ChampionSummonerSpellsSummonerSpell",
                column: "SummonerSpellsId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionTag_TagsId",
                table: "ChampionTag",
                column: "TagsId");

            migrationBuilder.CreateIndex(
                name: "IX_ChampionTags_IsDeleted",
                table: "ChampionTags",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyTips_ChampionId",
                table: "EnemyTips",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_EnemyTips_IsDeleted",
                table: "EnemyTips",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Items_IsDeleted",
                table: "Items",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RunePaths_IsDeleted",
                table: "RunePaths",
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
                name: "IX_StatRuneRows_IsDeleted",
                table: "StatRuneRows",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StatRunes_IsDeleted",
                table: "StatRunes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_StatRunes_RowId",
                table: "StatRunes",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_SummonerSpells_IsDeleted",
                table: "SummonerSpells",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AbilitiesPerLevel");

            migrationBuilder.DropTable(
                name: "AllyTips");

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
                name: "BaseAbilityChampionAbilities");

            migrationBuilder.DropTable(
                name: "ChampionCounters");

            migrationBuilder.DropTable(
                name: "ChampionItemsItem");

            migrationBuilder.DropTable(
                name: "ChampionRunesRune");

            migrationBuilder.DropTable(
                name: "ChampionRunesStatRune");

            migrationBuilder.DropTable(
                name: "ChampionsAbilitiesAbility");

            migrationBuilder.DropTable(
                name: "ChampionsItemsItem");

            migrationBuilder.DropTable(
                name: "ChampionsRoles");

            migrationBuilder.DropTable(
                name: "ChampionsRunesRune");

            migrationBuilder.DropTable(
                name: "ChampionsRunesStatRune");

            migrationBuilder.DropTable(
                name: "ChampionsStarterItemsItem");

            migrationBuilder.DropTable(
                name: "ChampionsSummonerSpellsSummonerSpell");

            migrationBuilder.DropTable(
                name: "ChampionStarterItemsItem");

            migrationBuilder.DropTable(
                name: "ChampionSummonerSpellsSummonerSpell");

            migrationBuilder.DropTable(
                name: "ChampionTag");

            migrationBuilder.DropTable(
                name: "EnemyTips");

            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "BaseAbilities");

            migrationBuilder.DropTable(
                name: "ChampionsAbilities");

            migrationBuilder.DropTable(
                name: "ChampionsItems");

            migrationBuilder.DropTable(
                name: "Runes");

            migrationBuilder.DropTable(
                name: "ChampionsRunes");

            migrationBuilder.DropTable(
                name: "StatRunes");

            migrationBuilder.DropTable(
                name: "ChampionStarterItems");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "ChampionsSummonerSpell");

            migrationBuilder.DropTable(
                name: "SummonerSpells");

            migrationBuilder.DropTable(
                name: "ChampionTags");

            migrationBuilder.DropTable(
                name: "RunePaths");

            migrationBuilder.DropTable(
                name: "StatRuneRows");

            migrationBuilder.DropTable(
                name: "Champions");

            migrationBuilder.DropTable(
                name: "ChampionPassives");

            migrationBuilder.DropTable(
                name: "ChampionsInfo");

            migrationBuilder.DropTable(
                name: "ChampionsStats");
        }
    }
}
