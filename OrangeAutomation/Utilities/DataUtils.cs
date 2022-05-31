using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fujitsu.OrangeAutomation.Utilities
{
    public class DataUtils
    {
        /// <summary>
        /// Provide data to the Invalid Credentials
        /// </summary>
        /// <returns>return object[] </returns>
        public static object[] InvalidCredentialData()
        {
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



    }
}
