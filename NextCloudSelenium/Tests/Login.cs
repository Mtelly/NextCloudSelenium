using DotNetEnv;
using NextCloudSelenium.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextCloudSelenium.Tests
{
    [TestFixture]
    public class Login
    {
        IWebDriver driver;
        LoginPage loginPage;
        string url = string.Empty, username = string.Empty, pswd = string.Empty;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            Env.TraversePath().Load();
            username = Env.GetString("USERNAME");
            pswd = Env.GetString("MY_PASSWORD");
            url = Env.GetString("ENVIRONMENT");
            driver.Navigate().GoToUrl(url);
            loginPage = new LoginPage(driver);
        }

        [Test]
        public void Test()
        {
            loginPage.LoginAs(username, pswd);
            Assert.That(driver.Title, Is.EqualTo("Dashboard - Nextcloud"));
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}