using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public interface ICRUDService<T, TDb, TInsert, TUpdate, TSearch> where T : class where TDb : class where TInsert : class
        where TUpdate : class where TSearch : class
    {
        IEnumerable<T> Get(TSearch search = null);
        T GetById(int id);
        T Insert(TInsert request);
        T Update(int id, TUpdate request);
    }
}
