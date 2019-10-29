using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Izh09FrameworkFundamentals
{
    internal class Customer
    {
        private string Name { get; set; }

        private string ContactPhone { get; set; }

        private decimal Revenue { get; set; }

        public Customer() { }

        public Customer(string name, string contactPhone, decimal revenue)
        {
            this.Name = name;
            this.ContactPhone = contactPhone;
            this.Revenue = revenue;
        }

        public string GetName()
        {
            return "- Customer record: " + this.Name;
        }

        public string GetContactPhone()
        {
            return "- Customer record: " + this.ContactPhone;
        }

        /// <summary>
        /// Defold GetRevenue, return the Revenue in ru-Culture.
        /// </summary>
        /// <param name="Revenue">in decimal form. </param>
        /// <returns>Revenue in Russian Culture. </returns>
        public string GetRevenue()
        {
            CultureInfo ru = new CultureInfo("ru-Ru");
            string culturalRevenue = this.Revenue.ToString(ru);
            return culturalRevenue;
        }

        /// <summary>
        /// GetRevenue with parameter, return the Revenue in your-Culture.
        /// </summary>
        /// <param name="Revenue">in decimal form. </param>
        /// <returns>Revenue in your Culture. </returns>
        public string GetRevenue(string culture)
        {
            CultureInfo.CurrentCulture = new CultureInfo("en-GB");
            //NumberFormatInfo formatInfo = yourCulture.NumberFormat;
            string culturalRevenue = this.Revenue.ToString();
            return culturalRevenue;
        }
    }
}
