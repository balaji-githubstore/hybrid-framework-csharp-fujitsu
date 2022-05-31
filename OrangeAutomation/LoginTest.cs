using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Fujitsu.OrangeAutomation
{
    public class LoginTest
    {
        [Test]
        public void ValidCredentialTest()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(),version:"99.0.4844.51");

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.FromSeconds(30);

            driver.Url = "https://opensource-demo.orangehrmlive.com/";

            driver.FindElement(By.Id("txtUsername")).SendKeys("Admin");
            driver.FindElement(By.Id("txtPassword")).SendKeys("admin123");
            driver.FindElement(By.Id("btnLogin")).Click();

            //wait for page load

            string actualUrl = driver.Url;
            Assert.That(actualUrl, Is.EqualTo("https://opensource-demo.orangehrmlive.com/index.php/dashboard"));
        }

        [Test]
        public void InvalidCredentialTest()
        {
            new DriverManager().SetUpDriver(new ChromeConfig(), version: "99.0.4844.51");

            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Url = "https://opensource-demo.orangehrmlive.com/";

            driver.FindElement(By.Id("txtUsername")).SendKeys("john");
            driver.FindElement(By.Id("txtPassword")).SendKeys("john12345");
            driver.FindElement(By.Id("btnLogin")).Click();

            string actualError = driver.FindElement(By.Id("spanMessage")).Text;
            Assert.That(actualError, Is.EqualTo("Invalid credentials"));
        }

        
    }
}
