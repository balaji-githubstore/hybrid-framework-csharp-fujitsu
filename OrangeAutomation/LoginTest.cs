using AventStack.ExtentReports;
using Fujitsu.OrangeAutomation.Base;
using Fujitsu.OrangeAutomation.Utilities;
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
            driver.FindElement(By.Id("txtUsername")).SendKeys(username);
            driver.FindElement(By.Id("txtPassword")).SendKeys(password);
            driver.FindElement(By.Id("btnLogin")).Click();

            //wait for page load

            string actualUrl = driver.Url;
            Assert.That(actualUrl, Is.EqualTo(expectedUrl));
        }

        [Test, TestCaseSource(typeof(DataUtils), nameof(DataUtils.InvalidCredentialData))]
         public void InvalidCredentialTest(string username, string password, string expectedError)
        {
            driver.FindElement(By.Id("txtUsername")).SendKeys(username);
            test.Log(Status.Info, "Entered Username as " + username);

            driver.FindElement(By.Id("txtPassword")).SendKeys(password);
            test.Log(Status.Info, "Entered Password as " + password);

            driver.FindElement(By.Id("btnLogin")).Click();
            test.Log(Status.Info, "Clicked On Login");

            string actualError = driver.FindElement(By.Id("spanMessage")).Text;
            test.Log(Status.Info, "Error Message Shown " + actualError);

            Assert.That(actualError, Is.EqualTo(expectedError));
        }
    }
}
