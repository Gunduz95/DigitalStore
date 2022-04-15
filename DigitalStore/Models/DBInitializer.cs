using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DigitalStore.Models
{
    public class DBInitializer : DropCreateDatabaseAlways<DigitalStoreContext>
    {
        protected override void Seed(DigitalStoreContext context)
        {
            context.Manufacturers.Add(new Manufacturer() { Name = "Sony" });
            context.Manufacturers.Add(new Manufacturer() { Name = "Samsung" });
            context.Manufacturers.Add(new Manufacturer() { Name = "Apple" });
            context.Manufacturers.Add(new Manufacturer() { Name = "HTC" });
            context.Manufacturers.Add(new Manufacturer() { Name = "Logitech" });

            context.Categories.Add(new Category() { Name = "Смартфоны" });
            context.Categories.Add(new Category() { Name = "Ноутбуки" });
            context.Categories.Add(new Category() { Name = "Планшеты" });
            context.Categories.Add(new Category() { Name = "Приставки" });

            context.SaveChanges();

            context.Products.Add(new Product()
            {
                Name = "TestProduct",
                CategoryId = 1,
                ManufacturerId = 1,
                Description = "TestProduct",
                Price = 100
            });

            base.Seed(context);
        }
    }
}