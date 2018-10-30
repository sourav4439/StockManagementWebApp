using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StockManagementWebApp.Models;

namespace StockManagementWebApp.Controllers
{
    public class StockController : Controller
    {
        private ApplicationDbContext db;

        public StockController()
        {
            db =new ApplicationDbContext();
            
        }

        [HttpGet]
        public ActionResult Stockin()
        {
            ViewBag.Company=db.Companies.Select(c => new SelectListItem{Value = c.Id.ToString(),Text = c.Name}).ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Stockin(StockIn stockIn)
        {
            return View();
        }

        public JsonResult GetItemByCompanyId(int companyId)
        {
           var items=db.Items.Where(i => i.CompanyId == companyId).Select(i=>new SelectListItem {Value = i.Id.ToString(),Text = i.ItemName}).ToList();
            return Json(items);
        }
    }
}