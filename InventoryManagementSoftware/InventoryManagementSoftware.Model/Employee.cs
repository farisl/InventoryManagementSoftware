using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagementSoftware.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public string Jmbg { get; set; }
        public DateTime BirthDate { get; set; }
        public int AddressId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int UserId { get; set; }
    }
}
