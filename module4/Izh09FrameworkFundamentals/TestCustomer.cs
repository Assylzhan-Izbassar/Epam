using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh09FrameworkFundamentals
{
    [TestFixture]
    class TestCustomer
    {
        [TestCase]
        public void TestGetRevenue()
        {
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);

            string result = "1000000";

            Assert.AreEqual(customer.GetRevenue(), result);
        }

        [TestCase("de-DE", ExpectedResult = "1,000,000")]
        public string TestGetRevenueInCulture(string culture)
        {
            Customer customer = new Customer("Jeffrey Richter", "+1 (425) 555-0100", 1000000);

            return customer.GetRevenue(culture);
        }
    }
}
