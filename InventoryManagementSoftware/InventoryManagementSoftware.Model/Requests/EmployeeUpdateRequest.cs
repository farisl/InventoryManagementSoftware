﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class EmployeeUpdateRequest
    {
        [Required(ErrorMessage = "First Name is a Required field")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is a Required field")]
        public string LastName { get; set; }
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

        public bool? Active { get; set; }
        public int? InventoryId { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-mm-dd}", ApplyFormatInEditMode = true)]
        public DateTime? HireDate { get; set; } = null;
        [Range(0, 10000)]
        public double? Salary { get; set; }
        public int GenderId { get; set; }
        public DateTime BirthDate { get; set; }
        public string Jmbg { get; set; }
    }
}
