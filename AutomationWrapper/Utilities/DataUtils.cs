using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.Utilities
{
    public class DataUtils
    {
        /// <summary>
        /// Provide data to the Invalid Credentials
        /// </summary>
        /// <returns>return object[] </returns>
        public static object[] InvalidCredentialData()
        {
            object[] main = ExcelUtils.GetSheetIntoObjectArray(@"C:\Selenium Session\OrangeAutomation\OrangeAutomation\TestData\orange_data.xlsx", "InvalidCredentialTest");
            return main;
        }
        /// <summary>
        /// Provide data to the Add Emergency Contact 
        /// </summary>
        /// <returns>return object[] </returns>
        public static object[] EmergencyContactData()
        {
            object[] main = ExcelUtils.GetSheetIntoObjectArray(@"C:\Selenium Session\OrangeAutomation\OrangeAutomation\TestData\orange_data.xlsx", "AddEmergencyContactTest");
            return main;
        }

        //public static object[] EmergencyContactData()
        //{
        //    object[] set1 = new object[8];
        //    set1[0] = "Admin";
        //    set1[1] = "admin123";
        //    set1[2] = "Sat";
        //    set1[3] = "Brother";
        //    set1[4] = "3434";
        //    set1[5] = "3434";
        //    set1[6] = "3434";
        //    set1[7] = "Sat;Brother;3434";

        //    object[] set2 = new object[8];
        //    set2[0] = "Admin";
        //    set2[1] = "admin123";
        //    set2[2] = "John";
        //    set2[3] = "Brother";
        //    set2[4] = "53434";
        //    set2[5] = "53434";
        //    set2[6] = "53434";
        //    set2[7] = "John;Brother;53434";

        //    object[] main = new object[2];
        //    main[0] = set1;
        //    main[1] = set2;

        //    return main;
        //}


    }
}
