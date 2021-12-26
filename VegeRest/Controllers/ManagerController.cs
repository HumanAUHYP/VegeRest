using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegeRest.Controllers
{
    public class ManagerController : Controller
    {
        private IWebHostEnvironment Environment;
        private string path;

        // ссылка на объект - хранилище заказов
        OrderStorage orderStorage;

        public ManagerController(IWebHostEnvironment _environment, IOrderStorage _projectStorage)
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
            return View(orderStorage.Orders);
        }

        public IActionResult Ready(string name)
        {
            orderStorage.ReadyByNumber(name);
            orderStorage.WriteInFile(path + "/data/orders.txt");
            return RedirectToAction("Index");
        }
    }
}
