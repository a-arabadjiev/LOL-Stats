namespace LoLStats.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;

    using LoLStats.Data.Common.Models;
    using LoLStats.Data.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AbilityPerLevel> AbilitiesPerLevel { get; set; }

        public DbSet<AllyTip> AllyTips { get; set; }

        public DbSet<EnemyTip> EnemyTips { get; set; }

        public DbSet<Tag> ChampionTags { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<Rune> Runes { get; set; }

        public DbSet<StatRuneRow> StatRuneRows { get; set; }

        public DbSet<StatRune> StatRunes { get; set; }

        public DbSet<RunePath> RunePaths { get; set; }

        public DbSet<Champion> Champions { get; set; }

        public DbSet<SummonerSpell> SummonerSpells { get; set; }

        public DbSet<BaseAbility> BaseAbilities { get; set; }

        public DbSet<ChampionAbilities> ChampionsAbilities { get; set; }

        public DbSet<ChampionAbilitiesAbility> ChampionsAbilitiesAbility { get; set; }

        public DbSet<CounterChampion> CounterChampions { get; set; }

        public DbSet<ChampionCounterChampions> ChampionCounterChampions { get; set; }

        public DbSet<ChampionInfo> ChampionsInfo { get; set; }

        public DbSet<ChampionItemsItem> ChampionsItemsItem { get; set; }

        public DbSet<ChampionStarterItemsItem> ChampionsStarterItemsItem { get; set; }

        public DbSet<ChampionPassive> ChampionPassives { get; set; }

        public DbSet<ChampionItems> ChampionsItems { get; set; }

        public DbSet<ChampionRole> ChampionsRoles { get; set; }

        public DbSet<ChampionRunes> ChampionsRunes { get; set; }

        public DbSet<ChampionRunesRune> ChampionsRunesRune { get; set; }

        public DbSet<ChampionRunesStatRune> ChampionsRunesStatRune { get; set; }

        public DbSet<ChampionSummonerSpells> ChampionsSummonerSpell { get; set; }

        public DbSet<ChampionSummonerSpellsSummonerSpell> ChampionsSummonerSpellsSummonerSpell { get; set; }

        public DbSet<ChampionStats> ChampionsStats { get; set; }

        public DbSet<Setting> Settings { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
