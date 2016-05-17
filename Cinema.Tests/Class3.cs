using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace Cinema.Tests
{
    [TestClass]
    public class RegisterUnitTests
    {
        IWebDriver driver = new FirefoxDriver();
        static Random rand = new Random();
        private int number;


        [TestInitialize]
        public void SetUp()
        {
            number = rand.Next(1000000000);

            driver.Navigate().GoToUrl("http://localhost:49610/Account/Logout");
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Navigate().GoToUrl("http://localhost:49610/Account/Logout");
        }

        [TestMethod]
        public void UserCreatedSuccessfullyTest()
        {
            string expected = "Menu Główne - Cinema";
            string actual = null;

            driver.Navigate().GoToUrl("http://localhost:49610/Account/Register");
            IWebElement loginTextBox = driver.FindElement(By.Id("Login"));
            IWebElement passwordTextBox = driver.FindElement(By.Id("Password"));
            IWebElement confirmPasswordTextBox = driver.FindElement(By.Id("ConfirmPassword"));
            IWebElement emailTextBox = driver.FindElement(By.Id("Email"));
            IWebElement nameTextBox = driver.FindElement(By.Id("Name"));


            loginTextBox.SendKeys(number + "newusertest");
            passwordTextBox.SendKeys(number + "newusertest");
            confirmPasswordTextBox.SendKeys(number + "newusertest");
            emailTextBox.SendKeys(number + "newusertest@newusertest.pl");
            nameTextBox.SendKeys(number + "newusertest");

            driver.FindElement(By.ClassName("login-button")).Click();

            loginTextBox = driver.FindElement(By.Id("Login"));
            passwordTextBox = driver.FindElement(By.Id("Password"));

            loginTextBox.SendKeys(number + "newusertest");
            passwordTextBox.SendKeys(number + "newusertest");
            driver.FindElement(By.ClassName("login-button")).Click();
            driver.Navigate().GoToUrl("http://localhost:49610/Application/MainMenu");

            actual = driver.Title;

            Assert.AreEqual(expected, actual);
        }

    }
}