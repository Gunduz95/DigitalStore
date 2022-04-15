using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using DigitalStore.Repository;
using DigitalStore.Models;

namespace DigitalStore.Tests
{
    [TestClass]
    public class RepositoryTest
    {
        [TestMethod]
        public void CreateCategoryTest()
        {
            IRepository<Category> db = new CategoryRepository();
            Category item = new Category() { Name = "TestCategory" };
            db.Create(item);
            db.Save();
        }

        [TestMethod]
        public void CreateManufacturerTest()
        {
            IRepository<Manufacturer> db = new ManufacturersRepository();
            Manufacturer item = new Manufacturer() { Name = "TestManufacturer" };
            db.Create(item);
            db.Save();
        }

        [TestMethod]
        public void CreateProductTest()
        {
            IRepository<Product> db = new ProductsRepository();
            Product item = new Product()
            {
                CategoryId = 1,
                ManufacturerId = 1,
                Name = "TestProduct",
                Description = "Test",
                Price = 100
            };
            db.Create(item);
            db.Save();
        }

        [TestMethod]
        public void GetManufacturerTest()
        {
            IRepository<Manufacturer> db = new ManufacturersRepository();
            Manufacturer manufacturer = db.GetById(1);
            Assert.IsNotNull(manufacturer);
        }

        [TestMethod]
        public void GetCategoryTest()
        {
            IRepository<Category> db = new CategoryRepository();
            Category category = db.GetById(1);
            Assert.IsNotNull(category);
        }

        [TestMethod]
        public void GetProductTest()
        {
            CreateProductTest();
            IRepository<Product> db = new ProductsRepository();
            Product product = db.GetAll().FirstOrDefault(i => i.Name == "TestProduct"); ;
            Assert.IsNotNull(product);
        }

        [TestMethod]
        public void EditCategoryTest()
        {
            IRepository<Category> db = new CategoryRepository();
            Category category = db.GetAll().FirstOrDefault(i => i.Name == "TestCategory");
            category.Name = "TestCategory1";
            db.Update(category);
            db.Save();
        }

        [TestMethod]
        public void EditManufacturerTest()
        {
            IRepository<Manufacturer> db = new ManufacturersRepository();
            Manufacturer manufacturer = db.GetAll().FirstOrDefault(i => i.Name == "TestManufacturer");
            manufacturer.Name = "TestManufacturer1";
            db.Update(manufacturer);
            db.Save();
        }

        [TestMethod]
        public void EditProductTest()
        {
            IRepository<Product> db = new ProductsRepository();
            Product product = db.GetAll().FirstOrDefault(i => i.Name == "TestProduct");
            product.Name = "TestProduct";
            db.Update(product);
            db.Save();
        }

        [TestMethod]
        public void DeleteManufacturerTest()
        {
            CreateManufacturerTest();
            IRepository<Manufacturer> db = new ManufacturersRepository();
            Manufacturer manufacturer = db.GetAll().FirstOrDefault(i => i.Name == "TestManufacturer");
            db.Delete(manufacturer.Id);
        }

        [TestMethod]
        public void DeleteCategoryTest()
        {
            CreateCategoryTest();
            IRepository<Category> db = new CategoryRepository();
            Category category = db.GetAll().FirstOrDefault(i => i.Name == "TestCategory");
            db.Delete(category.Id);
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            CreateProductTest();
            IRepository<Product> db = new ProductsRepository();
            Product product = db.GetAll().FirstOrDefault(i => i.Name == "TestProduct");
            db.Delete(product.Id);
        }
    }
}
