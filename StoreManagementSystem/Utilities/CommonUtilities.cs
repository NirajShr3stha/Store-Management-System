using StoreManagementSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StoreManagementSystem.Utilities
{
    public class CommonUtilities
    {
        public static IEnumerable<SelectListItem> GetCategoryList()
        {
            using (SMSEntities ent = new SMSEntities())
            {
                return new SelectList(ent.categorySetup.Where(x => x.Status == true && 
                x.deletedDate == null).ToList(), "categoryID", "categoryName");
            }
        }

        public static IEnumerable<SelectListItem>GetItemListOfCategory()
        {
            return new SelectList(new[]
            {
                new {Value = "Electronic Devices", Text="Electronic Devices" },
                new { Value = "Health and Beauty", Text = "Health and Beauty" },
                new { Value = "Babies Toy", Text = "Babies Toy" },
                new { Value = "Groceries", Text = "Groceries" },
                new { Value = "Lifestyle", Text = "Lifestyle" },
                new { Value = "Sports", Text = "Sports" },
                new { Value = "Automotive", Text = "Automotive" }
            }, "Value", "Text");
        }

        public static IEnumerable<SelectListItem> GetVendorList()
        {
            using (SMSEntities ent = new SMSEntities())
            {
                return new SelectList(ent.vendorSetup.Where(x => x.deletedDate == null).ToList(),
                    "VendorId", "VName");

            }
        }

        public static IEnumerable<SelectListItem> GetItemListOfVendor()
        {
            return new SelectList(new[]
            {
                new {Value="Big-Marts", Text="Big-Marts"},
                new{Value="Big-Apple", Text="Big-Apple"},
                new{Value="Food-Mario", Text="Food-Mario"},
                new{Value="Big-Meats", Text="Big-Meats"}
            }, "Value", "Text");
        }

        public static IEnumerable<SelectListItem> GetCustomerList()
        {
            using (SMSEntities ent = new SMSEntities())
            {
                return new SelectList(ent.customerSetup.Where(x => x.deletedDate == null).ToList(),
                    "customerId", "customerName");
            }
        }

        public static IEnumerable<SelectListItem> GetItemListOfCustomer()
        {
            return new SelectList(new[]
            {
                new {Value="Mark", Text="Mark"},
                new{Value="Jordi", Text="Jordi"},
                new{Value="Louis", Text="Louis"}
            }, "Value", "Text");
        }
    }
}