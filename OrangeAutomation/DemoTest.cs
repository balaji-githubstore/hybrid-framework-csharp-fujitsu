using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeAutomation
{
    //demo class - will be deleted
    internal class DemoTest
    {

        public static object[] InvalidData()
        {
            //temp array size - number of arguments
            object[] temp1 = new object[2];
            temp1[0] = "John";
            temp1[1] = "john123";

            object[] temp2 = new object[2];
            temp2[0] = "peter";
            temp2[1] = "peter123";

            object[] temp3 = new object[2];
            temp3[0] = "mark";
            temp3[1] = "mark123";

            string[] temp4=new string[2];
            temp4[0] = "paul";
            temp4[1] = "paul123";

            //main array size - number of test cases
            object[] main = new object[4]; //number of test case 
            main[0] = temp1;
            main[1] = temp2;
            main[2] = temp3;
            main[3] = temp4;

            return main;
        }

        [Test,TestCaseSource(nameof(InvalidData))]
        public void InvalidTest(string username, string password)
        {
            Console.WriteLine("Invalid" + username + password);
        }
    }
}
