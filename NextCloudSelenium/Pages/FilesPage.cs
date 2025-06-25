using OpenQA.Selenium;
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

        public FilesPage(IWebDriver driver)
        {
            _driver = driver;
        }
                
        private IWebElement NewButton => _driver.FindElement(By.ClassName("breadcrumb__actions"));
        private IWebElement NewFolderButton => _driver.FindElement(By.CssSelector("[data-cy-upload-picker-menu-entry='newFolder']"));
        private IWebElement FolderNameTextBox => _driver.FindElement(By.Id("inputassmv"));
        private IWebElement CreateNewFolderButton => _driver.FindElement(By.CssSelector("[data-cy-files-new-node-dialog-submit]"));

        public void CreateNewFolder(string folderName = "Selenium Test")
        {
            //Drop-down menu
            NewButton.Click();
            NewFolderButton.Click();

            //Popup modal
            FolderNameTextBox.Click();
            FolderNameTextBox.Clear();
            FolderNameTextBox.SendKeys(folderName);
            CreateNewFolderButton.Click();
        }
    }
}