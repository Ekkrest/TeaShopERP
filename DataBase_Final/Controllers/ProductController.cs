using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlMapper;
using DataBase_Final.Repositories;
using DataBase_Final.Models;
using Microsoft.Data.SqlClient;

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
            SqlConnection Conn = repo.ConnOpen();

            string sqlstr = "Select * From [ProductCategory] AS pc";
            sqlstr += " INNER JOIN [Product] AS p ON pc.ProductCategoryId = p.ProductCategoryId";

            var resultDictionary = new Dictionary<int, ProductCategory>();

            var endData = Conn.Query<ProductCategory, Product, ProductCategory>(

                sqlstr,
                (pc, p) =>
                {
                    if (!resultDictionary.TryGetValue(pc.ProductCategoryId, out ProductCategory pcEntry))
                    {
                        pcEntry = pc;
                        pcEntry.Products = new List<Product>();

                        resultDictionary.Add(pcEntry.ProductCategoryId, pcEntry);
                    }
                    pcEntry.Products.Add(p);
                    return pcEntry;
                },
                splitOn: "ProductId")
                .Distinct();

            repo.ConnClose(Conn);
            return View(endData);
        }
    }
}
