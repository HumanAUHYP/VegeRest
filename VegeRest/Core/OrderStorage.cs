﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace VegeRest
{
    public interface IOrderStorage
    {
        void Add(Order order);
        void RemoveByNumber(string name);
        void ReadFromFile(string path);
        void WriteInFile(string path);
    }
    public class OrderStorage : IOrderStorage
    {
        public List<Order> Orders { get; private set; }

        public OrderStorage()
        {
            Orders = new List<Order>();
        }

        public void Add(Order order)
        {
            Orders.Add(order);
        }

        public void ReadyByNumber(string orderNum)
        {
            int id = 0;
            foreach (var el in Orders)
            {
                if (el.OrderNumber == orderNum)
                {
                    id = Orders.IndexOf(el);
                }
            }
            Orders[id].Status = "Готов";
        }

        public void RemoveByNumber(string orderNum)
        {
            Orders.RemoveAll(p => p.OrderNumber == orderNum);
        }

        public void ReadFromFile(string path)
        {
            Orders.Clear();
            try
            {
                using (var sr = new StreamReader(path))
                {
                    string str;
                    while ((str = sr.ReadLine()) != null)
                    {
                        Orders.Add(new Order(str));
                    }
                }
            }
            catch (Exception) { }
        }

        public void WriteInFile(string path)
        {
            using (var sw = new StreamWriter(path, false))
            {
                foreach (var el in Orders)
                {
                    sw.WriteLine(el);
                }
            }
        }
    }
}
