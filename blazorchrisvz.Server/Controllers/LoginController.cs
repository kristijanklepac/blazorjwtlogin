using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using blazorchrisvz.Server.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;
using blazorchrisvz.Shared;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace blazorchrisvz.Server.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        [HttpPost]
        public IActionResult Login([FromBody] User user) {
            User u = new UserRepository().GetUser(user.Username);

            if (u == null)
                return Unauthorized();

            bool credentials = u.Password.Equals(user.Password);

            if (!credentials)
                return Unauthorized();

            return Ok(new { token = TokenManager.GenerateToken(user.Username) });

            }
    }
}
