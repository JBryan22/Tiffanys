using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tiffanys.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Tiffanys.Controllers
{
	[Authorize]
	public class AssociatesController : Controller
	{
		private readonly ApplicationDbContext _db;
		private readonly UserManager<ApplicationUser> _userManager;

		public AssociatesController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
		{
			_userManager = userManager;
			_db = db;
		}

		// GET: /<controller>/
		public async Task<IActionResult> Index()
		{
			var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var currentUser = await _userManager.FindByIdAsync(userId);
            ViewBag.Associate = _db.Associates.FirstOrDefault(x => x.User.Id == currentUser.Id);
            var allItems = _db.Items.Where(m => m.Sold == false).Include(m => m.Product).ToList();
			return View(allItems);
		}


        [HttpPost]
        public IActionResult SoldItem(int associateId, int itemId)
        {
            AssociateItem newSale = new AssociateItem(associateId, itemId);
            var soldItem = _db.Items.Include(m => m.Product).FirstOrDefault(i => i.ItemId == itemId);
            var thisAssociate = _db.Associates.FirstOrDefault(a => a.AssociateId == associateId);
            thisAssociate.TotalSales += soldItem.Product.RetailPrice;
            Product.TotalRevenue += soldItem.Product.RetailPrice;
            soldItem.Sold = true;

            _db.AssociateItems.Add(newSale);

			_db.Entry(thisAssociate).State = EntityState.Modified;
            _db.Entry(soldItem).State = EntityState.Modified;

            _db.SaveChanges();
            @ViewBag.Item = soldItem;
            return View("SoldItem");
        }

        public async Task<IActionResult> AssociateSales()
        {
			var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
			var currentUser = await _userManager.FindByIdAsync(userId);
			var associate = _db.Associates.FirstOrDefault(x => x.User.Id == currentUser.Id);
            var associateSales = _db.AssociateItems.Include(i => i.Item)
                                                    .Where(ai => ai.AssociateId == associate.AssociateId)
                                    .Select(ai => ai.Item)

                                    .Include(i => i.Product)


													.ToList();  
            
            return View(associateSales);
        }


   //    public IActionResult SoldItemView(int associateId, int itemId)
   //     {
			//var soldItem = _db.Items.Include(m => m.Product).FirstOrDefault(i => i.ItemId == itemId);
			//var thisAssociate = _db.Associates.FirstOrDefault(a => a.AssociateId == associateId);
        //    return View();
        //}

        public IActionResult DisplayView()
        {
            return View();
        }


	}
}
