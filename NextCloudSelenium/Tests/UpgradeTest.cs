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

namespace NextCloudSelenium.Tests
{
    [TestFixture]
    public class UpgradeTest
    {
        IWebDriver driver;
        NavigationBar navigationPage;
        FilesPage filesPage;
        LoginPage loginPage;
        DateTime now;
        string url = string.Empty, username = string.Empty, pswd = string.Empty;

        [SetUp]
        public void StartBrowser()
        {
            //TODO Run headless mode via runsettings. Potentially extract into Factory pattern.
            driver = new ChromeDriver();
            filesPage = new FilesPage(driver);
            navigationPage = new NavigationBar(driver);
            Env.TraversePath().Load();
            url = Env.GetString("ENVIRONMENT");
            username = Env.GetString("USERNAME");
            pswd = Env.GetString("MY_PASSWORD");
            driver.Navigate().GoToUrl(url);
            loginPage = new LoginPage(driver);
            loginPage.LoginAs(username, pswd);
        }

        [Test]
        public void FolderTest()
        {
            navigationPage.ClickFiles();
            filesPage.CreateNewFolder();
            IWebElement cyFiles = driver.FindElement(By.CssSelector("[data-cy-files-list-row-name=\"Documents\"]"));
            Assert.That(driver.Title, Is.EqualTo("All files - Nextcloud"));
            filesPage.SelectFolder();
        }
    }
}
