using AutoMapper;
using InventoryManagementSoftware.Database;
using InventoryManagementSoftware.Model.Requests;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class ShelfService : BaseCRUDService<Model.Shelf, Database.Shelf, ShelfInsertRequest, ShelfUpdateRequest, ShelfSearchObject>
        , IShelfService
    {
        public ShelfService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Shelf> Get(ShelfSearchObject search)
        {
            var list = _context.Shelves
                .Include(x => x.Department).ThenInclude(x => x.Inventory)
                .Include(x => x.ProductShelves)
                .AsQueryable();

            if (search?.DepartmentId != null)
                list = list.Where(x => x.DepartmentId == search.DepartmentId);
            if (!string.IsNullOrEmpty(search?.Name))
                list = list.Where(x => x.Name.StartsWith(search.Name));
            if (search?.RowNumber != null)
                list = list.Where(x => x.RowNumber == search.RowNumber);

            return _mapper.Map<List<Model.Shelf>>(list.ToList());
        }

        public override Model.Shelf Update(int id, ShelfUpdateRequest request)
        {
            var entity = _context.Shelves.Find(id);

            _mapper.Map(request, entity);
            foreach(var item in _context.ProductShelves.ToList())
            {
                _context.ProductShelves.Remove(item);
                _context.SaveChanges();
            }
            foreach(var item in request.Products)
            {
                _context.ProductShelves.Add(new ProductShelf
                {
                    ProductId = item.ProductId,
                    ShelfId = id,
                    Quantity = item.Quantity
                });
                _context.SaveChanges();
            }

            return _mapper.Map<Model.Shelf>(entity);
        }

    }
}
