using Microsoft.EntityFrameworkCore;

namespace MsServiceApp.Infraestructure
{
    public class ApplicationDbContext : DbContext
    {
        private readonly EntityInterceptor _entityInterceptor;
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            EntityInterceptor entityInterceptor
            ) : base(options)
        {
            _entityInterceptor = entityInterceptor ?? throw new ArgumentNullException(nameof(entityInterceptor));
        }

        #region Person

        public DbSet<Person> Persons { get; set; }

        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_entityInterceptor);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Persona

            modelBuilder.ApplyConfiguration(new PersonConfigurarion());
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}