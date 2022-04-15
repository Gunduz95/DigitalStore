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
    public class HomeControllerTest
    {
        [TestMethod]
        public void IndexNotNullTest()
        {
            var mock = new Mock<IRepository<Product>>();
            mock.Setup(m => m.GetAll()).Returns(new List<Product>() { new Product() });
            HomeController controller = new HomeController(mock.Object);

            ViewResult result = controller.Index(null) as ViewResult;

            Assert.IsNotNull(result.Model);
        }
    }
}
