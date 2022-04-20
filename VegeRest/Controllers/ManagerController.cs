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
        private IWebHostEnvironment Environment;
        private string path = @"C:\Users\Human\source\repos\VegeRest\CoreLibrary\data\orders.txt";

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

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Order order)
        {
            orderStorage.Add(order);
            orderStorage.WriteInFile(path);
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string orderNum)
        {
            orderStorage.RemoveByNumber(orderNum);
            orderStorage.WriteInFile(path);
            return RedirectToAction("Index");
        }
    }
}
