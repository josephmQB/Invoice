using Invoice.IService;
using Invoice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.Service
{
    public class UserService : IUserService
    {
        private InvoiceDBContext _dbContext;
        /// <summary>
        /// 
        /// </summary>
        public UserService()
        {
            _dbContext = new InvoiceDBContext();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string username, string password)
        {
            var user = _dbContext.UserAdministrations.Where(t => t.UserName == username).FirstOrDefault();
            if(user !=null)
            {
                return BCrypt.Net.BCrypt.Verify(password, user.Password);
            }
            return false;
        }

        public bool Signup(UserAdministration user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _dbContext.UserAdministrations.Add(user);
            _dbContext.SaveChanges();
            return true;
        }
    }
}
