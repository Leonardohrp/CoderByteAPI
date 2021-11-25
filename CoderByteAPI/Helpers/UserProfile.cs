using AutoMapper;
using CoderByteAPI.Dtos;
using CoderByteAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoderByteAPI.Helpers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
               .ForMember(
                   dest => dest.Age,
                   opt => opt.MapFrom(src => DateFunction.GetAgeFromDate(src.DateOfBirth))
               );

            CreateMap<User, UserUpdatedDto>()
               .ForMember(
                   dest => dest.Age,
                   opt => opt.MapFrom(src => DateFunction.GetAgeFromDate(src.DateOfBirth))
               );
        }
    }
}
