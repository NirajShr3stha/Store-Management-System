using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Core.SetupViewModel
{
    public class CustomerSetupViewModel
    {
        public int customerId { get; set; }
        public string cName { get; set; }
        public string State { get; set; }
        public string District { get; set; }
        public string cMunicipality { get; set; }
        public Nullable<int> cWard { get; set; }
        public string cContact { get; set; }
        public string cEmail { get; set; }
        public string cWeb { get; set; }
        public Nullable<int> createdBy { get; set; }
        public Nullable<System.DateTime> createdDate { get; set; }
        public Nullable<int> updatedBy { get; set; }
        public Nullable<System.DateTime> updatedDate { get; set; }
        public Nullable<int> deletedBy { get; set; }
        public Nullable<System.DateTime> deletedDate { get; set; }

        public List<CustomerSetupViewModel> CustomerSetupViewModelList { get; set; }
        public CustomerSetupViewModel()
        {
            CustomerSetupViewModelList = new List<CustomerSetupViewModel>();
        }
    }
}
