using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public virtual ICollection<EmployeeInventory> EmployeeInventories { get; set; }
        public virtual ICollection<EmployeeSalary> EmployeeSalaries { get; set; }
        public virtual Address Address { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual IdentityUser<int> User { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public string Username => User?.UserName;
        public int? CityId => Address?.CityId;
        public string AddressName => Address?.Name;
        public string City => Address?.City?.Name;
        public Inventory ActiveInventory => EmployeeInventories?.Where(x => x.EmployeeId == Id && x.EndDate == null)
            .FirstOrDefault()?.Inventory;
        public string Inventory => EmployeeInventories?.Where(x => x.EmployeeId == Id && x.EndDate == null)
            .FirstOrDefault()?.Inventory?.Name;
        public string GenderName => GenderId == 1 ? "M" : "F";
        public DateTime? HireDate => EmployeeInventories?.Where(x => x.EmployeeId == Id && x.EndDate == null)
            .FirstOrDefault()?.HireDate;
        public double? Salary => EmployeeSalaries?.Where(x => x.EmployeeId == Id && x.EndDate == null)
            .FirstOrDefault()?.Value;
    }
}
