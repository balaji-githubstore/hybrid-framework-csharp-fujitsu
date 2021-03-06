using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using ClosedXML.Excel;
using Newtonsoft.Json;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrangeAutomation.SAMPLE
{
    //demo class - will be deleted //not a part of framework
    internal class DemoTest
    {
        [Test]
        public void ReadJson()
        {
            StreamReader reader = new StreamReader(@"C:\Selenium Session\OrangeAutomation\OrangeAutomation\TestData\data.json");
            string text = reader.ReadToEnd();
            dynamic json = JsonConvert.DeserializeObject(text);

            string value = Convert.ToString(json["url"]);

            Console.WriteLine(value); ;

        }


        [Test]
        public void CreateReport()
        {
        
            //report config - should run only once 
            ExtentHtmlReporter reporter = new ExtentHtmlReporter(@"C:\Selenium Session\OrangeAutomation\OrangeAutomation\Report\index.html");
     
            ExtentReports extent = new ExtentReports();
            extent.AttachReporter(reporter);

            //run before each test method [Setup]
            ExtentTest test= extent.CreateTest("TC1");

            test.Log(Status.Info, "running tc1");

            //run after each testcase - log current test pass or fail
            test.Log(Status.Pass, "test passed");

            //run before each test method [Setup]
            test = extent.CreateTest("TC2");

            //run after each testcase - log current test pass or fail
            test.Log(Status.Fail, "test fail");

            


            //should run at the end of all test method
            extent.Flush();
        }





        [Test]
        public void ExcelRead()
        {
            
            using (XLWorkbook book = new XLWorkbook(@"C:\Selenium Session\OrangeAutomation\OrangeAutomation\TestData\orange_data.xlsx"))
            {
                var sheet = book.Worksheet("InvalidCredentialTest");
                var range = sheet.RangeUsed();

                int rowCount = range.RowCount();
                int columnCount = range.ColumnCount();
                Console.WriteLine(rowCount);
                Console.WriteLine(columnCount);

                //size is based on numbe of test case - (rowcount-1)
                object[] main = new object[rowCount-1]; 

                for (int r = 2; r <= rowCount; r++)
                {
                    //size is based on colcount //number of arguments
                    object[] set = new object[columnCount];

                    for (int c = 1; c <= columnCount; c++)
                    {
                        string value = range.Cell(r, c).GetString();
                        Console.WriteLine(value);
                        set[c-1] = value;
                    }
                    main[r-2]=set;
                }
                //will start at 4:40 PM IST
                Console.WriteLine();
            }

        }













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

            string[] temp4 = new string[2];
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

        [Test, TestCaseSource(nameof(InvalidData))]
        public void InvalidTest(string username, string password)
        {
            Console.WriteLine("Invalid" + username + password);
        }
    }
}
