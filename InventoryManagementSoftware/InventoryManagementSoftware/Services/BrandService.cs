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
    public class BrandService : BaseCRUDService<Model.Brand, Database.Brand, BrandUpsertRequest, BrandUpsertRequest, BrandSearchObject>
        , IBrandService
    {
        public BrandService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public override IEnumerable<Model.Brand> Get(BrandSearchObject search)
        {
            var list = _context.Brands.AsQueryable();

            if (!string.IsNullOrEmpty(search?.Name))
                list = list.Where(x => x.Name.StartsWith(search.Name));

            var categoriesBrand = _context.CategoriesBrands.ToList();
            List<int> brandIds = new List<int>();
            foreach(var categoryId in search?.CategoryIds)
            {
                brandIds.AddRange(categoriesBrand.Where(x => x.CategoryId == categoryId).Select(x => x.BrandId));
            }
            if (brandIds.Count > 0)
                list = list.Where(x => brandIds.Contains(x.Id));

            if (search?.CategoryIds.Count > 0 && brandIds.Count == 0)
                return new List<Model.Brand>();

            var result = _mapper.Map<List<Model.Brand>>(list.ToList());
            foreach(var item in result)
            {
                item.Categories = string.Join(", ", _context.Categories
                    .Where(x => item.CategoriesBrands.Select(y => y.CategoryId).Contains(x.Id))
                    .Select(x => x.Name).ToList());
            }

            return result;
        }

        public override Model.Brand Insert(BrandUpsertRequest request)
        {
            Database.Brand entity = new Brand
            {
                Name = request.Name
            };

            _context.Brands.Add(entity);
            _context.SaveChanges();

            foreach(var id in request.CategoryIds)
            {
                CategoriesBrand categoriesBrand = new CategoriesBrand
                {
                    BrandId = entity.Id,
                    CategoryId = id
                };
                _context.CategoriesBrands.Add(categoriesBrand);
                _context.SaveChanges();
            }

            return _mapper.Map<Model.Brand>(entity);
        }

        public override Model.Brand Update(int id, BrandUpsertRequest request)
        {
            var entity = _context.Brands.Find(id);

            entity.Name = request.Name;
            _context.SaveChanges();

            List<CategoriesBrand> categoriesBrands = _context.CategoriesBrands.Where(x => x.BrandId == id).ToList();
            _context.CategoriesBrands.RemoveRange(categoriesBrands);
            _context.SaveChanges();

            foreach (var item in request.CategoryIds)
            {
                CategoriesBrand categoriesBrand = new CategoriesBrand
                {
                    BrandId = entity.Id,
                    CategoryId = item
                };
                _context.CategoriesBrands.Add(categoriesBrand);
                _context.SaveChanges();
            }

            return _mapper.Map<Model.Brand>(entity);
        }

    }
}
