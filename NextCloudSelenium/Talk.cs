using DotNetEnv;
using NextCloudSelenium.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextCloudSelenium
{
    [TestFixture]
    public class Talk
    {
        IWebDriver driver;
        NavigationBar navigationPage;
        LoginPage loginPage;
        string url = String.Empty, username = String.Empty, pswd = String.Empty;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            DotNetEnv.Env.TraversePath().Load();
            url = Env.GetString("ENVIRONMENT");
            username = Env.GetString("USERNAME");
            pswd = Env.GetString("MY_PASSWORD");
            driver.Navigate().GoToUrl(url);
            navigationPage = new NavigationBar(driver);
            loginPage = new LoginPage(driver);
        }

        [Test]
        public void Test()
        {
            loginPage.LoginAs(username, pswd);
            navigationPage.ClickTalk();
            Assert.That(driver.Title, Is.EqualTo("Talk - Nextcloud"));
        }

        [Test]
        public void FilesTest()
        {
            loginPage.LoginAs(username, pswd);
            navigationPage.ClickFiles();
            Assert.That(driver.Title, Is.EqualTo("All files - Nextcloud"));
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}