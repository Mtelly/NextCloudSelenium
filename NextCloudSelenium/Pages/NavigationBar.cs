using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextCloudSelenium.Pages
{
    public class NavigationBar
    {
        private readonly IWebDriver _driver;
        public NavigationBar(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement nextcloud => _driver.FindElement(By.Id("nextcloud"));
        private IWebElement talk => _driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/nav/ul/li[2]/a/span[2]"));
        private IWebElement files => _driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/nav/ul/li[3]/a/span[2]"));
        private IWebElement photos => _driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/nav/ul/li[4]/a/span[2]"));
        private IWebElement activity => _driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/nav/ul/li[5]/a/span[2]"));
        private IWebElement mail => _driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/nav/ul/li[6]/a/span[2]"));
        private IWebElement contacts => _driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/nav/ul/li[7]/a/span[2]"));
        private IWebElement calendar => _driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/nav/ul/li[8]/a/span[2]"));
        private IWebElement notes => _driver.FindElement(By.XPath("//*[@id=\"header\"]/div[1]/nav/ul/li[9]/a/span[2]"));

        public void ClickNextcloud()
        {
            nextcloud.Click();
        }
        
        public void ClickTalk()
        {
            talk.Click();
        }

        public void ClickFiles()
        {
            files.Click();
        }

        public void ClickPhotos()
        {
            photos.Click();
        }

        public void ClickActivity()
        {
            activity.Click();
        }

        public void ClickMail()
        {
            mail.Click();
        }

        public void ClickContacts()
        {
            contacts.Click();
        }

        public void ClickCalendar()
        {
            calendar.Click();
        }

        public void ClickNotes()
        {
            notes.Click();
        }
    }
}