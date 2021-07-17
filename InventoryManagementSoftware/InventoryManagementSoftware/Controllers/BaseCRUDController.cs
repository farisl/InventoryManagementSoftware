using InventoryManagementSoftware.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BaseCRUDController<T, TDb, TInsert, TUpdate, TSearch> : ControllerBase where T : class where TDb : class where TInsert : class
        where TUpdate : class where TSearch : class
    {
        private readonly ICRUDService<T, TDb, TInsert, TUpdate, TSearch> _service;

        public BaseCRUDController(ICRUDService<T, TDb, TInsert, TUpdate, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<T> Get([FromQuery]TSearch search = null)
        {
            return _service.Get(search);
        }

        [HttpGet("{id}")]
        public T GetById(int id)
        {
            return _service.GetById(id);
        }

        [HttpPost]
        public T Insert([FromQuery]TInsert request)
        {
            return _service.Insert(request);
        }

        [HttpPut("{id}")]
        public T Update(int id, TUpdate request)
        {
            return _service.Update(id, request);
        }
    }
}
