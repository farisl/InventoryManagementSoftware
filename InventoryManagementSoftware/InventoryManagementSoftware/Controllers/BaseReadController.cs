using InventoryManagementSoftware.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BaseReadController<T, TSearch> : ControllerBase where T : class where TSearch : class
    {
        private readonly IReadService<T, TSearch> _service;

        public BaseReadController(IReadService<T, TSearch> service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<T> Get([FromQuery] TSearch search = null)
        {
            return _service.Get(search);
        }

        [HttpGet("{id}")]
        public T GetById(int id)
        {
            return _service.GetById(id);
        }
    }
}
