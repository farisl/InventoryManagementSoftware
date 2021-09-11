using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Database
{
    public partial class IMSContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            //Countries
            modelBuilder.Entity<Country>().HasData(new Country
            {
                Id = 1,
                Name = "Florida"
            },
            new Country
            {
                Id = 2,
                Name = "New Jersey"
            },
            new Country
            {
                Id = 3,
                Name = "Montana"
            },
            new Country
            {
                Id = 4,
                Name = "Texas"
            });
            
            //Cities
            modelBuilder.Entity<City>().HasData(new City
            {
                Id = 1,
                Name = "Miami",
                CountryId = 1
            },
            new City
            {
                Id = 2,
                Name = "Edison",
                CountryId = 2
            },
            new City
            {
                Id = 3,
                Name = "Austin",
                CountryId = 4
            },
            new City
            {
                Id = 4,
                Name = "Hackensack",
                CountryId = 2
            },
            new City
            {
                Id = 5,
                Name = "Helena",
                CountryId = 3
            },
            new City
            {
                Id = 6,
                Name = "Jacksonville",
                CountryId = 1
            },
            new City
            {
                Id = 7,
                Name = "Hico",
                CountryId = 4
            });

            //Addresses
            modelBuilder.Entity<Address>().HasData(new Address
            {
                Id = 1,
                CityId = 1,
                Name = "8457 Northwest 66th Street"
            },
            new Address
            {
                Id = 2,
                CityId = 2,
                Name = "2541 Highway 516 Old Bridge"
            },
            new Address
            {
                Id = 3,
                CityId = 3,
                Name = "1305 W Oltorf St # 300"
            },
            new Address
            {
                Id = 4,
                CityId = 4,
                Name = "3 University Plaza Dr #400"
            },
            new Address
            {
                Id = 5,
                CityId = 5,
                Name = "630 N Montana Ave"
            },
            new Address
            {
                Id = 6,
                CityId = 6,
                Name = "2500 Monument Rd"
            },
            new Address
            {
                Id = 7,
                CityId = 7,
                Name = "1645 Beeghley Street"
            });

            //Suppliers
            modelBuilder.Entity<Supplier>().HasData(new Supplier
            {
                Id = 1,
                Name = "Foremostco, Inc.",
                Email = "info@foremostco.com",
                PhoneNumber = "305.592.8986", 
                AddressId = 1
            },
            new Supplier
            {
                Id = 2,
                Name = "FSg Worldwide",
                Email = "sgworldwideinc@gmail.com",
                PhoneNumber = "+1 732-500-6268",
                AddressId = 2
            });
            
            //Customers
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = 1,
                Name = "Artisanal Imports",
                Email = "info@artisanalimports.com",
                PhoneNumber = "+1 512-440-0811",
                AddressId = 3
            },
            new Customer
            {
                Id = 2,
                Name = "Sg Companies",
                Email = "reach.out@thesgcompanies.com",
                PhoneNumber = "1-201-342-1200",
                AddressId = 4
            });

            //Categories
            modelBuilder.Entity<Category>().HasData(new Category
            {
                Id = 1,
                Name = "Plants",                
            },
            new Category
            {
                Id = 2,
                Name = "Beverage",
            },
            new Category
            {
                Id = 3,
                Name = "Clothes",
            });
            
            //Brands
            modelBuilder.Entity<Brand>().HasData(new Brand
            {
                Id = 1,
                Name = "Leaf & Clay",         
            },
            new Brand
            {
                Id = 2,
                Name = "Rampur",         
            },
            new Brand
            {
                Id = 3,
                Name = "Dakota Fleece",         
            },
            new Brand
            {
                Id = 4,
                Name = "Merrell",         
            },
            new Brand
            {
                Id = 5,
                Name = "Beam Suntory",         
            });
            
            //CategoriyBrands
            modelBuilder.Entity<CategoriesBrand>().HasData(new CategoriesBrand
            {
                Id = 1,
                CategoryId = 1,     
                BrandId = 1     
            },
            new CategoriesBrand
            {
                Id = 2,
                CategoryId = 2,     
                BrandId = 2     
            },
            new CategoriesBrand
            {
                Id = 3,
                CategoryId = 3,     
                BrandId = 3     
            },
            new CategoriesBrand
            {
                Id = 4,
                CategoryId = 3,     
                BrandId = 4     
            },
            new CategoriesBrand
            {
                Id = 5,
                CategoryId = 2,     
                BrandId = 5     
            });

            //Inventories
            modelBuilder.Entity<Inventory>().HasData(new Inventory
            {
                Id = 1,
                Name = "Helena - MT",
                AddressId = 5,
                PhoneNumber = "+1406-555-0451",
                Size = 150
            },
            new Inventory
            {
                Id = 2,
                Name = "Jacksonville - FL",
                AddressId = 6,
                PhoneNumber = "+1904-555-0506",
                Size = 200
            });

            //Departments
            modelBuilder.Entity<Department>().HasData(new Department
            {
                Id = 1,
                Name = "Food & beverages",
                InventoryId = 1,
                Size = 40
            },
            new Department
            {
                Id = 2,
                Name = "Plants and plant products",
                InventoryId = 1,
                Size = 26
            },
            new Department
            {
                Id = 3,
                Name = "Food & beverages",
                InventoryId = 2,
                Size = 66
            },
            new Department
            {
                Id = 4,
                Name = "Clothes & shoes",
                InventoryId = 2,
                Size = 41
            });

            //Shelves
            modelBuilder.Entity<Shelf>().HasData(new Shelf
            {
                Id = 1,
                DepartmentId = 1,
                Name = "001",
                RowNumber = 1
            },
            new Shelf
            {
                Id = 2,
                DepartmentId = 1,
                Name = "002",
                RowNumber = 2
            },
            new Shelf
            {
                Id = 3,
                DepartmentId = 2,
                Name = "001",
                RowNumber = 1
            },
            new Shelf
            {
                Id = 4,
                DepartmentId = 3,
                Name = "001",
                RowNumber = 1
            },
            new Shelf
            {
                Id = 5,
                DepartmentId = 3,
                Name = "002",
                RowNumber = 2
            },
            new Shelf
            {
                Id = 6,
                DepartmentId = 4,
                Name = "001",
                RowNumber = 1
            },
            new Shelf
            {
                Id = 7,
                DepartmentId = 4,
                Name = "002",
                RowNumber = 2
            },
            new Shelf
            {
                Id = 8,
                DepartmentId = 4,
                Name = "003",
                RowNumber = 3
            });

            //Products
            modelBuilder.Entity<Product>().HasData(new Product
            {
                Id = 1,
                Name = "Alpinia zerumbet",
                Description = "Variegated ginger",
                IsDeleted = false,
                CategoryBrandId = 1
            },
            new Product
            {
                Id = 2,
                Name = "Aphelandra",
                Description = "Squarrosa dania",
                IsDeleted = false,
                CategoryBrandId = 1
            },
            new Product
            {
                Id = 3,
                Name = "Rampur Select",
                Description = "Indian single malt whisky",
                IsDeleted = false,
                CategoryBrandId = 2
            },
            new Product
            {
                Id = 4,
                Name = "Double Cask",
                Description = "Indian single malt whisky",
                IsDeleted = false,
                CategoryBrandId = 2
            },
            new Product
            {
                Id = 5,
                Name = "Men's jackett",
                Description = "Men's Deluxe Solar Full Zip Fleece Jacket",
                IsDeleted = false,
                CategoryBrandId = 3
            },
            new Product
            {
                Id = 6,
                Name = "Women's hiking shoes",
                Description = "Women's Alverstone Vent Breathable Suede Leather Hiking Shoes - Taupe",
                IsDeleted = false,
                CategoryBrandId = 4
            },
            new Product
            {
                Id = 7,
                Name = "Roku",
                Description = "Premium Japanese craft gin",
                IsDeleted = false,
                CategoryBrandId = 5
            },
            new Product
            {
                Id = 8,
                Name = "Cruzan",
                Description = "Rum from the island of St. Croix",
                IsDeleted = false,
                CategoryBrandId = 5
            });

            //ProductPrices
            modelBuilder.Entity<ProductPrice>().HasData(new ProductPrice
            {
                Id = 1,
                ProductId = 1,
                StartDate = new DateTime(2021, 7, 6),
                EndDate = null,
                IsDeleted = false,
                Price = 44
            },
            new ProductPrice
            {
                Id = 2,
                ProductId = 2,
                StartDate = new DateTime(2021, 7, 12),
                EndDate = null,
                IsDeleted = false,
                Price = 15
            },
            new ProductPrice
            {
                Id = 3,
                ProductId = 3,
                StartDate = new DateTime(2021, 7, 12),
                EndDate = null,
                IsDeleted = false,
                Price = 58.95
            },
            new ProductPrice
            {
                Id = 4,
                ProductId = 4,
                StartDate = new DateTime(2021, 6, 20),
                EndDate = null,
                IsDeleted = false,
                Price = 90
            },
            new ProductPrice
            {
                Id = 5,
                ProductId = 5,
                StartDate = new DateTime(2021, 8, 15),
                EndDate = null,
                IsDeleted = false,
                Price = 54.99
            },
            new ProductPrice
            {
                Id = 6,
                ProductId = 6,
                StartDate = new DateTime(2021, 9, 2),
                EndDate = null,
                IsDeleted = false,
                Price = 129.99
            },
            new ProductPrice
            {
                Id = 7,
                ProductId = 7,
                StartDate = new DateTime(2021, 9, 2),
                EndDate = null,
                IsDeleted = false,
                Price = 25
            },
            new ProductPrice
            {
                Id = 8,
                ProductId = 8,
                StartDate = new DateTime(2021, 9, 3),
                EndDate = null,
                IsDeleted = false,
                Price = 15
            });

            //ProductShelves
            modelBuilder.Entity<ProductShelf>().HasData(new ProductShelf
            {
                Id = 1,
                ShelfId = 1,
                ProductId = 3,
                Quantity = 20
            },
            new ProductShelf
            {
                Id = 2,
                ShelfId = 1,
                ProductId = 4,
                Quantity = 15
            },
            new ProductShelf
            {
                Id = 3,
                ShelfId = 3,
                ProductId = 1,
                Quantity = 2
            },
            new ProductShelf
            {
                Id = 4,
                ShelfId = 4,
                ProductId = 7,
                Quantity = 12
            },
            new ProductShelf
            {
                Id = 5,
                ShelfId = 5,
                ProductId = 7,
                Quantity = 8
            },
            new ProductShelf
            {
                Id = 6,
                ShelfId = 5,
                ProductId = 8,
                Quantity = 10
            },
            new ProductShelf
            {
                Id = 7,
                ShelfId = 7,
                ProductId = 5,
                Quantity = 1
            },
            new ProductShelf
            {
                Id = 8,
                ShelfId = 8,
                ProductId = 6,
                Quantity = 3
            });

            //Users
            modelBuilder.Entity<IdentityUser<int>>().HasData(new IdentityUser<int>
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@ims.com",
                NormalizedEmail = "ADMIN@IMS.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEJUkMFSXrboURChAEJiqUu1pLXzvH61yPUTqsdQk0P+6c4XkL24mAg4uTtrs2BdHsA==",
                SecurityStamp = "d3a50ebf-5215-4039-9e5e-134405f033a6",
                ConcurrencyStamp = "f8761f6c-a02d-4e48-81da-95585f418954",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            },
            new IdentityUser<int>
            {
                Id = 2,
                UserName = "deenal",
                NormalizedUserName = "DEENAL",
                Email = "deenal@ims.com",
                NormalizedEmail = "DEENAL@IMS.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEJUkMFSXrboURChAEJiqUu1pLXzvH61yPUTqsdQk0P+6c4XkL24mAg4uTtrs2BdHsA==",
                SecurityStamp = "d3a50ebf-5215-4039-9e5e-134405f033a6",
                ConcurrencyStamp = "f8761f6c-a02d-4e48-81da-95585f418954",
                PhoneNumberConfirmed = false,
                TwoFactorEnabled = false,
                LockoutEnabled = true,
                AccessFailedCount = 0
            });

            //Roles
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int>
            {
                Id = 1,
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR",
                ConcurrencyStamp = "1954fd8e-8fe0-48e9-836c-2cdcccf89ef0"
            },
            new IdentityRole<int>
            {
                Id = 2,
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = "31d72aba-bc66-414c-979b-ed57c9a247b0"
            });

            //UserRoles
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = 1
            },
            new IdentityUserRole<int>
            {
                RoleId = 2,
                UserId = 2
            });

            //Genders
            modelBuilder.Entity<Gender>().HasData(new Gender
            {
                Id = 1,
                Name = "Male"
            },
            new Gender
            {
                Id = 2,
                Name = "Female"
            });

            //Employees
            modelBuilder.Entity<Employee>().HasData(new Employee
            {
                Id = 1,
                FirstName = "Deena",
                LastName = "Lavender",
                GenderId = 2,
                Jmbg = "4532522654414",
                BirthDate = new DateTime(1977, 8, 18),
                Email = "deena.lavender@yahoo.com",
                AddressId = 7,
                PhoneNumber = "254-796-6013",
                Active = true,
                IsDeleted = false,
                CreatedDate = new DateTime(2021, 6, 30),
                ModifiedDate = null,
                UserId = 2
            });

            //EmployeeSalaries
            modelBuilder.Entity<EmployeeSalary>().HasData(new EmployeeSalary
            {
                Id = 1,
                EmployeeId = 1,
                Value = 740,
                StartDate = new DateTime(2021, 6, 30),
                EndDate = null
            });

            //EmployeeInventories
            modelBuilder.Entity<EmployeeInventory>().HasData(new EmployeeInventory
            {
                Id = 1,
                EmployeeId = 1,
                InventoryId = 1,
                HireDate = new DateTime(2021, 7, 2),
                EndDate = null
            });

            //Imports
            modelBuilder.Entity<Import>().HasData(new Import
            {
                Id = 1,
                EmployeeId = 1,
                InventoryId = 1,
                SupplierId = 2,
                Date = new DateTime(2021, 8, 30)
            },
            new Import
            {
                Id = 2,
                EmployeeId = 1,
                InventoryId = 1,
                SupplierId = 1,
                Date = new DateTime(2021, 9, 4)
            });

            //ImportDetails
            modelBuilder.Entity<ImportDetail>().HasData(new ImportDetail
            {
                Id = 1,
                ImportId = 1,
                ProductId = 3,
                Quantity = 7,
                Discount = 0.3,
                Price = 288.86
            },
            new ImportDetail
            {
                Id = 2,
                ImportId = 1,
                ProductId = 4,
                Quantity = 5,
                Discount = 0,
                Price = 400
            },
            new ImportDetail
            {
                Id = 3,
                ImportId = 1,
                ProductId = 8,
                Quantity = 6,
                Discount = 0,
                Price = 90
            },
            new ImportDetail
            {
                Id = 4,
                ImportId = 2,
                ProductId = 1,
                Quantity = 2,
                Discount = 0.5,
                Price = 44
            },
            new ImportDetail
            {
                Id = 5,
                ImportId = 2,
                ProductId = 2,
                Quantity = 3,
                Discount = 0,
                Price = 15
            });

            //Exports
            modelBuilder.Entity<Export>().HasData(new Export
            {
                Id = 1,
                EmployeeId = 1,
                InventoryId = 1,
                CustomerId = 1,
                Date = new DateTime(2021, 9, 1)
            });

            //ExportDetails
            modelBuilder.Entity<ExportDetail>().HasData(new ExportDetail
            {
                Id = 1,
                ExportId = 1,
                ProductId = 3,
                Quantity = 5,
                Discount = 0.2,
                Price = 235.8
            },
            new ExportDetail
            {
                Id = 2,
                ExportId = 1,
                ProductId = 5,
                Quantity = 1,
                Discount = 0.0,
                Price = 54.99
            },
            new ExportDetail
            {
                Id = 3,
                ExportId = 1,
                ProductId = 6,
                Quantity = 1,
                Discount = 0.4,
                Price = 77.99
            });

        }
    }
}
