using Fujitsu.OrangeAutomation.Base;
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
        [TestCase("Admin","admin123", "https://opensource-demo.orangehrmlive.com/index.php/dashboard")]
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

        public static object[] InvalidCredentialData()
        {
            //("John","John123","Invalid credentials")
            //("Peter", "Peter123", "Invalid credentials")

            object[] data1 = new object[3];
            data1[0] = "John";
            data1[1] = "John123";
            data1[2] = "Invalid credentials";

            object[] data2 = new object[3];
            data2[0] = "Peter";
            data2[1] = "Pete123";
            data2[2] = "Invalid credentials";

            object[] main = new object[2];
            main[0] = data1;
            main[1] = data2;

            return main;
        }

        [Test,TestCaseSource(nameof(InvalidCredentialData))]
        //[TestCase("John","John123","Invalid credentials")]
        //[TestCase("Peter", "Peter123", "Invalid credentials")]
        public void InvalidCredentialTest(string username,string password,string expectedError)
        {
            driver.FindElement(By.Id("txtUsername")).SendKeys(username);
            driver.FindElement(By.Id("txtPassword")).SendKeys(password);
            driver.FindElement(By.Id("btnLogin")).Click();

            string actualError = driver.FindElement(By.Id("spanMessage")).Text;
            Assert.That(actualError, Is.EqualTo(expectedError));
        }

 
        
    }
}
