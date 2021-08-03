using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

#nullable disable

namespace InventoryManagementSoftware.Database
{
    public partial class IMSContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>,int>
    {
        public IMSContext()
        {
        }

        public IMSContext(DbContextOptions<IMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<CategoriesBrand> CategoriesBrands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<EmployeeInventory> EmployeeInventories { get; set; }
        public virtual DbSet<EmployeeSalary> EmployeeSalaries { get; set; }
        public virtual DbSet<Export> Exports { get; set; }
        public virtual DbSet<ExportDetail> ExportDetails { get; set; }
        public virtual DbSet<Gender> Genders { get; set; }
        public virtual DbSet<Import> Imports { get; set; }
        public virtual DbSet<ImportDetail> ImportDetails { get; set; }
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductAttribute> ProductAttributes { get; set; }
        public virtual DbSet<ProductPrice> ProductPrices { get; set; }
        public virtual DbSet<ProductShelf> ProductShelves { get; set; }
        public virtual DbSet<Shelf> Shelves { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<UserNotification> UserNotifications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=160321; User=sa; Password=test");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "Bosnian_Latin_100_BIN");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.CityId, "IX_Addresses_CityId");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId);
            });

            modelBuilder.Entity<CategoriesBrand>(entity =>
            {
                entity.HasIndex(e => e.BrandId, "IX_CategoriesBrands_BrandId");

                entity.HasIndex(e => e.CategoryId, "IX_CategoriesBrands_CategoryId");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.CategoriesBrands)
                    .HasForeignKey(d => d.BrandId);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.CategoriesBrands)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasIndex(e => e.CountryId, "IX_Cities_CountryId");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryId);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.AddressId, "IX_Customers_AddressId");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.PhoneNumber).IsRequired();

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.AddressId);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasIndex(e => e.InventoryId, "IX_Departments_InventoryId");

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Departments)
                    .HasForeignKey(d => d.InventoryId);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasIndex(e => e.AddressId, "IX_Employees_AddressId");

                entity.HasIndex(e => e.GenderId, "IX_Employees_GenderId");

                entity.Property(e => e.Jmbg).HasColumnName("JMBG");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.AddressId);

                entity.HasOne(d => d.Gender)
                    .WithMany(p => p.Employees)
                    .HasForeignKey(d => d.GenderId);

                //entity.HasOne(d => d.IdentityUser)
                //    .WithMany(p => p.Employees)
                //    .HasForeignKey(d => d.IdentityUserId);
            });

            modelBuilder.Entity<EmployeeInventory>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId, "IX_EmployeeInventories_EmployeeId");

                entity.HasIndex(e => e.InventoryId, "IX_EmployeeInventories_InventoryId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeInventories)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.EmployeeInventories)
                    .HasForeignKey(d => d.InventoryId);
            });

            modelBuilder.Entity<EmployeeSalary>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId, "IX_EmployeeSalaries_EmployeeId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeSalaries)
                    .HasForeignKey(d => d.EmployeeId);
            });

            modelBuilder.Entity<Export>(entity =>
            {
                entity.HasIndex(e => e.CustomerId, "IX_Exports_CustomerId");

                entity.HasIndex(e => e.EmployeeId, "IX_Exports_EmployeeId");

                entity.HasIndex(e => e.InventoryId, "IX_Exports_InventoryId");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Exports)
                    .HasForeignKey(d => d.CustomerId);

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Exports)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Exports)
                    .HasForeignKey(d => d.InventoryId);
            });

            modelBuilder.Entity<ExportDetail>(entity =>
            {
                entity.HasIndex(e => e.ExportId, "IX_ExportDetails_ExportId");

                entity.HasIndex(e => e.ProductId, "IX_ExportDetails_ProductId");

                entity.HasOne(d => d.Export)
                    .WithMany(p => p.ExportDetails)
                    .HasForeignKey(d => d.ExportId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ExportDetails)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Import>(entity =>
            {
                entity.HasIndex(e => e.EmployeeId, "IX_Imports_EmployeeId");

                entity.HasIndex(e => e.InventoryId, "IX_Imports_InventoryId");

                entity.HasIndex(e => e.SupplierId, "IX_Imports_SupplierId");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Imports)
                    .HasForeignKey(d => d.EmployeeId);

                entity.HasOne(d => d.Inventory)
                    .WithMany(p => p.Imports)
                    .HasForeignKey(d => d.InventoryId);

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Imports)
                    .HasForeignKey(d => d.SupplierId);
            });

            modelBuilder.Entity<ImportDetail>(entity =>
            {
                entity.HasIndex(e => e.ImportId, "IX_ImportDetails_ImportId");

                entity.HasIndex(e => e.ProductId, "IX_ImportDetails_ProductId");

                entity.HasOne(d => d.Import)
                    .WithMany(p => p.ImportDetails)
                    .HasForeignKey(d => d.ImportId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ImportDetails)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<Inventory>(entity =>
            {
                entity.HasIndex(e => e.AddressId, "IX_Inventories_AddressId");

                entity.Property(e => e.PhoneNumber).IsRequired();

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Inventories)
                    .HasForeignKey(d => d.AddressId);
            });

            //modelBuilder.Entity<Notification>(entity =>
            //{
            //    entity.HasOne(d => d.IdentityUser)
            //        .WithMany(p => p.Notifications)
            //        .HasForeignKey(d => d.IdentityUserId);
            //});


            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.CategoryBrandId, "IX_Products_CategoryBrandId");

                entity.HasOne(d => d.CategoryBrand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryBrandId);
            });

            modelBuilder.Entity<ProductAttribute>(entity =>
            {
                entity.HasIndex(e => e.AttributeId, "IX_ProductAttributes_AttributeId");

                entity.HasIndex(e => e.ProductId, "IX_ProductAttributes_ProductId");

                entity.HasOne(d => d.Attribute)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(d => d.AttributeId);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductAttributes)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<ProductPrice>(entity =>
            {
                entity.HasIndex(e => e.ProductId, "IX_ProductPrices_ProductId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPrices)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<ProductShelf>(entity =>
            {
                entity.HasIndex(e => e.ProductId, "IX_ProductShelves_ProductId");

                entity.HasIndex(e => e.ShelfId, "IX_ProductShelves_ShelfId");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductShelves)
                    .HasForeignKey(d => d.ProductId);

                entity.HasOne(d => d.Shelf)
                    .WithMany(p => p.ProductShelves)
                    .HasForeignKey(d => d.ShelfId);
            });

            modelBuilder.Entity<Shelf>(entity =>
            {
                entity.HasIndex(e => e.DepartmentId, "IX_Shelves_DepartmentId");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Shelves)
                    .HasForeignKey(d => d.DepartmentId);
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.HasIndex(e => e.AddressId, "IX_Suppliers_AddressId");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.PhoneNumber).IsRequired();

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.AddressId);
            });

            //modelBuilder.Entity<UserNotification>(entity =>
            //{
            //    entity.HasIndex(e => e.NotificationId, "IX_UserNotifications_NotificationId");

            //    entity.HasOne(d => d.IdentityUser)
            //        .WithMany(p => p.UserNotifications)
            //        .HasForeignKey(d => d.IdentityUserId)
            //        .OnDelete(DeleteBehavior.ClientSetNull);

            //    entity.HasOne(d => d.Notification)
            //        .WithMany(p => p.UserNotifications)
            //        .HasForeignKey(d => d.NotificationId);
            //});

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
