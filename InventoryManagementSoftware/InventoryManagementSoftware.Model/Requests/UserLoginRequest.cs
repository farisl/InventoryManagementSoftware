using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace InventoryManagementSoftware.Model.Requests
{
    public class UserLoginRequest
    {
        [Required(ErrorMessage = "Username is a Required field")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is a Required field")]
        public string Password { get; set; }
    }
}
