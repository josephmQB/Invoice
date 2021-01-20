using Invoice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Invoice.IService
{
    public interface IUserService
    {
        bool Signup(UserAdministration user);
        bool Login(string username, string password);
    }
}
