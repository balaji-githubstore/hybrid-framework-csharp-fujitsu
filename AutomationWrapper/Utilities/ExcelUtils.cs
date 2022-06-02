using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClosedXML.Excel;

namespace Fujitsu.Utilities
{
    public class ExcelUtils
    {
        /// <summary>
        /// Convert Sheet intot Object[] 
        /// It can be used in any application
        /// </summary>
        /// <param name="file">Excel Location</param>
        /// <param name="sheetname">SheetName (TestMethodName)</param>
        /// <returns>object[]</returns>
        public static object[] GetSheetIntoObjectArray(string file, string sheetname)
        {
            using (XLWorkbook book = new XLWorkbook(file))
            {
                var sheet = book.Worksheet(sheetname);
                var range = sheet.RangeUsed();

                int rowCount = range.RowCount();
                int columnCount = range.ColumnCount();
                //size is based on numbe of test case - (rowcount-1)
                object[] main = new object[rowCount - 1];

                for (int r = 2; r <= rowCount; r++)
                {
                    //size is based on colcount //number of arguments
                    object[] set = new object[columnCount];

                    for (int c = 1; c <= columnCount; c++)
                    {
                        string value = range.Cell(r, c).GetString();

                        set[c - 1] = value;
                    }
                    main[r - 2] = set;
                }
                return main;
            }
        }

        /// <summary>
        /// To get cell value
        /// </summary>
        /// <param name="file"></param>
        /// <param name="sheetname"></param>
        /// <param name="rowNumber"></param>
        /// <param name="columnNumber"></param>
        /// <returns></returns>
        public static string GetCellValue(string file, string sheetname, int rowNumber, int columnNumber)
        {
            using (XLWorkbook book = new XLWorkbook(file))
            {
                var sheet = book.Worksheet(sheetname);
                var range = sheet.RangeUsed();

                return range.Cell(rowNumber, columnNumber).GetString();
            }
        }
    }
}
