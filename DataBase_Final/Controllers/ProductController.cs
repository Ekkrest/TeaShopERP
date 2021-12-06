using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using DataBase_Final.Repositories;

namespace DataBase_Final.Controllers
{
    public class ProductController : Controller
    {
        IRepository repo = new MyRepository();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ProductList() 
        {
            return Content("登入成功!!!");
        }
    }
}
