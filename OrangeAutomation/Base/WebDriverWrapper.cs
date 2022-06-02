using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
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
        private static ExtentReports extent;
        protected static ExtentTest test;

        //protected IWebDriver Driver
        //{
        //    get { return driver; }
        //}

        [OneTimeSetUp]
        public void Start()
        {
            if(extent ==null)
            {
                string path = Directory.GetCurrentDirectory();
                path = path.Remove(path.IndexOf("bin"))+@"Report\index.html";

                ExtentHtmlReporter reporter = new ExtentHtmlReporter(path);
                extent = new ExtentReports();
                extent.AttachReporter(reporter);
            }
        }

        [OneTimeTearDown]
        public void End()
        {
            extent.Flush();
        }

        [SetUp]
        public void Init()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            
            string browser = "chrome";

            switch(browser.ToLower())
            {
                case "edge":
                    new DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;
                case "ff":
                case "firefox":
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
        public void EndTest()
        {

            string testName = TestContext.CurrentContext.Test.Name;

            TestStatus status = TestContext.CurrentContext.Result.Outcome.Status;

            if (status == TestStatus.Failed)
            {
                var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
                var errorMessage = TestContext.CurrentContext.Result.Message;
                
                test.Log(Status.Fail, stackTrace + errorMessage);
                
            }
            else if (status == TestStatus.Passed)
            {
                test.Log(Status.Pass, "Passed - Snapshot below:");
            }
            else if (status == TestStatus.Skipped)
            {
                test.Log(Status.Skip, "Skipped - " + testName);
            }
            driver.Quit();
        }
    }
}
