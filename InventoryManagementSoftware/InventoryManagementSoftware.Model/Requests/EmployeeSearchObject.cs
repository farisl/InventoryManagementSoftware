using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class EmployeeSearchObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? InventoryId { get; set; }
    }
}
