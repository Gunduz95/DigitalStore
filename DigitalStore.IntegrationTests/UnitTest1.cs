using Microsoft.VisualStudio.TestTools.UnitTesting;

using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Linq;

using DigitalStore.Repository;
using System.Data.Entity;
using DigitalStore.Models;

namespace DigitalStore.IntegrationTests
{
    [TestClass]
    public class IntegrationTest
    {
        private const string baseUrl = "http://localhost:5509";
        private const string connectionString = @"Data Source=localhost\SQLEXPRESS;Initial Catalog=DigitalStoreDB;Integrated Security=True;Pooling=False";

        [TestMethod]
        public void AddCategoryTest()
        {
            int prev, actual;

            using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
            {
                prev = db.Categories.Count();
            }

            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Categories/Create");

                var input = driver.FindElement(By.CssSelector("input#Name"));
                input.SendKeys("TestCategory");

                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
                {
                    actual = db.Categories.Count();
                }

                Assert.AreEqual(actual, prev + 1);
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [TestMethod]
        public void AddManufacturerTest()
        {
            int prev, actual;

            using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
            {
                prev = db.Manufacturers.Count();
            }

            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Manufacturers/Create");

                var input = driver.FindElement(By.CssSelector("input#Name"));
                input.SendKeys("TestManufacturer");

                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
                {
                    actual = db.Manufacturers.Count();
                }

                Assert.AreEqual(actual, prev + 1);
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [TestMethod]
        public void AddProducTest()
        {
            int prev, actual;

            using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
            {
                prev = db.Products.Count();
            }

            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Products/Create");

                var input = driver.FindElement(By.CssSelector("input#Name"));
                input.SendKeys("TestProduct");

                input = driver.FindElement(By.CssSelector("textarea#Description"));
                input.SendKeys("Description");

                input = driver.FindElement(By.CssSelector("input#Price"));
                input.SendKeys("10");

                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
                {
                    actual = db.Products.Count();
                }

                Assert.AreEqual(actual, prev + 1);
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [TestMethod]
        public void EditCategoryTest()
        {
            string newName = "EditedCategory", actual;

            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Categories");

                var link = driver.FindElements(By.TagName("a")).LastOrDefault(c => c.Text == "Edit");
                link.Click();

                var input = driver.FindElement(By.CssSelector("input#Name"));
                input.Clear();
                input.SendKeys(newName);

                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
                {
                    actual = db.Categories.ToArray().Last().Name;
                }

                Assert.AreEqual(actual, newName);
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [TestMethod]
        public void EditManufacturerTest()
        {
            string newName = "EditedManufacturer", actual;

            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Manufacturers");

                var link = driver.FindElements(By.TagName("a")).LastOrDefault(c => c.Text == "Edit");
                link.Click();

                var input = driver.FindElement(By.CssSelector("input#Name"));
                input.Clear();
                input.SendKeys(newName);

                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
                {
                    actual = db.Manufacturers.ToArray().Last().Name;
                }

                Assert.AreEqual(actual, newName);
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [TestMethod]
        public void EditProductNameTest()
        {
            string newName = "EditedProduct", actual;

            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Products");

                var link = driver.FindElements(By.TagName("a")).LastOrDefault(c => c.Text == "Edit");
                link.Click();

                var input = driver.FindElement(By.CssSelector("input#Name"));
                input.Clear();
                input.SendKeys(newName);

                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
                {
                    actual = db.Products.ToArray().Last().Name;
                }

                Assert.AreEqual(actual, newName);
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [TestMethod]
        public void EditProductPriceTest()
        {
            decimal newPrice = 123, actual;

            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Products");

                var link = driver.FindElements(By.TagName("a")).LastOrDefault(c => c.Text == "Edit");
                link.Click();

                var input = driver.FindElement(By.CssSelector("input#Price"));
                input.Clear();
                input.SendKeys(newPrice.ToString());

                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
                {
                    actual = db.Products.ToArray().Last().Price;
                }

                Assert.AreEqual(actual, newPrice);
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [TestMethod]
        public void DeleteCategoryTest()
        {
            int prev, actual;

            using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
            {
                prev = db.Categories.Count();
            }

            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Categories");

                var link = driver.FindElements(By.TagName("a")).Last();
                link.Click();

                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
                {
                    actual = db.Categories.Count();
                }

                Assert.AreEqual(actual, prev - 1);
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [TestMethod]
        public void DeleteManufacturerTest()
        {
            int prev, actual;

            using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
            {
                prev = db.Manufacturers.Count();
            }

            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Manufacturers");

                var link = driver.FindElements(By.TagName("a")).Last();
                link.Click();

                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
                {
                    actual = db.Manufacturers.Count();
                }

                Assert.AreEqual(actual, prev - 1);
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [TestMethod]
        public void DeleteProductTest()
        {
            int prev, actual;

            using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
            {
                prev = db.Products.Count();
            }

            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Products");

                var link = driver.FindElements(By.TagName("a")).Last();
                link.Click();

                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                using (DigitalStoreContext db = new DigitalStoreContext(connectionString))
                {
                    actual = db.Products.Count();
                }

                Assert.AreEqual(actual, prev - 1);
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }
    }
}
