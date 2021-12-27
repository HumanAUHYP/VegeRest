using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegeRest.Controllers
{
    public class WaiterController : Controller
    {
        private IWebHostEnvironment Environment;
        private string path;

        // ссылка на объект - хранилище заказов
        OrderStorage orderStorage;

        public WaiterController(IWebHostEnvironment _environment, IOrderStorage _projectStorage)
        {
            orderStorage = (OrderStorage)_projectStorage;

            // получить путь до wwwroot
            Environment = _environment;
            path = Environment.WebRootPath;
        }

        public IActionResult Index()
        {
            orderStorage.ReadFromFile(path + "/data/orders.txt");
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
            orderStorage.WriteInFile(path + "/data/orders.txt");
            return RedirectToAction("Index");
        }

        public IActionResult Remove(string orderNum)
        {
            orderStorage.RemoveByNumber(orderNum);
            orderStorage.WriteInFile(path + "/data/orders.txt");
            return RedirectToAction("Index");
        }
        
    }
}
