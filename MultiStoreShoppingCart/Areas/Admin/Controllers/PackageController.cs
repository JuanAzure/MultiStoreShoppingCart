using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiStoreShoppingCart.Models;
using MultiStoreShoppingCart.Repositories;

namespace MultiStoreShoppingCart.Areas.Admin.Controllers
{

    [Authorize(Roles = "Admin", AuthenticationSchemes = "Schema_Admin")]
    [Area("admin")]
    [Route("admin/package")]
    public class PackageController : Controller
    {
        private IPackageRepository packageRepository;

        public PackageController(IPackageRepository _packageRepository)
        {
            packageRepository = _packageRepository;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            ViewBag.packages = packageRepository.GetAll().ToList();
            return View();
        }

        [HttpGet]
        [Route("add")]
        public IActionResult Add()
        {
            return View("Add", new Package());
        }

        [HttpPost]
        [Route("add")]
        public async Task<IActionResult> Add(Package package)
        {
           await packageRepository.Create(package);
           return RedirectToAction("Index", "package", new { area = "admin" });
        }

        [HttpGet]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var package = await packageRepository.GetById(id);
            return View("Edit", package);
        }


        [HttpPost]
        [Route("edit/{id}")]
        public async Task<IActionResult> Edit(int id,Package package)
        {
            await packageRepository.Update(id,package);
            return RedirectToAction("index", "package", new { area = "admin" });
        }


        [HttpGet]
        [Route("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await packageRepository.Delete(id);
            return RedirectToAction("index", "package", new { area = "admin" });
        }
    }
}

