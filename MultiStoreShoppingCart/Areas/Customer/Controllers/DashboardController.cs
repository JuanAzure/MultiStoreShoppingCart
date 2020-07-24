using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiStoreShoppingCart.Models;

namespace MultiStoreShoppingCart.Areas.Customer.Controllers
{

    [Authorize(Roles = "Customer", AuthenticationSchemes = "Schema_Customer")]
    [Area("customer")]
    [Route("customer/dashboard")]
    public class DashboardController : Controller
    {
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}

