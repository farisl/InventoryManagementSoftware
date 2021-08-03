using AutoMapper;
using InventoryManagementSoftware.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class BaseCRUDService<T, TDb, TInsert, TUpdate, TSearch> : BaseReadService<T, TDb, TSearch>
        , ICRUDService<T, TInsert, TUpdate, TSearch> where T : class where TDb : class where TInsert : class
        where TUpdate : class where TSearch : class
    {
        public BaseCRUDService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public virtual T Insert(TInsert request)
        {
            var set = _context.Set<TDb>();

            TDb entity = _mapper.Map<TDb>(request);

            set.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<T>(entity);
        }

        public virtual T Update(int id, TUpdate request)
        {
            var entity = _context.Set<TDb>().Find(id);

            _mapper.Map(request, entity);
            _context.SaveChanges();

            return _mapper.Map<T>(entity);
        }
    }
}
