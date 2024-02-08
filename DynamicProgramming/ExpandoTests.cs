using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace DynamicProgramming
{
    public class ExpandoTests
    {
        public static void SerilizationTest()
        {
            dynamic person = new ExpandoObject();
            person.name = "Jeff Jones";
            person.gender = "Male";
            person.age = 53;
            person.birthday = new DateTime(1970, 4, 29);

            string s = JsonConvert.SerializeObject(person);
            Console.WriteLine(s);

            // ExpandoObjects implement an IDictionary behind the scenes as IDictionary<string, object?>
            // So, it is possible to cast an Expando to a Dictionary
            var dict = (IDictionary<string, object?>)person;
            foreach(var key in dict.Keys)
            {
                Console.WriteLine($"Key: {key} Value: {dict[key]}");
            }
        }
    }
}
