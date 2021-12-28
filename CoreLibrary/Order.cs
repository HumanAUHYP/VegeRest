using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLibrary
{
    public class Order
    {
        public string OrderNumber { get; set; }
        public string TableNumber { get; set; }
        public string Product { get; set; }
        public string Status { get; set; }

        public Order()
        { }

        public Order(string str)
        {
            var data = str.Split(';');
            OrderNumber = data[0];
            TableNumber = data[1];
            Product = data[2];
            Status = "Принят";
        }

        public override string ToString()
        {
            return $"{OrderNumber};{TableNumber};{Product};{Status}";
        }
    }
}
