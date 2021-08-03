using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public interface ICRUDService<T, TInsert, TUpdate, TSearch> : IReadService<T, TSearch> 
        where T : class where TInsert : class where TUpdate : class where TSearch : class
    {
        T Insert(TInsert request);
        T Update(int id, TUpdate request);
    }
}
