using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class InventoryUpsertRequest
    {
        [Required(ErrorMessage = "Name is a Required field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "AdressName is a Required field")]
        public string AddressName { get; set; }
        [Required(ErrorMessage = "CityId is a Required field")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "PhoneNumber is a Required field")]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Size is a Required field")]
        [Range(0,10000)]
        public float Size { get; set; }
    }
}
