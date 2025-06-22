using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextCloudSelenium.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement UsernameInputField => _driver.FindElement(By.ClassName("input-field"));
        private IWebElement Username => _driver.FindElement(By.Id("user"));
        private IWebElement PasswordInputField => _driver.FindElement(By.CssSelector(".input-field.input-field--trailing-icon"));
        private IWebElement Password => _driver.FindElement(By.Id("password"));
        private IWebElement LoginButton => _driver.FindElement(By.CssSelector(".button-vue.button-vue--size-normal.button-vue--icon-and-text.button-vue--vue-primary.button-vue--wide"));
        
        public void EnterUsername(string username)
        {
            UsernameInputField.Click();
            Username.Clear();
            Username.SendKeys(username);
        }
        public void EnterPassword(string password)
        {
            PasswordInputField.Click();
            Password.SendKeys(password);
        }

        public void ClickLogin()
        {
            LoginButton.Click();            
        }

        public void LoginAs(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();
        }
    }
}