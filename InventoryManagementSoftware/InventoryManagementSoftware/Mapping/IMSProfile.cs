using AutoMapper;
using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Mapping
{
    public class IMSProfile : Profile
    {
        public IMSProfile()
        {
            CreateMap<Database.City, Model.City>();
            CreateMap<CityUpsertRequest, Database.City>();

            CreateMap<Database.Country, Model.Country>();

            CreateMap<Database.Brand, Model.Brand>();
            CreateMap<BrandUpsertRequest, Database.Brand>();

            CreateMap<Database.Category, Model.Category>();
            CreateMap<BaseUpsertRequest, Database.Category>();
            
            CreateMap<Database.Customer, Model.Customer>();
            CreateMap<CustomerUpsertRequest, Database.Customer>();

            CreateMap<Database.Supplier, Model.Supplier>();
            CreateMap<SupplierUpsertRequest, Database.Supplier>();

            CreateMap<Database.Department, Model.Department>();
            CreateMap<DepartmentUpsertRequest, Database.Department>();
            
            CreateMap<Database.Inventory, Model.Inventory>();
            CreateMap<InventoryUpsertRequest, Database.Inventory>();

            CreateMap<Database.Export, Model.Export>();
            CreateMap<ExportInsertRequest, Database.Export>();
            CreateMap<ExportUpdateRequest, Database.Export>();

            CreateMap<Database.ExportDetail, Model.ExportDetail>();
            CreateMap<ExportDetailInsertRequest, Database.ExportDetail>();
            CreateMap<ExportDetailUpdateRequest, Database.ExportDetail>();

            CreateMap<Database.Employee, Model.Employee>();
            CreateMap<EmployeeInsertRequest, Database.Employee>();
            CreateMap<EmployeeUpdateRequest, Database.Employee>();

            CreateMap<Database.Product, Model.Product>();
            CreateMap<ProductUpsertRequest, Database.Product>();

            CreateMap<Database.Import, Model.Import>();
            CreateMap<ImportInsertRequest, Database.Import>();
            CreateMap<ImportUpdateRequest, Database.Import>();

            CreateMap<Database.Shelf, Model.Shelf>();
            CreateMap<ShelfInsertRequest, Database.Shelf>();
            CreateMap<ShelfUpdateRequest, Database.Shelf>();

            CreateMap<Database.CategoriesBrand, Model.CategoriesBrand>();

            CreateMap<Database.Address, Model.Address>();

            CreateMap<Database.ProductShelf, Model.ProductShelf>();
            CreateMap<ProductShelfUpsertRequest, Database.ProductShelf>();

            CreateMap<Database.EmployeeInventory, Model.EmployeeInventory>();

            CreateMap<Database.Gender, Model.Gender>();

            CreateMap<Database.EmployeeSalary, Model.EmployeeSalary>();

            CreateMap<Database.Attribute, Model.Attribute>();

            CreateMap<Database.ProductAttribute, Model.ProductAttribute>();
            CreateMap<ProductAttributeUpsertRequest, Database.ProductAttribute>();
        }
    }
}
