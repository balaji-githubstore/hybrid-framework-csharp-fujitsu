using Fujitsu.OrangeAutomation.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeAutomation
{
    public class EmergencyContactTest : WebDriverWrapper
    {
        /// <summary>
        /// Verify Add Emergency Contact works fine. 
        /// Admin,admin123,sat,brother,34,43323,4354,expectedvalue
        /// Admin,admin123,prem,father,34,43323,4354,expectedvalue
        /// </summary>
        [Test]
        public void AddEmergencyContactTest()
        {
            driver.FindElement(By.Id("txtUsername")).SendKeys("Admin");
            driver.FindElement(By.Id("txtPassword")).SendKeys("admin123");
            driver.FindElement(By.Id("btnLogin")).Click();
            driver.FindElement(By.LinkText("My Info")).Click();
            driver.FindElement(By.LinkText("Emergency Contacts")).Click();
            driver.FindElement(By.Id("btnAddContact")).Click();
            driver.FindElement(By.CssSelector("#emgcontacts_name")).SendKeys("Sat");
            driver.FindElement(By.CssSelector("#emgcontacts_relationship")).SendKeys("Brother");
            driver.FindElement(By.CssSelector("#emgcontacts_homePhone")).SendKeys("7878");
            driver.FindElement(By.CssSelector("#emgcontacts_mobilePhone")).SendKeys("23333");
            driver.FindElement(By.CssSelector("#emgcontacts_workPhone")).SendKeys("22233233");
            driver.FindElement(By.Id("btnSaveEContact")).Click();
            //assert the added record in the current page or table 

            string tableData = driver.FindElement(By.Id("emgcontact_list")).Text;
            Console.WriteLine(tableData);

            Assert.Multiple(() =>
            {
                Assert.That(tableData.Contains("Sat"), "Assertion on Contact Name");
                Assert.True(tableData.Contains("7878"), "Assertion on home phone");
                Assert.True(driver.PageSource.Contains("Brother"), "Assertion on relationship");
            });
        }
    }
}
