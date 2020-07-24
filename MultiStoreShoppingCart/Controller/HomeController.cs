using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MultiStoreShoppingCart.Controllers
{
    [Route("home")]

    public class HomeController : Controller
    {
        [Route("index")]
        [Route("")]
        [Route("~/")]
        public IActionResult Index()
        {

            string password = BCrypt.Net.BCrypt.HashPassword("123");
            return View();
        }
    }
}
