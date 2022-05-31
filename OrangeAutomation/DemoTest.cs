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
        [Test]
        public void demo()
        {
            int a = 10;

            object z = a; //boxing 

            int res = (int)z; //unboxing

            //bool res1 = (bool)z; //unboxing

            object[] test=new object[10];
            test[0] = 7878787;
            test[1] = 10.2;
            test[2] = "Balaji";
            test[3] = new DemoTest();

            string name = (string)test[2]; //unboxing
        }

        //public static object[] invalidData()
        //{
            

        //    object[] temp1 = new object[2];
        //    temp1[0] = "John";
        //    temp1[1] = "john123";

        //    object[] temp2 = new object[2];
        //    temp2[0] = "peter";
        //    temp2[1] = "peter123";

        //    object[] temp3 = new object[2];
        //    temp3[0] = "mark";
        //    temp3[1] = "mark123";


        //}

        //[Test]
        //public void InvalidTest(string username,string password)
        //{
        //    Console.WriteLine("Invalid"+username+password);
        //}
    }
}
