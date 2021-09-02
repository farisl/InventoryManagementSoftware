using AutoMapper;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class ProductShelfService : BaseCRUDService<Model.ProductShelf, Database.ProductShelf, ProductShelfUpsertRequest, ProductShelfUpsertRequest, ProductShelfSearchObject>
        , IProductShelfService
    {
        private readonly INotificationService _notificationService;

        public ProductShelfService(IMSContext context, IMapper mapper, INotificationService notificationService) : base(context, mapper)
        {
            _notificationService = notificationService;
        }        

        public override IEnumerable<Model.ProductShelf> Get(ProductShelfSearchObject search)
        {
            var list = _context.ProductShelves
                .Include(x => x.Product)
                .AsQueryable();

            if (search?.ShelfId != null)
                list = list.Where(x => x.ShelfId == search.ShelfId);
            if (search?.ProductId != null)
                list = list.Where(x => x.ProductId == search.ProductId);

            return _mapper.Map<List<Model.ProductShelf>>(list.ToList());
        }

        public override Model.ProductShelf Insert(ProductShelfUpsertRequest request)
        {
            var result = base.Insert(request);

            var productName = _context.Products.Find(result.ProductId).Name;

            int inventoryId = _context.Shelves.Include(x => x.Department).Where(x => x.Id == result.ShelfId).First()
                .Department.InventoryId;
            var userIds = _context.EmployeeInventories.Where(x => x.InventoryId == inventoryId)
                .Select(x => x.Employee.UserId).ToList();
            var notification =_notificationService.Insert(new NotificationInsertRequest
            {
                DateTime = DateTime.Now,
                Text = $"New product added to your inventory - ({productName})",
                UserId = AuthManagementService.UserId,
                UserIds = userIds
            });

            return result;
        }

        public IEnumerable<Model.ProductShelf> Delete(int id)
        {
            var entity = _context.ProductShelves.Find(id);

            _context.ProductShelves.Remove(entity);
            _context.SaveChanges();

            var list = _context.ProductShelves.ToList();
            return _mapper.Map<List<Model.ProductShelf>>(list);
        }

    }
}
