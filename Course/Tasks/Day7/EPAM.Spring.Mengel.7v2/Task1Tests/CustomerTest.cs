using NUnit.Framework;
using System;
using Task1Logic;

namespace Task1Tests
{
    [TestFixture]
    public class CustomerTest
    {
        [TestCase(arg1: "f",  arg2: null, Result = "Customer record: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100",  TestName = "FullOutput", Description = "Show all properies")]
        [TestCase(arg1: "c",  arg2: null, Result = "Customer record: +1 (425) 555-0100",                                 TestName = "ContactOutput", Description = "Get just ContactPhone")]
        [TestCase(arg1: "nr", arg2: null, Result = "Customer record: Jeffrey Richter, 1,000,000.00",                     TestName = "NameAndContactOutput", Description = "Get Name and ContactPhone")]
        [TestCase(arg1: "n",  arg2: null, Result = "Customer record: Jeffrey Richter",                                   TestName = "NameOutput", Description = "Get just Name")]
        [TestCase(arg1: "r-", arg2: null, Result = "Customer record: 1000000",                                           TestName = "RevenueNotFormattedOutput", Description = "Get just Revenue not formatted")]
        [TestCase(arg1: "r",  arg2: null, Result = "Customer record: 1,000,000.00",                                      TestName = "RevenueOutput", Description = "Get just Revenue")]
        [TestCase(arg1: "sf", arg2: null, Result = "Task1Logic.Customer -> Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100", TestName = "ShowFullOutput", Description = "Modernized .ToString() with GetType() and Properties")]
        public string TestToString(string format, IFormatProvider provider)
        {
            var customer = new Customer("Jeffrey Richter", 1000000m, "+1 (425) 555-0100");
            return customer.ToString(format, provider);
        }

        [TestCase(arg1: "f", arg2: null, Result = "Helper show customer records: Jeffrey Richter, 1,000,000.00, +1 (425) 555-0100", TestName = "HelperFullOutput", Description = "Show helper extension with all properies")]
        public string TestPrint(string format, IFormatProvider provider)
        {
            var customer = new Customer("Jeffrey Richter", 1000000m, "+1 (425) 555-0100");
            return customer.ToString(format, provider, "Helper show customer records:");
        }
    }
}
