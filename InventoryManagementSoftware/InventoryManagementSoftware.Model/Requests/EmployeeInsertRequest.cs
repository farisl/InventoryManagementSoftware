using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class EmployeeInsertRequest
    {
        [Required(ErrorMessage ="First Name is a Required field")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is a Required field")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "GenderId is a Required field")]
        [Range(1,2, ErrorMessage ="GenderId can only contain values '1' or '2'")]
        public int GenderId { get; set; }
        [Required(ErrorMessage = "Jmbg is a Required field")]
        [MinLength(13, ErrorMessage = "Jmbg must be 13 characters long")]
        [MaxLength(13, ErrorMessage = "Jmbg must be 13 characters long")]
        public string Jmbg { get; set; }
        [Required(ErrorMessage = "BirthDate is a Required field")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "AddressName is a Required field")]
        public string AddressName { get; set; }
        [Required(ErrorMessage = "CityId is a Required field")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "Email is a Required field")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "PhoneNumber is a Required field")]
        [Phone]
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
        public int? InventoryId { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime? HireDate { get; set; } = null;
        [Range(0, 10000)]
        public double? Salary { get; set; }


    }
}
