using SMS.Core.SetupViewModel;
using StoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManagementSystem.Controllers.SetupController
{
    public class CustomerSetupController : Controller
    {
        // GET: CustomerSetup
        SMSEntities ent = new SMSEntities();
        public ActionResult Index()
        {
            CustomerSetupViewModel model = new CustomerSetupViewModel();
            model.CustomerSetupViewModelList = (from i in ent.customerSetup
                                                where i.deletedDate == null
                                                select new CustomerSetupViewModel
                                              {
                                                  customerId = i.customerId,
                                                  cName = i.cName,
                                                  State = i.State,
                                                  District = i.District,
                                                  cMunicipality = i.cMunicipality,
                                                  cWard = i.cWard,
                                                  cContact = i.cContact,
                                                  cEmail = i.cEmail,
                                                  cWeb = i.cWeb,
                                                  createdBy = i.createdBy,
                                                    createdDate = i.createdDate,   
                                                    updatedBy = i.updatedBy,
                                                    updatedDate = i.updatedDate,
                                                    deletedBy = i.deletedBy,
                                                    deletedDate = i.deletedDate,
                                              }).ToList();

            return View(model);
        }

        public ActionResult _SearchCustomer(string cName)
        {
            CustomerSetupViewModel model = new CustomerSetupViewModel();
            model.CustomerSetupViewModelList = (from i in ent.customerSetup
                                                where i.deletedDate == null
                                                select new CustomerSetupViewModel
                                                {
                                                    customerId = i.customerId,
                                                    cName = i.cName,
                                                    State = i.State,
                                                    District = i.District,
                                                    cMunicipality = i.cMunicipality,
                                                    cWard = i.cWard,
                                                    cContact = i.cContact,
                                                    cEmail = i.cEmail,
                                                    cWeb = i.cWeb,
                                                    createdBy = i.createdBy,
                                                    createdDate = i.createdDate,
                                                    updatedBy = i.updatedBy,
                                                    updatedDate = i.updatedDate,
                                                    deletedBy = i.deletedBy,
                                                    deletedDate = i.deletedDate,
                                                }).ToList();

            if (!String.IsNullOrEmpty(cName))
            {
                model.CustomerSetupViewModelList = model.CustomerSetupViewModelList
                    .Where(x => x.cName.ToLower()
                    .Contains(cName.ToLower())).ToList();
            }

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CustomerSetupViewModel model)
        {
            SMSEntities ent = new SMSEntities();    //connection string name
            customerSetup entityCustomer = new customerSetup(); //take name

            entityCustomer.cName = model.cName;
            entityCustomer.State = model.State;
            entityCustomer.District = model.District;
            entityCustomer.cMunicipality = model.cMunicipality;
            entityCustomer.cWard = model.cWard;
            entityCustomer.cContact = model.cContact;
            entityCustomer.cEmail = model.cEmail;
            entityCustomer.cWeb = model.cWeb;
            entityCustomer.createdBy = 1;
            entityCustomer.createdDate = DateTime.Now;

            ent.Entry(entityCustomer).State = EntityState.Added; //adds data
            ent.SaveChanges();

            return RedirectToAction("Index"); //redirects to index page onclick "create-btn" in views
        }

        //for editing records
        public ActionResult Edit(int id)
        {
            customerSetup model = new customerSetup();

            var data = ent.customerSetup.Where(x => x.customerId == id).FirstOrDefault();
            if (data != null)
            {
                model.customerId = data.customerId;
                model.cName = data.cName;
                model.State = data.State;
                model.District = data.District;
                model.cMunicipality = data.cMunicipality;
                model.cWard = data.cWard;
                model.cContact = data.cContact;
                model.cEmail = data.cEmail;
                model.cWeb = data.cWeb;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CustomerSetupViewModel model)
        {
            customerSetup entityCustomer = new customerSetup(); //take name
            entityCustomer.customerId = model.customerId;
            entityCustomer.cName = model.cName;
            entityCustomer.State = model.State;
            entityCustomer.District = model.District;
            entityCustomer.cMunicipality = model.cMunicipality;
            entityCustomer.cWard = model.cWard;
            entityCustomer.cContact = model.cContact;
            entityCustomer.cEmail = model.cEmail;
            entityCustomer.cWeb = model.cWeb;
            entityCustomer.updatedBy = 1;
            entityCustomer.updatedDate = DateTime.Now;

            ent.Entry(entityCustomer).State = EntityState.Modified; //adds data
            ent.Entry(entityCustomer).Property(x => x.createdBy).IsModified = false;
            ent.Entry(entityCustomer).Property(x => x.createdBy).IsModified = false;
            ent.SaveChanges();

            return RedirectToAction("Index");

        }

        //for deleting record
        public ActionResult Delete(int id)
        {
            var data = ent.customerSetup.Where(x => x.customerId == id).FirstOrDefault();
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