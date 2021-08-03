using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class UserRegistrationRequest
    {
        [Required(ErrorMessage = "Username is a Required field")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Email is a Required field")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
