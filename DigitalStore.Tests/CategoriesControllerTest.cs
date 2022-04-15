using System.Web.Mvc;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using DigitalStore.Repository;
using DigitalStore.Models;
using DigitalStore.Controllers;

namespace DigitalStore.Tests
{
    [TestClass]
    public class CategoriesControllerTest
    {
        [TestMethod]
        public void IndexNotNullTest()
        {
            var mock = new Mock<IRepository<Category>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Category>());
            CategoriesController controller = new CategoriesController(mock.Object);

            ViewResult result = controller.Index() as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void DetailsNotNullTest()
        {
            var mock = new Mock<IRepository<Category>>();
            mock.Setup(m => m.GetById(1)).Returns(new Category() { Id = 1 });
            CategoriesController controller = new CategoriesController(mock.Object);

            ViewResult result = controller.Details(1) as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void CreateViewNameTest()
        {
            var mock = new Mock<IRepository<Category>>();
            CategoriesController controller = new CategoriesController(mock.Object);

            ViewResult result = controller.Create() as ViewResult;

            Assert.IsNotNull(result);
            Assert.AreEqual("Create", result.ViewName);
        }

        [TestMethod]
        public void EditNotNullTest()
        {
            var mock = new Mock<IRepository<Category>>();
            mock.Setup(m => m.GetById(1)).Returns(new Category() { Id = 1 });
            CategoriesController controller = new CategoriesController(mock.Object);

            ViewResult result = controller.Edit(1) as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void DeleteNotNullTest()
        {
            var mock = new Mock<IRepository<Category>>();
            mock.Setup(m => m.GetById(1)).Returns(new Category() { Id = 1 });
            CategoriesController controller = new CategoriesController(mock.Object);

            ViewResult result = controller.Delete(1) as ViewResult;

            Assert.IsNotNull(result.Model);
        }

        [TestMethod]
        public void CreatePostAction_RedirectToIndexView()
        {
            var mock = new Mock<IRepository<Category>>();
            Category c = new Category();
            CategoriesController controller = new CategoriesController(mock.Object);

            RedirectToRouteResult result = controller.Edit(c) as RedirectToRouteResult;
            string expected = "Index";

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        [TestMethod]
        public void EditPostAction_RedirectToIndexView()
        {
            var mock = new Mock<IRepository<Category>>();
            Category c = new Category();
            CategoriesController controller = new CategoriesController(mock.Object);

            RedirectToRouteResult result = controller.Edit(c) as RedirectToRouteResult;
            string expected = "Index";

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }

        [TestMethod]
        public void DeletePostAction_RedirectToIndexView()
        {
            var mock = new Mock<IRepository<Category>>();
            mock.Setup(m => m.GetById(1)).Returns(new Category() { Id = 1 });
            CategoriesController controller = new CategoriesController(mock.Object);

            RedirectToRouteResult result = controller.DeleteConfirmed(1) as RedirectToRouteResult;
            string expected = "Index";

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.RouteValues["action"]);
        }
    }
}
