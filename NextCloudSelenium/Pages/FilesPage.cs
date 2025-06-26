using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextCloudSelenium.Pages
{
    public class FilesPage
    {
        private readonly IWebDriver _driver;
        private WebDriverWait wait;

        public FilesPage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }

        private IWebElement NewButton => _driver.FindElement(By.ClassName("breadcrumb__actions"));
        private IWebElement NewFolderButton => _driver.FindElement(By.CssSelector("[data-cy-upload-picker-menu-entry='newFolder']"));
        private IWebElement FolderNameTextBox => _driver.FindElement(By.XPath("/html/body/div[7]/div[2]/div/div/div/div[1]/div/form/div/div/input"));//TODO Create more efficient selector. ID is dynamic.  
        private IWebElement CreateNewFolderButton => _driver.FindElement(By.CssSelector("[data-cy-files-new-node-dialog-submit]"));

        public void CreateNewFolder(string folderName = "Selenium Test")
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //Drop-down menu
            NewButton.Click();
            NewFolderButton.Click();

            //Popup modal
            FolderNameTextBox.Click();
            FolderNameTextBox.Clear();
            FolderNameTextBox.SendKeys(folderName);
            CreateNewFolderButton.Click();
        }

        public void SelectFolder(string folderName = "Selenium Test")
        {
            IWebElement seleniumTest = _driver.FindElement(By.CssSelector($"[title=\"Open folder {folderName}\"]"));
            seleniumTest.Click();
        }
    }
}