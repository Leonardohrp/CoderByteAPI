using AutoMapper;
using CoderByteAPI.Dtos;
using CoderByteAPI.Models;
using CoderByteAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Helpers
{
    public class AddressProfile : Profile
    {
        public AddressProfile()
        {
            CreateMap<Address, AddressDto>()
               .ForMember(
                   dest => dest.Categoria,
                   opt => opt.MapFrom(src => Enum.GetName(typeof(CategoryEnum), src.Categoria))
               );
        }
    }
}
