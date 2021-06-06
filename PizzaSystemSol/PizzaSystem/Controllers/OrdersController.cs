using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using PizzaSystem.Models;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using PizzaSystem.Services;

namespace PizzaSystem.Controllers
{
    public class OrderController : Controller
    {
        private ILogger<OrderController> _logger;
        private IOrder<Order> _repo;
        private IPizza<Pizza> _pizza;
        public OrderController(IPizza<Pizza> pizza, IOrder<Order> repo, ILogger<OrderController> logger)
        {
            _logger = logger;
            _repo = repo;
            _pizza = pizza;
        }
        [HttpGet]
        public IActionResult Index(int pizzaId)
        {
            Pizza P = _pizza.Get(pizzaId);
            TempData["pizzaId"] = P.PizzaId;
            TempData["PizzaName"] = P.PizzaName;
            TempData["PizzaPrice"] = P.Price;
            return View();
        }
        public IActionResult SaveOrder(Order order)
        {
            try
            {
                _repo.AddOrder(order);
                return View("Success", order);

            }
            catch (Exception e)
            {
                _logger.LogDebug(e.Message);
                return RedirectToAction("Error", "Home");
            }

        }
        public IActionResult Confirm(Order order)
        {
            int pizza_id = order.PizzaId;
            Pizza p = _pizza.Get(pizza_id);
            TempData["PizzaName"] = p.PizzaName;
            TempData["PizzaPrice"] = p.Price;
            return View(order);
        }

        public ActionResult Success()
        {
            return View();
        }


    }
}