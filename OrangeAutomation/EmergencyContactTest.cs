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
        [TestCase("Admin","admin123","Sat","Brother","788","878788","88799889", "Sat;Brother;788")]
        public void AddEmergencyContactTest(string username,string password,string contactName,string relationship,string homePhone,string mobilePhone,string homeTelephone,string expectedRecord)
        {
            driver.FindElement(By.Id("txtUsername")).SendKeys(username);
            driver.FindElement(By.Id("txtPassword")).SendKeys(password);
            driver.FindElement(By.Id("btnLogin")).Click();
            driver.FindElement(By.LinkText("My Info")).Click();
            driver.FindElement(By.LinkText("Emergency Contacts")).Click();
            driver.FindElement(By.Id("btnAddContact")).Click();
            driver.FindElement(By.CssSelector("#emgcontacts_name")).SendKeys(contactName);
            driver.FindElement(By.CssSelector("#emgcontacts_relationship")).SendKeys(relationship);
            driver.FindElement(By.CssSelector("#emgcontacts_homePhone")).SendKeys(homePhone);
            driver.FindElement(By.CssSelector("#emgcontacts_mobilePhone")).SendKeys(homeTelephone);
            driver.FindElement(By.CssSelector("#emgcontacts_workPhone")).SendKeys(mobilePhone);
            driver.FindElement(By.Id("btnSaveEContact")).Click();
            //assert the added record in the current page or table 

            string tableData = driver.FindElement(By.Id("emgcontact_list")).Text;
            Console.WriteLine(tableData);

            Assert.Multiple(() =>
            {
                Assert.That(tableData.Contains(contactName), "Assertion on Contact Name");
                Assert.True(tableData.Contains(mobilePhone), "Assertion on home phone");
                Assert.True(driver.PageSource.Contains(relationship), "Assertion on relationship");
            });

            string[] records = expectedRecord.Split(";");

            Assert.Multiple(() =>
            {
                Assert.That(tableData.Contains(records[0]), "Assertion on Contact Name");
                Assert.True(tableData.Contains(records[1]), "Assertion on home phone");
                Assert.True(driver.PageSource.Contains(records[2]), "Assertion on relationship");
            });
        }
    }
}
