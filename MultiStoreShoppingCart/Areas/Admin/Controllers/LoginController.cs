using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiStoreShoppingCart.Models;
using MultiStoreShoppingCart.Repositories;
using MultiStoreShoppingCart.Security;

namespace MultiStoreShoppingCart.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/login")]
    public class LoginController : Controller
    {
        private IAccountRepository accountRepository;

        public LoginController(IAccountRepository _accountRepository)
        {
            accountRepository = _accountRepository;
        }

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string username, string password)
        {
            var account = accountRepository.Login(username, password, 1);
            if (account == null)
            {
                ViewBag.error = "Invalid";
                return View("index");
            }
            else
            {
                var securityManager = new SecurityManager();
                securityManager.SignIn(this.HttpContext, account, "Schema_Admin");
                return RedirectToAction("index", "dashboard", new { area = "admin" });
            }
        }

        [Authorize(Roles = "Admin", AuthenticationSchemes = "Schema_Admin")]
        [HttpGet]
        [Route("profile")]
        public IActionResult Profile()
        {
            var user = User.FindFirst(ClaimTypes.Name);
            var username = user.Value;
            var account = accountRepository.getByUsername(username);
            return View("Profile", account);
        }


        [Authorize(Roles = "Admin", AuthenticationSchemes = "Schema_Admin")]
        [HttpPost]
        [Route("profile")]
        public async Task<IActionResult> Profile(Account account)
        {
            var currentAccount = await accountRepository.GetByIdNoTracking(account.Id);

            if (!string.IsNullOrEmpty(account.Password))
            {
                account.Password = BCrypt.Net.BCrypt.HashPassword(account.Password);
            }
            else
            {
                account.Password = currentAccount.Password;
            }
            account.Status = currentAccount.Status;
            await accountRepository.Update(account.Id, account);
            return RedirectToAction("profile", "login", new { area = "admin" });
        }

        [Authorize(Roles = "Admin", AuthenticationSchemes = "Schema_Admin")]
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout()
        {
            var securityManager = new SecurityManager();
            securityManager.SignOut(this.HttpContext, "Schema_Admin");
            return RedirectToAction("index", "login", new { area = "admin" });
        }
    }
}
