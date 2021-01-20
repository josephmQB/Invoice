using Invoice.DTOs;
using Invoice.IService;
using Invoice.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invoice.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<AccountController>
        [Route("login")]
        [HttpPost]
        public bool Login ([FromBody] LoginDTO login )
        {
            return  _userService.Login(login.UserName,login.Password);
        }

        // POST api/<AccountController>
        [Route("signup")]
        [HttpPost]
        public bool SignUp([FromBody] UserAdministration user)
        {
            user.CompId = Guid.Parse( "02CE1048-96F3-4E46-8EDE-C65EAB8E04A7");
            user.UserId = Guid.NewGuid();
            return  _userService.Signup(user);
        }
    }
}
