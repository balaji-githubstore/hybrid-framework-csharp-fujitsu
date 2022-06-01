using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Fujitsu.OrangeAutomation.Base
{
    public class WebDriverWrapper
    {
        protected IWebDriver driver;

        //protected IWebDriver Driver
        //{
        //    get { return driver; }
        //}

        [SetUp]
        public void Init()
        {
            string browser = "ff";

            switch(browser.ToLower())
            {
                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
                case "ff":
                    new DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;
                default:
                    new DriverManager().SetUpDriver(new ChromeConfig(), version: "99.0.4844.51");
                    driver = new ChromeDriver();
                    break;
            }

            
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);

            driver.Url = "https://opensource-demo.orangehrmlive.com/";
        }

        [TearDown]
        public void End()
        {
            driver.Quit();
        }
    }
}
