using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using task1inWebApp.Context;
using task1inWebApp.Models;

namespace task1inWebApp.Services
{
    public class UserServices : IUserRepo<UserModel>
    {
        private UserContext _context;
        private ILogger<UserServices> _logger;

        public UserServices(UserContext context, ILogger<UserServices> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IEnumerable<UserModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Login(UserModel t)
        {
            try
            {
                UserModel user = _context.Users.SingleOrDefault(u => u.UserName == t.UserName);
                if (user.Password == t.Password)
                    return true;

            }
            catch (Exception)
            {

                return false;
            }
            return false;
            
        }

        public bool Register(UserModel t)
        {
            try
            {   
                _context.Users.Add(t);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                
            }
            return false;
        }
    }
}