using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeHRMBDD.Pages
{
    public class MyInfoPage
    {
        private IWebDriver _driver;
        public MyInfoPage(IWebDriver driver)
        {
            this._driver = driver;
        }

    }
}
