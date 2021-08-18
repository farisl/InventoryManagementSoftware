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
    public class ProductShelfService : BaseCRUDService<Model.ProductShelf, Database.ProductShelf, ProductShelfUpsertRequest, ProductShelfUpsertRequest, ProductShelfSearchObject>
        , IProductShelfService
    {
        public ProductShelfService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
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
