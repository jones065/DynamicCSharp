using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class ReflectionTests
    {
        public static void RunTests()
        {
            var customer = new Customer()
            {
                FirstName = "Jeff",
                LastName = "Jones"
            };

            ReflectionTests tests = new ReflectionTests();
            tests.InvokeMethodUsingReflection(customer);
            tests.InvokeMethodUsingDynamic(customer);
            tests.GetPropertyValueUsingReflection(customer);
            tests.GetPropertyValueUsingDynamic(customer);
            
        }

        public void InvokeMethodUsingReflection(object o)
        {
            Type t = o.GetType();

            t.InvokeMember("WriteCustomer", 
                System.Reflection.BindingFlags.InvokeMethod,
                null,
                o,
                new object[] {"Customer data (reflection): " });
        }

        public void InvokeMethodUsingDynamic(object o)
        {
            dynamic c = o;
            c.WriteCustomer("Customer data (dynamic): ");
        }

        public void GetPropertyValueUsingReflection(object o)
        {
            Type t = o.GetType();

            object? result = t.InvokeMember("FirstName",
                System.Reflection.BindingFlags.GetProperty,
                null,
                o,
                null);

            Console.WriteLine($"Property value (reflection): {result}");
        }

        public void GetPropertyValueUsingDynamic(object o)
        {
            dynamic c = o;
            Console.WriteLine($"Property value (reflection): {c.FirstName}");
        }
    }
}
