using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MultiStoreShoppingCart.Areas.Vendor.Controllers
{
    [Area("vendor")]
    [Route("vendor/login")]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
