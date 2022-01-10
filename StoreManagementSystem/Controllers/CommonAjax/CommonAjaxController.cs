using StoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManagementSystem.Controllers.CommonAjax
{
    public class CommonAjaxController : Controller
    {
        // GET: CommonAjax
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCategoryNameById(int categoryID)
        {
            using (SMSEntities ent = new SMSEntities())
            {
                var categoryName = ent.categorySetup.Where(x=> x.Status == true && x.deletedDate == null 
                && x.categoryID == categoryID).Select(x => x.categoryName).FirstOrDefault();
                return Json(categoryName, JsonRequestBehavior.AllowGet);
            }
        }
    }
}