using AutoMapper;
using Practicum.Core.DTOs;
using Practicum.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practicum.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {            
            CreateMap<Product, ProductDto>().ReverseMap();            
        }
    }
}
