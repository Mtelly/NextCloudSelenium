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
    public class NavigationBarTest
    {
        IWebDriver driver;
        NavigationBar navigationPage;
        LoginPage loginPage;
        DateTime now;
        string url = string.Empty, username = string.Empty, pswd = string.Empty;

        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            Env.TraversePath().Load();
            url = Env.GetString("ENVIRONMENT");
            username = Env.GetString("USERNAME");
            pswd = Env.GetString("MY_PASSWORD");
            driver.Navigate().GoToUrl(url);
            navigationPage = new NavigationBar(driver);
            loginPage = new LoginPage(driver);
            loginPage.LoginAs(username, pswd);
        }

        [Test]
        public void TalkTest()
        {            
            navigationPage.ClickTalk();
            Assert.That(driver.Title, Is.EqualTo("Talk - Nextcloud"));
        }

        [Test]
        public void FilesTest()
        {
            navigationPage.ClickFiles();
            Assert.That(driver.Title, Is.EqualTo("All files - Nextcloud"));
        }

        [Test]
        public void PhotosTest()
        {
            navigationPage.ClickPhotos();
            Assert.That(driver.Title, Is.EqualTo("All your media - Photos - Nextcloud"));
        }

        [Test]
        public void ActivityTest()
        {
            navigationPage.ClickActivity();
            Assert.That(driver.Title, Is.EqualTo("Activity - Nextcloud"));
        }

        [Test]
        public void MailTest()
        {
            navigationPage.ClickMail();
            Assert.That(driver.Title, Is.EqualTo("Mail - Nextcloud"));
        }

        [Test]
        public void ContactsTest()
        {
            navigationPage.ClickContacts();
            Assert.That(driver.Title, Is.EqualTo("Contacts - Nextcloud"));
        }

        [Test]
        public void CalendarTest()
        {
            now = DateTime.Now;
            string fullMonth = now.ToString("MMMM");
            int year = now.Year;

            navigationPage.ClickCalendar();
            Assert.That(driver.Title, Is.EqualTo($"{fullMonth} {year} - Calendar - Nextcloud"));
        }

        [Test]
        public void NotesTest()
        {
            navigationPage.ClickNotes();
            Assert.That(driver.Title, Is.EqualTo("Notes - Nextcloud"));
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}