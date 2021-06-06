using Microsoft.Extensions.Logging;
using PizzaSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaSystem.Services
{
    public class PizzaService : IPizza<Pizza>
    {
        readonly PizzaContext _context;
        readonly ILogger<PizzaService> _Logger;

        public PizzaService(PizzaContext context, ILogger<PizzaService> logger)
        {
            _context = context;
            _Logger = logger;
        }

        public void Add(Pizza t)
        {
            try
            {
                _context.Pizzas.Add(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
        }

        public void Delete(Pizza t)
        {
            try
            {
                _context.Pizzas.Remove(t);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
        }

        public Pizza Get(int id)
        {
            try
            {
                Pizza Pizza = _context.Pizzas.FirstOrDefault(i => i.PizzaId == id);
                return Pizza;
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
            return null;
        }

        public IEnumerable<Pizza> GetAll()
        {
            try
            {
                if (_context.Pizzas.Count() == 0)
                {
                    return null;
                }
                return _context.Pizzas.ToList();
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
            return null;
        }

        public void Update(int id, Pizza t)
        {
            try
            {
                Pizza Pizza = Get(id);
                if (Pizza != null)
                {
                    Pizza.PizzaName = t.PizzaName;
                    Pizza.Price = t.Price;
                    Pizza.Speciality = t.Speciality;
                    Pizza.IsVeg = t.IsVeg;
                }
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _Logger.LogDebug(e.Message);
            }
        }
    }
}