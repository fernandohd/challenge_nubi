using System.Linq;
using Challenge.Domain.Mapping;
using Challenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Challenge.Domain.Contexts
{
    public class ChallengeDbContext : DbContext
    {
        public ChallengeDbContext() : base(new DbContextOptionsBuilder<ChallengeDbContext>().Options)
        { }

        public ChallengeDbContext(DbContextOptions<ChallengeDbContext> option)
            : base(option) { }

        public virtual DbSet<UserEntity> User { get; set; }
        public virtual DbSet<ConversionEntity> Conversion { get; set; }
        public virtual DbSet<CurrencyHistoryEntity> CurrencyHistory { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new ConversionMapping());
            modelBuilder.ApplyConfiguration(new CurrencyHistoryMapping());
        }

        public bool Exists<TEntity>() where TEntity : class
        {
            var attachedEntity = ChangeTracker.Entries<TEntity>().FirstOrDefault();
            return (attachedEntity != null);
        }
    }
}
