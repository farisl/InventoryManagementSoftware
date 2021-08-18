using AutoMapper;
using InventoryManagementSoftware.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Services
{
    public class GenderService : BaseReadService<Model.Gender, Database.Gender, object>, IGenderService
    {
        public GenderService(IMSContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
