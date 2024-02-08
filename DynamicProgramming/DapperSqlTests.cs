using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    internal class DapperSqlTests
    {
        public static void RunTests()
        {
            DapperSqlTests tests = new DapperSqlTests();
            tests.RunSqlTest();
        }

        public void RunSqlTest()
        {
            string connString = "Data Source=DEV2\\DEV2SQL;Initial Catalog=Students;Integrated Security=True;TrustServerCertificate=True";

            using var conn = new SqlConnection(connString);

            IEnumerable<dynamic> studentList = conn.Query("Select top 10 * from Students");

            foreach (var student in studentList)
            {
                Console.WriteLine($"Name: {student.LastName}, {student.FirstName}");
            }
        }
    }
}
