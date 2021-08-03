using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class CityUpsertRequest
    {
        [Required(ErrorMessage = "Name is a Required field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "CountryId is a Required field")]
        public int CountryId { get; set; }
    }
}
