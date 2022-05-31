using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            new DriverManager().SetUpDriver(new ChromeConfig(), version: "99.0.4844.51");

            driver = new ChromeDriver();
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
