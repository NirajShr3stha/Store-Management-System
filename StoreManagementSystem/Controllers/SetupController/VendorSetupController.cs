using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using SMS.Core.SetupViewModel;
using StoreManagementSystem.Entities;

namespace StoreManagementSystem.Controllers.SetupController
{
    public class VendorSetupController : Controller
    {
        // GET: VendorSetup
        SMSEntities ent = new SMSEntities();
        public ActionResult Index()
        {
            VendorSetupViewModel model = new VendorSetupViewModel();
            model.VendorSetupViewModelList = (from i in ent.vendorSetup
                                                where i.deletedDate == null
                                                select new VendorSetupViewModel
                                                {
                                                    VendorId = i.VendorId,
                                                    VName = i.VName,
                                                    State = i.State,
                                                    District = i.District,
                                                    VMunicipality = i.VMunicipality,
                                                    VWard = i.VWard,
                                                    VContact = i.VContact,
                                                    VEmail = i.VEmail,
                                                    VWeb = i.VWeb,
                                                    createdBy = i.createdBy,
                                                    createdDate = i.createdDate,
                                                    updatedBy = i.updatedBy,
                                                    updatedDate = i.updatedDate,
                                                    deletedBy = i.deletedBy,
                                                    deletedDate = i.deletedDate,
                                                }).ToList();

            return View(model);
        }

        public ActionResult _SearchVendor(string VName)
        {
            VendorSetupViewModel model = new VendorSetupViewModel();
            model.VendorSetupViewModelList = (from i in ent.vendorSetup
                                              where i.deletedDate == null
                                              select new VendorSetupViewModel
                                              {
                                                  VendorId = i.VendorId,
                                                  VName = i.VName,
                                                  State = i.State,
                                                  District = i.District,
                                                  VMunicipality = i.VMunicipality,
                                                  VWard = i.VWard,
                                                  VContact = i.VContact,
                                                  VEmail = i.VEmail,
                                                  VWeb = i.VWeb,
                                                  createdBy = i.createdBy,
                                                  createdDate = i.createdDate,
                                                  updatedBy = i.updatedBy,
                                                  updatedDate = i.updatedDate,
                                                  deletedBy = i.deletedBy,
                                                  deletedDate = i.deletedDate,
                                              }).ToList();
            if (!String.IsNullOrEmpty(VName))
            {
                model.VendorSetupViewModelList = model.VendorSetupViewModelList
                    .Where(x => x.VName.ToLower()
                    .Contains(VName.ToLower())).ToList();
            }

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VendorSetupViewModel model)
        {
            SMSEntities ent = new SMSEntities();    //connection string name
            vendorSetup entityVendor = new vendorSetup(); //take name

            entityVendor.VName = model.VName;
            entityVendor.State = model.State;
            entityVendor.District = model.District;
            entityVendor.VMunicipality = model.VMunicipality;
            entityVendor.VWard = model.VWard;
            entityVendor.VContact = model.VContact;
            entityVendor.VEmail = model.VEmail;
            entityVendor.VWeb = model.VWeb;
            entityVendor.createdBy = 1;
            entityVendor.createdDate = DateTime.Now;

            ent.Entry(entityVendor).State = EntityState.Added; //adds data
            ent.SaveChanges();

            return RedirectToAction("Index"); //redirects to index page onclick "create-btn" in views
        }

        //for editing records
        public ActionResult Edit(int id)
        {
            vendorSetup model = new vendorSetup();
           
            var data = ent.vendorSetup.Where(x => x.VendorId == id).FirstOrDefault();
            if (data != null)
            {
                model.VendorId = data.VendorId;
                model.VName = data.VName;
                model.State = data.State;
                model.District = data.District;
                model.VMunicipality = data.VMunicipality;
                model.VWard = data.VWard;
                model.VContact = data.VContact;
                model.VEmail = data.VEmail;
                model.VWeb = data.VWeb;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(VendorSetupViewModel model)
        {
            vendorSetup entityVendor = new vendorSetup(); //take name
            entityVendor.VendorId = model.VendorId;
            entityVendor.VName = model.VName;
            entityVendor.State = model.State;
            entityVendor.District = model.District;
            entityVendor.VMunicipality = model.VMunicipality;
            entityVendor.VWard = model.VWard;
            entityVendor.VContact = model.VContact;
            entityVendor.VEmail = model.VEmail;
            entityVendor.VWeb = model.VWeb;
            entityVendor.updatedBy = 1;
            entityVendor.updatedDate = DateTime.Now;

            ent.Entry(entityVendor).State = EntityState.Modified; //adds data
            ent.Entry(entityVendor).Property(x => x.createdBy).IsModified = false;
            ent.Entry(entityVendor).Property(x => x.createdBy).IsModified = false;
            ent.SaveChanges();

            return RedirectToAction("Index");
        }

        //for deleting record
        public ActionResult Delete(int id)
        {
            var data = ent.vendorSetup.Where(x => x.VendorId == id).FirstOrDefault();
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