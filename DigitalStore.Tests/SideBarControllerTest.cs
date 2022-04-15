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
    public class SideBarControllerTest
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
    }
}
