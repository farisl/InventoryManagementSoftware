using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventoryManagementSoftware.Migrations
{
    public partial class Data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 2, "31d72aba-bc66-414c-979b-ed57c9a247b0", "User", "USER" },
                    { 1, "1954fd8e-8fe0-48e9-836c-2cdcccf89ef0", "Administrator", "ADMINISTRATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 2, 0, "f8761f6c-a02d-4e48-81da-95585f418954", "deenal@ims.com", true, true, null, "DEENAL@IMS.COM", "DEENAL", "AQAAAAEAACcQAAAAEJUkMFSXrboURChAEJiqUu1pLXzvH61yPUTqsdQk0P+6c4XkL24mAg4uTtrs2BdHsA==", null, false, "d3a50ebf-5215-4039-9e5e-134405f033a6", false, "deenal" },
                    { 1, 0, "f8761f6c-a02d-4e48-81da-95585f418954", "admin@ims.com", true, true, null, "ADMIN@IMS.COM", "ADMIN", "AQAAAAEAACcQAAAAEJUkMFSXrboURChAEJiqUu1pLXzvH61yPUTqsdQk0P+6c4XkL24mAg4uTtrs2BdHsA==", null, false, "d3a50ebf-5215-4039-9e5e-134405f033a6", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Leaf & Clay" },
                    { 4, "Merrell" },
                    { 3, "Dakota Fleece" },
                    { 2, "Rampur" },
                    { 5, "Beam Suntory" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Plants" },
                    { 2, "Beverage" },
                    { 3, "Clothes" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 2, "New Jersey" },
                    { 3, "Montana" },
                    { 4, "Texas" },
                    { 1, "Florida" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Male" },
                    { 2, "Female" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "CategoriesBrands",
                columns: new[] { "Id", "BrandId", "CategoryId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 2 },
                    { 5, 5, 2 },
                    { 3, 3, 3 },
                    { 4, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CountryId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Miami" },
                    { 6, 1, "Jacksonville" },
                    { 2, 2, "Edison" },
                    { 4, 2, "Hackensack" },
                    { 5, 3, "Helena" },
                    { 3, 4, "Austin" },
                    { 7, 4, "Hico" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "CityId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "8457 Northwest 66th Street" },
                    { 6, 6, "2500 Monument Rd" },
                    { 2, 2, "2541 Highway 516 Old Bridge" },
                    { 4, 4, "3 University Plaza Dr #400" },
                    { 5, 5, "630 N Montana Ave" },
                    { 3, 3, "1305 W Oltorf St # 300" },
                    { 7, 7, "1645 Beeghley Street" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryBrandId", "Description", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Variegated ginger", false, "Alpinia zerumbet" },
                    { 2, 1, "Squarrosa dania", false, "Aphelandra" },
                    { 3, 2, "Indian single malt whisky", false, "Rampur Select" },
                    { 4, 2, "Indian single malt whisky", false, "Double Cask" },
                    { 7, 5, "Premium Japanese craft gin", false, "Roku" },
                    { 8, 5, "Rum from the island of St. Croix", false, "Cruzan" },
                    { 5, 3, "Men's Deluxe Solar Full Zip Fleece Jacket", false, "Men's jackett" },
                    { 6, 4, "Women's Alverstone Vent Breathable Suede Leather Hiking Shoes - Taupe", false, "Women's hiking shoes" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "AddressId", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 2, 4, "reach.out@thesgcompanies.com", "Sg Companies", "1-201-342-1200" },
                    { 1, 3, "info@artisanalimports.com", "Artisanal Imports", "+1 512-440-0811" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Active", "AddressId", "BirthDate", "CreatedDate", "Email", "FirstName", "GenderId", "IsDeleted", "JMBG", "LastName", "ModifiedDate", "PhoneNumber", "UserId" },
                values: new object[] { 1, true, 7, new DateTime(1977, 8, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Deena", 2, false, "4532522654414", "Lavender", null, "254-796-6013", 2 });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "Id", "AddressId", "Name", "PhoneNumber", "Size" },
                values: new object[,]
                {
                    { 2, 6, null, "+1904-555-0506", 200f },
                    { 1, 5, null, "+1406-555-0451", 150f }
                });

            migrationBuilder.InsertData(
                table: "ProductPrices",
                columns: new[] { "Id", "EndDate", "IsDeleted", "Price", "ProductId", "StartDate" },
                values: new object[,]
                {
                    { 1, null, false, 44.0, 1, new DateTime(2021, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, false, 15.0, 2, new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, false, 58.950000000000003, 3, new DateTime(2021, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, false, 90.0, 4, new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, null, false, 25.0, 7, new DateTime(2021, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, null, false, 15.0, 8, new DateTime(2021, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, null, false, 54.990000000000002, 5, new DateTime(2021, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, null, false, 129.99000000000001, 6, new DateTime(2021, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "Id", "AddressId", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, 1, "info@foremostco.com", "Foremostco, Inc.", "305.592.8986" },
                    { 2, 2, "sgworldwideinc@gmail.com", "FSg Worldwide", "+1 732-500-6268" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "InventoryId", "Name", "Size" },
                values: new object[,]
                {
                    { 3, 2, "Food & beverages", 66f },
                    { 4, 2, "Clothes & shoes", 41f },
                    { 1, 1, "Food & beverages", 40f },
                    { 2, 1, "Plants and plant products", 26f }
                });

            migrationBuilder.InsertData(
                table: "EmployeeInventories",
                columns: new[] { "Id", "EmployeeId", "EndDate", "HireDate", "InventoryId" },
                values: new object[] { 1, 1, null, new DateTime(2021, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "EmployeeSalaries",
                columns: new[] { "Id", "EmployeeId", "EndDate", "StartDate", "Value" },
                values: new object[] { 1, 1, null, new DateTime(2021, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 740.0 });

            migrationBuilder.InsertData(
                table: "Shelves",
                columns: new[] { "Id", "DepartmentId", "Name", "RowNumber" },
                values: new object[,]
                {
                    { 4, 3, "001", 1 },
                    { 5, 3, "002", 2 },
                    { 6, 4, "001", 1 },
                    { 7, 4, "002", 2 },
                    { 8, 4, "003", 3 },
                    { 1, 1, "001", 1 },
                    { 2, 1, "002", 2 },
                    { 3, 2, "001", 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductShelves",
                columns: new[] { "Id", "ProductId", "Quantity", "ShelfId" },
                values: new object[,]
                {
                    { 4, 7, 12.0, 4 },
                    { 5, 7, 8.0, 5 },
                    { 6, 8, 10.0, 5 },
                    { 7, 5, 1.0, 7 },
                    { 8, 6, 3.0, 8 },
                    { 1, 3, 20.0, 1 },
                    { 2, 4, 15.0, 1 },
                    { 3, 1, 2.0, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeInventories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeSalaries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductPrices",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ProductShelves",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductShelves",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductShelves",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductShelves",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductShelves",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ProductShelves",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ProductShelves",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductShelves",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Suppliers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Shelves",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoriesBrands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CategoriesBrands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CategoriesBrands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "CategoriesBrands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CategoriesBrands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inventories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
