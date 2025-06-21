using DotNetEnv;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

DotNetEnv.Env.TraversePath().Load();
string pswd = Env.GetString("MY_PASSWORD");

IWebDriver driver;
driver = new ChromeDriver();
driver.Url = "http://localhost:81/login?clear=1";

IWebElement usernameInputField = driver.FindElement(By.ClassName("input-field"));
usernameInputField.Click();
IWebElement username = driver.FindElement(By.Id("user"));
username.SendKeys("daguilar");

IWebElement passwordInputField = driver.FindElement(By.CssSelector(".input-field.input-field--trailing-icon"));
passwordInputField.Click();
IWebElement password = driver.FindElement(By.Id("password"));
password.SendKeys(pswd);

IWebElement loginButton = driver.FindElement(By.CssSelector(".button-vue.button-vue--size-normal.button-vue--icon-and-text.button-vue--vue-primary.button-vue--wide"));
loginButton.Click();