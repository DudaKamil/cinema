using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Cinema.Tests.AccountController
{
    [TestClass]
    public class LoginTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://localhost:49610/Account/Logout");
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Navigate().GoToUrl("http://localhost:49610/Account/Logout");
            driver?.Quit();
        }

        [TestMethod]
        public void AdminLoginSuccessfulTest()
        {
            string expected = "Panel Admina - Cinema";
            string actual = null;

            driver.Navigate().GoToUrl("http://localhost:49610/Account/Login");
            IWebElement loginTextBox = driver.FindElement(By.Id("Login"));
            IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));

            loginTextBox.SendKeys("admin");
            passwordTextBox.SendKeys("admin");
            driver.FindElement(By.ClassName("login-button")).Click();
            driver.Navigate().GoToUrl("http://localhost:49610/Admin/AdminPanel");

            actual = driver.Title;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AdminLoginFailTest()
        {
            string expected = "Panel Admina - Cinema";
            string actual = null;

            driver.Navigate().GoToUrl("http://localhost:49610/Account/Login");
            IWebElement loginTextBox = driver.FindElement(By.Id("Login"));
            IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));

            loginTextBox.SendKeys("admin");
            passwordTextBox.SendKeys("wrongpassword");
            driver.FindElement(By.ClassName("login-button")).Click();
            driver.Navigate().GoToUrl("http://localhost:49610/Admin/AdminPanel");

            actual = driver.Title;

            Assert.AreNotEqual(expected, actual);
        }

        [TestMethod]
        public void UserLoginSuccessfulTest()
        {
            string expected = "Przegląd Zamówień - Cinema";
            string actual = null;

            driver.Navigate().GoToUrl("http://localhost:49610/Account/Login");
            IWebElement loginTextBox = driver.FindElement(By.Id("Login"));
            IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));

            loginTextBox.SendKeys("user");
            passwordTextBox.SendKeys("user");
            driver.FindElement(By.ClassName("login-button")).Click();
            driver.Navigate().GoToUrl("http://localhost:49610/Application/OrderSummary");

            actual = driver.Title;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UserLoginFailTest()
        {
            string expected = "Przegląd Zamówień - Cinema";
            string actual = null;

            driver.Navigate().GoToUrl("http://localhost:49610/Account/Login");
            IWebElement loginTextBox = driver.FindElement(By.Id("Login"));
            IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));

            loginTextBox.SendKeys("user");
            passwordTextBox.SendKeys("wrongpassword");
            driver.FindElement(By.ClassName("login-button")).Click();
            driver.Navigate().GoToUrl("http://localhost:49610/Application/OrderSummary");

            actual = driver.Title;

            Assert.AreNotEqual(expected, actual);
        }
    }
}
