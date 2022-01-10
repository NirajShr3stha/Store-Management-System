using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.SetupViewModel
{
    public class CategorySetupViewModel
    {
        public int categoryID { get; set; }
        public string categoryName { get; set; }
        public bool? Status { get; set; }
        public int? createdBy { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<int> updatedBy { get; set; }
        public Nullable<System.DateTime> updatedDate { get; set; }
        public Nullable<int> deletedBy { get; set; }
        public Nullable<System.DateTime> deletedDate { get; set; }
        public string imageName { get; set; }
        public string imagePath { get; set; }
        public string SetCategoryID { get; set; }

        public List <CategorySetupViewModel> CategorySetupViewModelList { get; set; }

        public CategorySetupViewModel()
        {
            CategorySetupViewModelList = new List<CategorySetupViewModel>();
        }

    }
}
