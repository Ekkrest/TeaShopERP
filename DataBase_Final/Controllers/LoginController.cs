using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;
using DataBase_Final.Repositories;
using DataBase_Final.Models;
using Dapper;
using static Dapper.SqlMapper;
using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DataBase_Final.Controllers
{
    public class LoginController : Controller
    {
        IRepository repo = new MyRepository();

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Administrator _admin) 
        {
            if ((_admin != null) && ModelState.IsValid)
            {
                SqlConnection Conn = repo.ConnOpen();

                string sqlstr = "INSERT INTO [Administrator] ([AdministratorName],[Password])";
                sqlstr += " VALUES (@AdministratorName, @Password)";

                int affectRows = Conn.Execute(sqlstr, new
                {
                    AdministratorName = _admin.AdministratorName,
                    Password = _admin.Password
                });

                return RedirectToAction("Login");
            }
            else 
            {
                ModelState.AddModelError("", "");
                return View();
            }      
        }

        public IActionResult Login() {
            return View();
        }

        [HttpPost] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Administrator _admin) 
        {

            if (ModelState.IsValid) 
            {
                SqlConnection Conn = repo.ConnOpen();

                string sqlstr = "Select * from [Administrator] Where AdministratorName = @AdministratorName ";
                sqlstr += "and Password = @Password";
                var sqlparameter = new
                {
                    AdministratorName = _admin.AdministratorName,
                    Password = _admin.Password
                };
                Administrator result = Conn.QueryFirstOrDefault<Administrator>(sqlstr, sqlparameter);

                repo.ConnClose(Conn);

                if (result == null)
                {
                    ModelState.AddModelError("Password", "你輸入的帳號密碼錯誤，請重新輸入");
                    return View();
                }
                else 
                {
                    var claims = new List<Claim>
                    {
                        new Claim("AdministratorID", result.AdministratorId.ToString()),
                        new Claim(ClaimTypes.Name, result.AdministratorName),
                        new Claim(ClaimTypes.Role, "Administrator")
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        AllowRefresh = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddHours(3),
                        IsPersistent = true
                    };

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                                                                        new ClaimsPrincipal(claimsIdentity),
                                                                        authProperties);

                    return RedirectToAction("ProductList", "Product");

                }
            }
            return View();
        }

        public async Task<IActionResult> Logout() 
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction(nameof(Login), "Login");
        }
    }
}
