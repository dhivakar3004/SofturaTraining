using Microsoft.Extensions.Logging;
using PizzaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSystem.Services
{
    public class OrderService : IOrder<Order>
    {
        readonly PizzaContext _context;
        readonly ILogger<OrderService> _Logger;

        public OrderService(PizzaContext context, ILogger<OrderService> logger)
        {
            _context = context;
            _Logger = logger;
        }

        public void AddOrder(Order o)
        {
            try
            {
                _context.Orders.Add(o);
                _context.SaveChanges();

                var orderDetails = new OrderDetails();
                orderDetails.OrderId = o.OrderId;
                orderDetails.pizzaId = o.PizzaId;
                orderDetails.Quantity = o.Quantity;
                orderDetails.Toppings = o.Toppings;
                orderDetails.CrustType = o.CrustType;
                AddOrderDetail(orderDetails);
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }

        }
        private void AddOrderDetail(OrderDetails odt)
        {
            try
            {
                _context.OrderDetails.Add(odt);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
        }
    }
}