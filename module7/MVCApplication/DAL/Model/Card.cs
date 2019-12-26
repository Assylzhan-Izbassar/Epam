using System;

using System.Text;

namespace DAL.Model
{
    public class Card
    {
        public int CardID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Brand { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
