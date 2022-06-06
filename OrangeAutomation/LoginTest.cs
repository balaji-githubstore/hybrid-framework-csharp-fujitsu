using AventStack.ExtentReports;
using Fujitsu.Base;
using Fujitsu.OrangeAutomation.Utilities;
using Fujitsu.OrangeHRMBDD.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Fujitsu.OrangeAutomation
{
    public class LoginTest : WebDriverWrapper
    {
        [Test]
        [TestCase("Admin", "admin123", "https://opensource-demo.orangehrmlive.com/index.php/dashboard")]
        [TestCase("Admin", "admin123", "https://opensource-demo.orangehrmlive.com/index.php/dashboard")]
        public void ValidCredentialTest(string username, string password, string expectedUrl)
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername(username);
            login.EnterPassword(password);
            login.ClickOnLogin();

            //wait for page load
            MainPage main = new MainPage(driver);
            string actualUrl = main.GetMainPageUrl();

            Assert.That(actualUrl, Is.EqualTo(expectedUrl));
        }

        [Test, TestCaseSource(typeof(DataUtils), nameof(DataUtils.InvalidCredentialData))]
         public void InvalidCredentialTest(string username, string password, string expectedError)
        {
            LoginPage login = new LoginPage(driver);
            login.EnterUsername(username);
            test.Log(Status.Info, "Entered Username as " + username);

            login.EnterPassword(password);
            test.Log(Status.Info, "Entered Password as " + password);

            login.ClickOnLogin();
            test.Log(Status.Info, "Clicked On Login");

            string actualError = login.GetErrorMessage();
            test.Log(Status.Info, "Error Message Shown " + actualError);

            Assert.That(actualError, Is.EqualTo(expectedError));
        }
    }
}
