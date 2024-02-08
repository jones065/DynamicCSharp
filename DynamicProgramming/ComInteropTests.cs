using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Versioning;

namespace DynamicProgramming
{
    [SupportedOSPlatform("windows")]
    public class ComInteropTests
    {
        public static void RunTests()
        {
            ComInteropTests tests = new ComInteropTests();
            tests.ExcelTest();
        }

        public void ExcelTest()
        {
            Console.WriteLine("Please enter a customer name: ");
            var name = Console.ReadLine()!;

            Type excelType = Type.GetTypeFromProgID("Excel.Application")!;
            dynamic excel = Activator.CreateInstance(excelType)!;

            excel.Visible = true;
            excel.Workbooks.Add();

            dynamic defaultWorksheet = excel.ActiveSheet;

            defaultWorksheet.Cells[1, "A"] = "Customer Name";
            defaultWorksheet.Columns[1].AutoFit();

            defaultWorksheet.Cells[1, "B"] = name;
            defaultWorksheet.Columns[1].AutoFit();

            //Console.WriteLine("\n\nPress enter to exit...");
            //Console.ReadLine();
        }
    }
}
