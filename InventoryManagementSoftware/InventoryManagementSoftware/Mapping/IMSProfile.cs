using AutoMapper;
using InventoryManagementSoftware.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryManagementSoftware.Mapping
{
    public class IMSProfile : Profile
    {
        public IMSProfile()
        {
            CreateMap<Database.City, Model.City>();
            CreateMap<CityUpsertRequest, Database.City>();
        }
    }
}
