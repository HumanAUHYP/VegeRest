using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreLibrary //Проверяли Чийпеш Владислав и Шагиахметова Зиля
{
    public class Order
    {
        public string OrderNumber { get; set; } //не настроен сеттер, можно лучше
        public string TableNumber { get; set; }
        public string Product { get; set; }
        public string Status { get; set; }

        public Order()
        { } //нужно исправить, не форматированный код 

        public Order(string str) // Хорошо! Есть конструкторы
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
