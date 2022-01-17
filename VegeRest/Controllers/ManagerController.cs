using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using CoreLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegeRest.Controllers
{
    public class ManagerController : Controller
    {
        private string path = @"C:\Users\Human\source\repos\VegeRest\CoreLibrary\data\orders.txt"; // Можно лучше - Путь лучше хранить динамически

        // ссылка на объект - хранилище заказов
        OrderStorage orderStorage;

        public ManagerController(IWebHostEnvironment _environment, IOrderStorage _projectStorage)
        {
            orderStorage = (OrderStorage)_projectStorage;
        }
        public IActionResult Index()
        {
            orderStorage.ReadFromFile(path);
            var orders = orderStorage.Orders;
            
            return View(orders);
        }

        public IActionResult Ready(string orderNum)
        {
            orderStorage.ReadyByNumber(orderNum);
            orderStorage.WriteInFile(path);
            return RedirectToAction("Index");
        }
    }
}
