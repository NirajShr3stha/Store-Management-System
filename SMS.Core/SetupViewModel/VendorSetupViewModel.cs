using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.SetupViewModel
{
    public class VendorSetupViewModel
    {
        public int VendorId { get; set; }
        public string VName { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string VMunicipality { get; set; }
        public Nullable<int> VWard { get; set; }
        public string VContact { get; set; }
        public string VEmail { get; set; }
        public string VWeb { get; set; }
        public Nullable<int> createdBy { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<int> updatedBy { get; set; }
        public Nullable<System.DateTime> updatedDate { get; set; }
        public Nullable<int> deletedBy { get; set; }
        public Nullable<System.DateTime> deletedDate { get; set; }

        public List<VendorSetupViewModel> VendorSetupViewModelList { get; set; }
        public VendorSetupViewModel()
        {
            VendorSetupViewModelList = new List<VendorSetupViewModel>();
        }
    }
}
