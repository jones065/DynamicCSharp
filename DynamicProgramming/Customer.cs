using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicProgramming
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public void WriteCustomer(string message)
        {
            Console.WriteLine($"{message} {FirstName} {LastName}");
        }
    }
}
