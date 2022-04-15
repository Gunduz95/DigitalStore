using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DigitalStore.Repository;
using DigitalStore.Models;
using DigitalStore.Controllers;
using System.Linq;
using System.Data.Entity;

namespace DigitalStore.Tests
{
    [TestClass]
    public class DbContextTest
    {
        [TestMethod]
        public void CreateCategoryTest()
        {
            DigitalStoreContext db = new DigitalStoreContext();
            Category category = new Category() { Name = "TestCategory" };
            db.Categories.Add(category);
            db.SaveChanges();
        }

        [TestMethod]
        public void CreateManufacturerTest()
        {
            DigitalStoreContext db = new DigitalStoreContext();
            Manufacturer manufacturer = new Manufacturer() { Name = "TestManufacturer" };
            db.Manufacturers.Add(manufacturer);
            db.SaveChanges();
        }

        [TestMethod]
        public void CreateProductTest()
        {
            DigitalStoreContext db = new DigitalStoreContext();
            Product product = new Product() 
            { 
                CategoryId = 1,
                ManufacturerId = 1,
                Name = "TestProduct",
                Description = "Test",
                Price = 100
            };
            db.Products.Add(product);
            db.SaveChanges();
        }

        [TestMethod]
        public void GetManufacturerTest()
        {
            DigitalStoreContext db = new DigitalStoreContext();
            Manufacturer manufacturer = db.Manufacturers.Find(1);
            Assert.IsNotNull(manufacturer);
        }

        [TestMethod]
        public void GetCategoryTest()
        {
            DigitalStoreContext db = new DigitalStoreContext();
            Category category = db.Categories.Find(1);
            Assert.IsNotNull(category);
        }

        [TestMethod]
        public void GetProductTest()
        {
            CreateProductTest();
            DigitalStoreContext db = new DigitalStoreContext();
            var p = db.Products.ToArray();
            Product product = db.Products.FirstOrDefault(i => i.Name == "TestProduct");
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void EditCategoryTest()
        {
            CreateCategoryTest();
            DigitalStoreContext db = new DigitalStoreContext();
            Category category = db.Categories.FirstOrDefault(i => i.Name == "TestCategory");
            category.Name = "TestCategory1";
            db.Entry(category).State = EntityState.Modified;
            db.SaveChanges();
        }

        [TestMethod]
        public void EditManufacturerTest()
        {
            CreateManufacturerTest();
            DigitalStoreContext db = new DigitalStoreContext();
            Manufacturer manufacturer = db.Manufacturers.FirstOrDefault(i => i.Name == "TestManufacturer");
            manufacturer.Name = "TestManufacturer1";
            db.Entry(manufacturer).State = EntityState.Modified;
            db.SaveChanges();
        }

        [TestMethod]
        public void EditProductTest()
        {
            CreateProductTest();
            DigitalStoreContext db = new DigitalStoreContext();
            Product product = db.Products.FirstOrDefault(i => i.Name == "TestProduct");
            product.Name = "TestProduct1";
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }

        [TestMethod]
        public void DeleteManufacturerTest()
        {
            DigitalStoreContext db = new DigitalStoreContext();
            Manufacturer manufacturer = db.Manufacturers.FirstOrDefault(i => i.Name == "TestManufacturer");
            db.Manufacturers.Remove(manufacturer);
            db.SaveChanges();
        }

        [TestMethod]
        public void DeleteCategoryTest()
        {
            DigitalStoreContext db = new DigitalStoreContext();
            Category category = db.Categories.FirstOrDefault(i => i.Name == "TestCategory");
            db.Categories.Remove(category);
            db.SaveChanges();
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            DigitalStoreContext db = new DigitalStoreContext();
            Product product = db.Products.FirstOrDefault(i => i.Name == "TestProduct");
            db.Products.Remove(product);
            db.SaveChanges();
        }
    }
}
