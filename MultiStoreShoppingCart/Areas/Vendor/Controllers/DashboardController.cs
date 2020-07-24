using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiStoreShoppingCart.Models;

namespace MultiStoreShoppingCart.Areas.Vendor.Controllers
{

    [Authorize(Roles = "Vendor", AuthenticationSchemes = "Schema_Vendor")]
    [Area("vendor")]
    [Route("vendor/dashboard")]
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

