using AutoMapper;
using InventoryManagementSoftware.Controllers;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model.Requests;
using InventoryManagementSoftware.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class EmployeeService : BaseCRUDService<Model.Employee, Database.Employee, EmployeeInsertRequest, EmployeeUpdateRequest, EmployeeSearchObject>
        , IEmployeeService
    {
        private readonly IAuthManagementService _authManagementService;

        public EmployeeService(IMSContext context, IMapper mapper, IAuthManagementService authManagementService) : base(context, mapper)
        {
            _authManagementService = authManagementService;
        }

        public override IEnumerable<Model.Employee> Get(EmployeeSearchObject search)
        {
            var list = _context.Employees.AsQueryable();

            if (!string.IsNullOrEmpty(search?.FirstName))
                list = list.Where(x => x.FirstName.StartsWith(search.FirstName));
            if (!string.IsNullOrEmpty(search?.LastName))
                list = list.Where(x => x.LastName.StartsWith(search.LastName));
            if(search?.InventoryId != null)
            {
                List<int> employeeIds = new List<int>();
                foreach (var item in _context.EmployeeInventories.Where(x => x.InventoryId == search.InventoryId && x.EndDate == null)
                    .ToList())
                {
                    employeeIds.Add(item.EmployeeId);
                }
                if (employeeIds.Count == 0)
                    return new List<Model.Employee>();
                list = list.Where(x => employeeIds.Contains(x.Id));               
            }

            return _mapper.Map<List<Model.Employee>>(list.ToList());
        }

        public override Model.Employee Insert(EmployeeInsertRequest request)
        {
            var entity = _mapper.Map<Database.Employee>(request);

            Address address = new Address
            {
                Name = request.AddressName,
                CityId = request.CityId
            };
            _context.Addresses.Add(address);
            _context.SaveChanges();

            entity.AddressId = address.Id;
            entity.IsDeleted = false;
            entity.CreatedDate = DateTime.Now;

            var newUser = new UserRegistrationRequest
            {
                Email = (request.FirstName + request.LastName.Substring(0, 1)).ToLower() + "@ims.ba",
                Username = (request.FirstName + request.LastName.Substring(0, 1)).ToLower()
            };
            entity.UserId = _authManagementService.Register(newUser).Result.Id;
            _context.Employees.Add(entity);
            _context.SaveChanges();

            if(request.InventoryId != null)
            {
                EmployeeInventory employeeInventory = new EmployeeInventory
                {
                    EmployeeId = entity.Id,
                    InventoryId = (int)request.InventoryId,
                    HireDate = (DateTime)request.HireDate,
                    EndDate = null
                };
                _context.EmployeeInventories.Add(employeeInventory);
                _context.SaveChanges();
            }

            if(request.Salary != null)
            {
                _context.EmployeeSalaries.Add(new EmployeeSalary
                {
                    EmployeeId = entity.Id,
                    Value = (double)request.Salary,
                    StartDate = DateTime.Now,
                    EndDate = null
                });
                _context.SaveChanges();
            }

            return _mapper.Map<Model.Employee>(entity);
        }

        public override Model.Employee Update(int id, EmployeeUpdateRequest request)
        {
            var entity = _context.Employees.Include(x => x.Address).FirstOrDefault(x => x.Id == id);

            _mapper.Map(request, entity);
            entity.Address.Name = request.AddressName;
            entity.Address.CityId = request.CityId;

            var employeeInventory = _context.EmployeeInventories.FirstOrDefault(x => x.EmployeeId == id && x.EndDate == null);
            if (request.InventoryId != null)
            {
                if(employeeInventory == null)
                {
                    _context.EmployeeInventories.Add(new EmployeeInventory
                    {
                        EmployeeId = id,
                        InventoryId = (int)request.InventoryId,
                        HireDate = (DateTime)request.HireDate
                    });
                    _context.SaveChanges();
                }
                else if(employeeInventory.InventoryId != request.InventoryId)
                {
                    employeeInventory.EndDate = DateTime.Now;
                    _context.EmployeeInventories.Add(new EmployeeInventory
                    {
                        EmployeeId = id,
                        InventoryId = (int)request.InventoryId,
                        HireDate = DateTime.Now
                    });
                    _context.SaveChanges();
                }
            }
            else if (request.InventoryId == null && employeeInventory != null)
            {
                employeeInventory.EndDate = DateTime.Now;
                _context.SaveChanges();
            }

            if (request.Salary != null)
            {
                var employeeSalary = _context.EmployeeSalaries.FirstOrDefault(x => x.EmployeeId == id && x.EndDate == null);
                if(employeeSalary == null)
                {
                    _context.EmployeeSalaries.Add(new EmployeeSalary
                    {
                        EmployeeId = id,
                        Value = (double)request.Salary,
                        StartDate = DateTime.Now,
                        EndDate = null
                    });
                    _context.SaveChanges();
                }
                else if(employeeSalary.Value != request.Salary)
                {
                    employeeSalary.EndDate = DateTime.Now;
                    _context.EmployeeSalaries.Add(new EmployeeSalary
                    {
                        EmployeeId = id,
                        Value = (double)request.Salary,
                        StartDate = DateTime.Now,
                        EndDate = null
                    });
                    _context.SaveChanges();
                }
            }

            return _mapper.Map<Model.Employee>(entity);
        }

    }
}
