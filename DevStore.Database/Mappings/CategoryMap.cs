using System.Data.Entity.ModelConfiguration;
using DevStore.Domain;

namespace DevStore.Database.Mappings
{
    public class CategoryMap: EntityTypeConfiguration<Category>
    {
        public CategoryMap()
        {
            ToTable("Category");

            HasKey(x => x.Id);

            Property(x => x.Title)
                .HasMaxLength(60)
                .IsRequired();
        }
    }
}