using AutoMapper;
using InventoryManagementSoftware.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class BaseReadService<T, TDb, TSearch> : IReadService<T, TSearch> where T : class where TDb : class where TSearch : class
    {
        protected readonly IMSContext _context;
        protected readonly IMapper _mapper;

        public BaseReadService(IMSContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public virtual IEnumerable<T> Get(TSearch search)
        {
            var list = _context.Set<TDb>().ToList();

            return _mapper.Map<List<T>>(list);
        }

        public virtual T GetById(int id)
        {
            var entity = _context.Set<TDb>().Find(id);

            return _mapper.Map<T>(entity);
        }
    }
}
