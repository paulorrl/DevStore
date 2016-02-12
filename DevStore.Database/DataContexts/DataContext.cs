using System.Data.Entity;
using DevStore.Database.Mappings;
using DevStore.Domain;

namespace DevStore.Database.DataContexts
{
    public class DataContext : DbContext
    {
        public DataContext()
            : base("DevStoreConnectionString")
        {
            System.Data.Entity.
                Database.SetInitializer<DataContext>(new DataContextInitializer());

            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new CategoryMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}