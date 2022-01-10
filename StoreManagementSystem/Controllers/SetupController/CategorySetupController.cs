using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SMS.Core.SetupViewModel;
using System.Data.Entity;
using StoreManagementSystem.Entities;
using System.IO;

namespace StoreManagementSystem.Controllers.SetupController
{
    public class CategorySetupController : Controller
    {
        // GET: CategorySetup
        // for inserting new record

        SMSEntities ent = new SMSEntities(); //initalize

        public ActionResult Index()
        {
            CategorySetupViewModel model = new CategorySetupViewModel();
            model.CategorySetupViewModelList = (from i in ent.categorySetup
                                                where i.deletedDate == null && i.Status == true
                                                select new CategorySetupViewModel
                                                {
                                                    categoryID = i.categoryID,
                                                    categoryName = i.categoryName,
                                                    Status = i.Status,
                                                    createdBy = i.createdBy,
                                                    createdDate = i.createdDate,   
                                                    updatedBy = i.updatedBy,
                                                    updatedDate = i.updatedDate,
                                                    deletedBy = i.deletedBy,
                                                    deletedDate = i.deletedDate,
                                                    imagePath = i.imagePath,
                                                }).ToList();

            return View(model);
        }

        //FOR SEARCH FUNCTION
        public ActionResult _SearchCategory(string categoryName)
        {
            CategorySetupViewModel model = new CategorySetupViewModel();
            model.CategorySetupViewModelList = (from i in ent.categorySetup
                                                where i.deletedDate == null && i.Status == true
                                                select new CategorySetupViewModel
                                                {
                                                    categoryID = i.categoryID,
                                                    categoryName = i.categoryName,
                                                    Status = i.Status,
                                                    createdBy = i.createdBy,
                                                    createdDate = i.createdDate,
                                                    updatedBy = i.updatedBy,
                                                    updatedDate = i.updatedDate,
                                                    deletedBy = i.deletedBy,
                                                    deletedDate = i.deletedDate,
                                                    imagePath = i.imagePath
                                                }).ToList();

            if(!String.IsNullOrEmpty(categoryName))
            {
                model.CategorySetupViewModelList = model.CategorySetupViewModelList
                    .Where(x => x.categoryName.ToLower()
                    .Contains(categoryName.ToLower())).ToList();
            }

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategorySetupViewModel model, HttpPostedFileBase file)
        {
            categorySetup entityCategory = new categorySetup(); //take name

            var imagePath = "/Content/Images/";

            if (file != null)
            {
                var fileName = Path.GetFileName(file.FileName);
                var path = Path.Combine(Server.MapPath(imagePath), fileName);
                file.SaveAs(path);
                model.imageName = file.FileName;
                model.imagePath = imagePath + file.FileName;
            }

            entityCategory.categoryName = model.categoryName;
            entityCategory.Status = true;
            entityCategory.createdBy = 1;
            entityCategory.createdDate = DateTime.Now;

            entityCategory.imageName = model.imageName;
            entityCategory.imagePath = model.imagePath;

            ent.Entry(entityCategory).State = EntityState.Added; //adds data
            ent.SaveChanges();

            return RedirectToAction("Index"); //redirects to index page onclick "create-btn" in views
        }

        //for editing records
        public ActionResult Edit(int id)
        {
            categorySetup model = new categorySetup();
            var data = ent.categorySetup.Where(x => x.categoryID == id).FirstOrDefault();
            if (data != null)
            {
                model.categoryID = data.categoryID;
                model.categoryName = data.categoryName;
                model.imageName= data.imageName;
                model.imagePath = data.imagePath;
                
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategorySetupViewModel model)
        {
            categorySetup entityCategory = new categorySetup(); //take name
            entityCategory.categoryID = model.categoryID;
            entityCategory.categoryName = model.categoryName;
            entityCategory.Status = true;
            entityCategory.createdBy= 1;
            entityCategory.createdDate = DateTime.Now;
            entityCategory.updatedBy = 1;
            entityCategory.updatedDate = DateTime.Now;

            ent.Entry(entityCategory).State = EntityState.Modified; //adds data
            ent.Entry(entityCategory).Property(x => x.createdBy).IsModified = false;
            ent.Entry(entityCategory).Property(x => x.createdBy).IsModified = false;

            ent.SaveChanges();

            return RedirectToAction("Index");
        }

        //for deleting record
        public ActionResult Delete(int id)
        {
            var data = ent.categorySetup.Where(x => x.categoryID == id).FirstOrDefault();
            if (data != null)
            {
                data.deletedBy = 1;
                data.deletedDate = DateTime.Now;
            }

            ent.Entry(data).State = EntityState.Modified;
            ent.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}