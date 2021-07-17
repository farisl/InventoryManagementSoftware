using AutoMapper;
using InventoryManagementSoftware.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class BaseCRUDService<T, TDb, TInsert, TUpdate, TSearch> : ICRUDService<T, TDb, TInsert, TUpdate, TSearch> where T : class where TDb : class
        where TInsert : class where TUpdate : class where TSearch : class
    {
        protected readonly IMSContext _context;
        protected readonly IMapper _mapper;

        public BaseCRUDService(IMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual IEnumerable<T> Get(TSearch search = null)
        {
            var list = _context.Set<TDb>().AsQueryable();

            if(search == null)
                return _mapper.Map<List<T>>(list.ToList());

            return _mapper.Map<IQueryable<T>>(list);
        }

        public T GetById(int id)
        {
            var entity = _context.Set<TDb>().Find(id);

            return _mapper.Map<T>(entity);
        }

        public T Insert(TInsert request)
        {
            var set = _context.Set<TDb>();

            TDb entity = _mapper.Map<TDb>(request);

            set.Add(entity);
            _context.SaveChanges();

            return _mapper.Map<T>(entity);
        }

        public T Update(int id, TUpdate request)
        {
            var entity = _context.Set<TDb>().Find(id);

            _mapper.Map(request, entity);
            _context.SaveChanges();

            return _mapper.Map<T>(entity);
        }
    }
}
