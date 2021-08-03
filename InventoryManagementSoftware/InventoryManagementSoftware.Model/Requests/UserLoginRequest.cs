using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class UserLoginRequest
    {
        [Required(ErrorMessage = "Email is a Required field")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is a Required field")]
        public string Password { get; set; }
    }
}
