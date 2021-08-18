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
    public class ProductAttributeService : BaseCRUDService<Model.ProductAttribute, Database.ProductAttribute, ProductAttributeUpsertRequest, ProductAttributeUpsertRequest, ProductAttributeSearchObject>
        , IProductAttributeService
    {
        public ProductAttributeService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.ProductAttribute> Get(ProductAttributeSearchObject search)
        {
            var list = _context.ProductAttributes
                .Include(x => x.Attribute)
                .AsQueryable();

            if (search?.ProductId != null)
                list = list.Where(x => x.ProductId == search.ProductId);

            return _mapper.Map<List<Model.ProductAttribute>>(list.ToList());
        }

        public override Model.ProductAttribute Insert(ProductAttributeUpsertRequest request)
        {
            Database.Attribute attribute = new Database.Attribute { Name = request.AttributeName };
            _context.Attributes.Add(attribute);
            _context.SaveChanges();

            Database.ProductAttribute productAttribute = new ProductAttribute
            {
                AttributeId = attribute.Id,
                ProductId = request.ProductId,
                Value = request.Value
            };
            _context.ProductAttributes.Add(productAttribute);
            _context.SaveChanges();

            return _mapper.Map<Model.ProductAttribute>(productAttribute);
        }

        public IEnumerable<Model.ProductAttribute> Delete(int id)
        {
            var entity = _context.ProductAttributes.Find(id);

            _context.ProductAttributes.Remove(entity);
            _context.SaveChanges();

            var list = _context.ProductAttributes.ToList();
            return _mapper.Map<List<Model.ProductAttribute>>(list);
        }
    }
}
