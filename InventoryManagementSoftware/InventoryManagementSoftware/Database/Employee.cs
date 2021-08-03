using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class Employee
    {
        public Employee()
        {
            EmployeeInventories = new HashSet<EmployeeInventory>();
            EmployeeSalaries = new HashSet<EmployeeSalary>();
            Exports = new HashSet<Export>();
            Imports = new HashSet<Import>();
        }

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

        public virtual Address Address { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual IdentityUser<int> User { get; set; }
        public virtual ICollection<EmployeeInventory> EmployeeInventories { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
        public virtual ICollection<Export> Exports { get; set; }
        public virtual ICollection<Import> Imports { get; set; }
    }
}
