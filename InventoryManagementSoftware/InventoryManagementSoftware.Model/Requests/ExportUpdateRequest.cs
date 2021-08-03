﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class ExportUpdateRequest
    {
        [Required(ErrorMessage = "Date is a Required field")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int? InventoryId { get; set; }
        public int? CustomerId { get; set; }
    }
}
