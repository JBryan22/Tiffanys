using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tiffanys.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tiffanys.Controllers
{   
    [Authorize]
    public class ProductsController : Controller
	{
		private readonly ApplicationDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;
		public ProductsController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
		{
			_userManager = userManager;
			_db = db;
		}

		public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult NewProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return Json(product);
        }
    }
}
