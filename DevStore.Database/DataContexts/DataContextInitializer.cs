using System.Data.Entity;
using DevStore.Domain;

namespace DevStore.Database.DataContexts
{
    public class DataContextInitializer: DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Categories.Add(new Category { Id = 1, Title = "Informática" });
            context.Categories.Add(new Category { Id = 2, Title = "Games" });
            context.Categories.Add(new Category { Id = 3, Title = "Papelaria" });
            context.SaveChanges();


            context.Products.Add(new Product { Id = 1, CategoryId = 1, IsActive = true, Price = 10, Title = "Mouse" });
            context.Products.Add(new Product { Id = 2, CategoryId = 1, IsActive = true, Price = 20.2m, Title = "Pendrive" });
            context.Products.Add(new Product { Id = 3, CategoryId = 1, IsActive = true, Price = 50, Title = "Teclado s/ fio" });

            context.Products.Add(new Product { Id = 4, CategoryId = 2, IsActive = true, Price = 100.5m, Title = "PES 2015" });
            context.Products.Add(new Product { Id = 5, CategoryId = 2, IsActive = true, Price = 250, Title = "GTA V" });
            context.Products.Add(new Product { Id = 6, CategoryId = 2, IsActive = true, Price = 110, Title = "FIFA 15" });

            context.Products.Add(new Product { Id = 7, CategoryId = 3, IsActive = true, Price = 3, Title = "Caneta" });
            context.Products.Add(new Product { Id = 8, CategoryId = 3, IsActive = true, Price = 2, Title = "Lápis" });
            context.Products.Add(new Product { Id = 9, CategoryId = 3, IsActive = true, Price = 1.5m, Title = "Borracha" });
            context.SaveChanges();
        }
    }
}