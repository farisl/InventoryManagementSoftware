using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class ExportSearchObject
    {
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateFrom { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DateTo { get; set; }
        public int? EmployeeId { get; set; }
    }
}
