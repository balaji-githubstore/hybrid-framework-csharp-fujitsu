using Fujitsu.Base;
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
    public class LoginUITest : WebDriverWrapper
    {
        [Test]
        public void ValidateTitleTest()
        {
            
            Assert.That(driver.Title, Is.EqualTo("OrangeHRM"));
        }
    }
}
