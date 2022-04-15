using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using DigitalStore.Repository;
using DigitalStore.Models;
using DigitalStore.Controllers;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DigitalStore.Tests
{
    [TestClass]
    public class ProductsControllerTest
    {
        [TestMethod]
        public void IndexNotNullTest()
        {
            var mock1 = new Mock<IRepository<Product>>();
            var mock2 = new Mock<IRepository<Category>>();
            var mock3 = new Mock<IRepository<Manufacturer>>();
            mock1.Setup(m => m.GetAll()).Returns(new List<Product>());
            mock2.Setup(m => m.GetAll()).Returns(new List<Category>());
            mock3.Setup(m => m.GetAll()).Returns(new List<Manufacturer>());
            ProductsController controller = new ProductsController(mock1.Object, mock2.Object, mock3.Object);

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void DetailsNotNullTest()
        {
            var mock1 = new Mock<IRepository<Product>>();
            var mock2 = new Mock<IRepository<Category>>();
            var mock3 = new Mock<IRepository<Manufacturer>>();
            mock1.Setup(m => m.GetById(1)).Returns( new Product() { Id = 1 } );
            mock2.Setup(m => m.GetAll()).Returns(new List<Category>() { new Category() });
            mock3.Setup(m => m.GetAll()).Returns(new List<Manufacturer>() { new Manufacturer() });
            ProductsController controller = new ProductsController(mock1.Object, mock2.Object, mock3.Object);

            ViewResult result = controller.Details(1) as ViewResult;
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void DeleteNotNullTest()
        {
            var mock1 = new Mock<IRepository<Product>>();
            var mock2 = new Mock<IRepository<Category>>();
            var mock3 = new Mock<IRepository<Manufacturer>>();
            mock1.Setup(m => m.GetById(1)).Returns(new Product() { Id = 1 });
            mock2.Setup(m => m.GetAll()).Returns(new List<Category>() { new Category() });
            mock3.Setup(m => m.GetAll()).Returns(new List<Manufacturer>() { new Manufacturer() });
            ProductsController controller = new ProductsController(mock1.Object, mock2.Object, mock3.Object);

            ViewResult result = controller.Delete(1) as ViewResult;
            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void CreateNotNullTest()
        {
            var mock1 = new Mock<IRepository<Product>>();
            var mock2 = new Mock<IRepository<Category>>();
            var mock3 = new Mock<IRepository<Manufacturer>>();
            mock2.Setup(m => m.GetAll()).Returns(new List<Category>() { new Category() });
            mock3.Setup(m => m.GetAll()).Returns(new List<Manufacturer>() { new Manufacturer() });
            ProductsController controller = new ProductsController(mock1.Object, mock2.Object, mock3.Object);

            ViewResult result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void CreateViewBagTest()
        {
            var mock1 = new Mock<IRepository<Product>>();
            var mock2 = new Mock<IRepository<Category>>();
            var mock3 = new Mock<IRepository<Manufacturer>>();
            mock2.Setup(m => m.GetAll()).Returns(new List<Category>() { new Category() });
            mock3.Setup(m => m.GetAll()).Returns(new List<Manufacturer>() { new Manufacturer() });
            ProductsController controller = new ProductsController(mock1.Object, mock2.Object, mock3.Object);

            ViewResult result = controller.Create() as ViewResult;

            var cat = result.ViewBag.CategoryId as SelectList;
            var man = result.ViewBag.ManufacturerId as SelectList;
            Assert.IsNotNull(result);
            Assert.IsNotNull(cat);
            Assert.IsNotNull(man);
        }

        [TestMethod]
        public void CreateViewBagCountTest()
        {
            var mock1 = new Mock<IRepository<Product>>();
            var mock2 = new Mock<IRepository<Category>>();
            var mock3 = new Mock<IRepository<Manufacturer>>();
            mock2.Setup(m => m.GetAll()).Returns(new List<Category>() { new Category() });
            mock3.Setup(m => m.GetAll()).Returns(new List<Manufacturer>() { new Manufacturer() });
            ProductsController controller = new ProductsController(mock1.Object, mock2.Object, mock3.Object);

            ViewResult result = controller.Create() as ViewResult;

            var cat = result.ViewBag.CategoryId as SelectList;
            var man = result.ViewBag.ManufacturerId as SelectList;
            int? categoriesCount = (cat.Items as List<Category>)?.Count;
            int? manufacturersCount = (man.Items as List<Manufacturer>)?.Count;

            Assert.AreEqual(categoriesCount, 1);
            Assert.AreEqual(manufacturersCount, 1);
        }

        [TestMethod]
        public void CreatePostAction_RedirectToIndexView()
        {
            var mock1 = new Mock<IRepository<Product>>();
            var mock2 = new Mock<IRepository<Category>>();
            var mock3 = new Mock<IRepository<Manufacturer>>();
            Product p = new Product();
            mock2.Setup(m => m.GetAll()).Returns(new List<Category>() { new Category() });
            mock3.Setup(m => m.GetAll()).Returns(new List<Manufacturer>() { new Manufacturer() });
            ProductsController controller = new ProductsController(mock1.Object, mock2.Object, mock3.Object);
            
            RedirectToRouteResult result = controller.Create(p) as RedirectToRouteResult;
            string expected = "Index";
            
            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        [TestMethod]
        public void EditPostAction_RedirectToIndexView()
        {
            var mock1 = new Mock<IRepository<Product>>();
            var mock2 = new Mock<IRepository<Category>>();
            var mock3 = new Mock<IRepository<Manufacturer>>();
            Product p = new Product();
            mock2.Setup(m => m.GetAll()).Returns(new List<Category>() { new Category() });
            mock3.Setup(m => m.GetAll()).Returns(new List<Manufacturer>() { new Manufacturer() });
            ProductsController controller = new ProductsController(mock1.Object, mock2.Object, mock3.Object);

            RedirectToRouteResult result = controller.Edit(p) as RedirectToRouteResult;
            string expected = "Index";

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        [TestMethod]
        public void DeletePostAction_RedirectToIndexView()
        {
            var mock1 = new Mock<IRepository<Product>>();
            var mock2 = new Mock<IRepository<Category>>();
            var mock3 = new Mock<IRepository<Manufacturer>>();
            mock1.Setup(m => m.GetById(1)).Returns(new Product() { Id = 1 });
            mock2.Setup(m => m.GetAll()).Returns(new List<Category>() { new Category() });
            mock3.Setup(m => m.GetAll()).Returns(new List<Manufacturer>() { new Manufacturer() });
            ProductsController controller = new ProductsController(mock1.Object, mock2.Object, mock3.Object);

            RedirectToRouteResult result = controller.DeleteConfirmed(1) as RedirectToRouteResult;
            string expected = "Index";

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        [TestMethod]
        public void ProductNameLenghtTest1()
        {
            Product p = new Product() { Id = 1, Name = "abc" };

            Assert.IsTrue(ValidateModel(p).Any(
                v => v.MemberNames.Contains("Name") &&
                v.ErrorMessage.Contains("Наименование должно быть в пределах 5 - 50 символов")));
        }

        [TestMethod]
        public void ProductNameLenghtTest2()
        {
            Product p = new Product() { Id = 1, Name = "abcdef" };

            Assert.IsFalse(ValidateModel(p).Any(
                v => v.MemberNames.Contains("Name") &&
                v.ErrorMessage.Contains("Наименование должно быть в пределах 5 - 50 символов")));
        }

        [TestMethod]
        public void ProductNameLenghtTest3()
        {
            Product p = new Product() { Id = 1, Name = new string(Enumerable.Range(1, 51).Select(c => (char)c).ToArray()) };

            Assert.IsTrue(ValidateModel(p).Any(
                v => v.MemberNames.Contains("Name") &&
                v.ErrorMessage.Contains("Наименование должно быть в пределах 5 - 50 символов")));
        }

        [TestMethod]
        public void ProducPriceTest1()
        {
            Product p = new Product() { Id = 1, Name = "abcdef", Price = 0 };

            Assert.IsTrue(ValidateModel(p).Any(
                v => v.MemberNames.Contains("Price") &&
                v.ErrorMessage.Contains("The field Цена must be between 1 and 2147483647.")));
        }

        [TestMethod]
        public void ProducPriceTest2()
        {
            Product p = new Product() { Id = 1, Name = "abcdef", Price = 1 };

            Assert.IsFalse(ValidateModel(p).Any(
                v => v.MemberNames.Contains("Price") &&
                v.ErrorMessage.Contains("Поле Цена должно иметь значение между 1 и 2147483647")));
        }

        [TestMethod]
        public void ProducPriceTest3()
        {
            Product p = new Product() { Id = 1, Name = "abcdef", Price = 2 };

            Assert.IsFalse(ValidateModel(p).Any(
                v => v.MemberNames.Contains("Price") &&
                v.ErrorMessage.Contains("Поле Цена должно иметь значение между 1 и 2147483647")));
        }


        private IList<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            Validator.TryValidateObject(model, ctx, validationResults, true);
            return validationResults;
        }
    }
}
