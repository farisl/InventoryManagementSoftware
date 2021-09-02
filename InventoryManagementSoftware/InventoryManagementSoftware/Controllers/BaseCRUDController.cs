using InventoryManagementSoftware.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Controllers
{
    public class BaseCRUDController<T, TDb, TInsert, TUpdate, TSearch> : BaseReadController<T, TSearch> 
        where T : class where TDb : class where TInsert : class
        where TUpdate : class where TSearch : class
    {
        protected readonly ICRUDService<T, TInsert, TUpdate, TSearch> _crudService;

        public BaseCRUDController(ICRUDService<T, TInsert, TUpdate, TSearch> service) : base(service)
        {
            _crudService = service;
        }

        [HttpPost]
        public T Insert([FromQuery]TInsert request)
        {
            return _crudService.Insert(request);
        }

        [HttpPut("{id}")]
        virtual public T Update(int id, TUpdate request)
        {
            return _crudService.Update(id, request);
        }
    }
}
