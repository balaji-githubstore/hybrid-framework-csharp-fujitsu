using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Fujitsu.OrangeAutomation.Utilities;
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
        protected IWebDriver? driver;
        private static ExtentReports? extent;
        protected static ExtentTest? test;
        public static String? projectPath;

        //protected IWebDriver Driver
        //{
        //    get { return driver; }
        //}

        [OneTimeSetUp]
        public void Start()
        {
            if(extent ==null)
            {
                projectPath = Directory.GetCurrentDirectory();
                projectPath = projectPath.Remove(projectPath.IndexOf("bin"));

                ExtentHtmlReporter reporter = new ExtentHtmlReporter(projectPath + @"Report\index.html");
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

            string browser = JsonUtils.GetValue(projectPath + @"TestData\data.json", "browser");

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

            driver.Url = JsonUtils.GetValue(projectPath + @"TestData\data.json", "url");
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
