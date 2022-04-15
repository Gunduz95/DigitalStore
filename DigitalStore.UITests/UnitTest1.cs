using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Linq;

namespace DigitalStore.UITests
{
    [TestFixture]
    public class UITest
    {
        private const string baseUrl = "http://localhost:5509";

        [Test]
        public void AddCategoryErrorMessageTest()
        {
            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Categories/Create");
                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                var error = driver.FindElement(By.ClassName("field-validation-error"));
                var message = error.Text;

                Assert.AreEqual(message, "The Наименование field is required.");
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [Test]
        public void AddManufacturerErrorMessageTest()
        {
            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Manufacturers/Create");
                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                var error = driver.FindElement(By.ClassName("field-validation-error"));
                var message = error.Text;

                Assert.AreEqual(message, "The Наименование field is required.");
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [Test]
        public void AddProductErrorMessageTest1()
        {
            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Products/Create");
                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                var errorName = driver.FindElements(By.ClassName("field-validation-error"))
                    .FirstOrDefault(c => c.GetAttribute("data-valmsg-for") == "Name");
                var message1 = errorName?.Text;

                var errorPrice = driver.FindElements(By.ClassName("field-validation-error"))
                    .FirstOrDefault(c => c.GetAttribute("data-valmsg-for") == "Price");
                var message2 = errorPrice?.Text;

                Assert.AreEqual(message1, "The Наименование field is required."); 
                Assert.AreEqual(message2, "The Цена field is required.");
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [Test]
        public void AddProductErrorMessageTest2()
        {
            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Products/Create");

                var input = driver.FindElement(By.CssSelector("input#Name"));
                input.SendKeys("pr1");

                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                var errorName = driver.FindElements(By.ClassName("field-validation-error"))
                    .FirstOrDefault(c => c.GetAttribute("data-valmsg-for") == "Name");
                var message = errorName?.Text;

                Assert.AreEqual(message, "Наименование должно быть в пределах 5 - 50 символов");
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [Test]
        public void AddProductErrorMessageTest3()
        {
            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Products/Create");

                var input = driver.FindElement(By.CssSelector("input#Price"));
                input.SendKeys("-5");

                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                var errorName = driver.FindElements(By.ClassName("field-validation-error"))
                    .FirstOrDefault(c => c.GetAttribute("data-valmsg-for") == "Price");
                var message = errorName?.Text;

                Assert.AreEqual(message, "The field Цена must be between 1 and 2147483647.");
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [Test]
        public void AddProductErrorMessageTest4()
        {
            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Products/Create");

                var input = driver.FindElement(By.CssSelector("input#Name"));
                input.SendKeys(new string(Enumerable.Range('A', 'A' + 51).Select(c => (char)c).ToArray()));

                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                var errorName = driver.FindElements(By.ClassName("field-validation-error"))
                    .FirstOrDefault(c => c.GetAttribute("data-valmsg-for") == "Name");
                var message = errorName?.Text;

                Assert.AreEqual(message, "Наименование должно быть в пределах 5 - 50 символов");
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [Test]
        public void AddCategoryTest()
        {
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

                Assert.AreEqual(driver.Url, baseUrl + "/Categories");
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [Test]
        public void AddManufacturerTest()
        {
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

                Assert.AreEqual(driver.Url, baseUrl + "/Manufacturers");
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [Test]
        public void AddProducTest()
        {
            var options = new InternetExplorerOptions();
            options.AddAdditionalCapability("IgnoreProtectedModeSettings", true);
            var driver = new InternetExplorerDriver(options);
            try
            {
                driver.Navigate().GoToUrl(baseUrl + "/Products/Create");

                var input = driver.FindElement(By.CssSelector("input#Name"));
                input.SendKeys("Test product");

                input = driver.FindElement(By.CssSelector("textarea#Description"));
                input.SendKeys("Description");

                input = driver.FindElement(By.CssSelector("input#Price"));
                input.SendKeys("10");

                var button = driver.FindElement(By.CssSelector("input.btn.btn-default"));
                button.Click();

                Assert.AreEqual(driver.Url, baseUrl + "/Products");
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }

        [Test]
        public void DeleteCategoryTest()
        {
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

                Assert.AreEqual(driver.Url, baseUrl + "/Categories");
            }
            finally
            {
                driver.Close();
                driver.Quit();
            }
        }
    }
}
