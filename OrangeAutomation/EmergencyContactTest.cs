using Fujitsu.OrangeAutomation.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeAutomation
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
            //click on My Info
            //click on Emergency contact
            //click on add (Add Emergency Contact)
            //enter name
            //enter relationship
            //enter home telephoone
            //enter mobile 
            //enter work telephone
            //click save
            //assert the added record in the current page or table 
        }
    }
}
