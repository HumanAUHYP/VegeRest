﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreLibrary;

namespace VegeRest.Controllers
{
    public class WaiterController : Controller
    {
        private IWebHostEnvironment Environment;
        private string path = @"C:\Users\Human\source\repos\VegeRest\CoreLibrary\data\orders.txt";

        // ссылка на объект - хранилище заказов
        OrderStorage orderStorage;

        public WaiterController(IWebHostEnvironment _environment, IOrderStorage _projectStorage)
        {
            orderStorage = (OrderStorage)_projectStorage;
        }

        public IActionResult Index()
        {
            orderStorage.ReadFromFile(path);
            var orders = orderStorage.Orders;

            return View(orders);
        }
    }
}