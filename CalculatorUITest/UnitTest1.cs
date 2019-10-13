using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace CalculatorUITest
{
    [TestClass]
    public class UnitTest1
    {
        private static readonly string DriverDirectory = "C:\\seleniumDrivers2";
        private static IWebDriver _driver;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
             _driver = new ChromeDriver(DriverDirectory); // fast
            // _driver = new FirefoxDriver(DriverDirectory);  // slow
            // _driver = new EdgeDriver(DriverDirectory); // times out ... not working
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            _driver.Navigate().GoToUrl("http://localhost:3000/");
            Assert.AreEqual("Calculator", _driver.Title);

            IWebElement inputElement1 = _driver.FindElement(By.Id("number1"));
            inputElement1.SendKeys("12");

            IWebElement inputElement2 = _driver.FindElement(By.Id("number2"));
            inputElement2.SendKeys("4");

            IWebElement selectElement = _driver.FindElement(By.Id("operation"));
            SelectElement operations = new SelectElement(selectElement);
            operations.SelectByText("*");

            IWebElement buttonElement = _driver.FindElement(By.Id("calculateButton"));
            buttonElement.Click();

            IWebElement outputElement = _driver.FindElement(By.Id("result"));
            string text = outputElement.Text;

            Assert.AreEqual("48", text);
        }
    }
}
