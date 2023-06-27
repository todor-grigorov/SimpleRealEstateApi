﻿using AutoMapper;
using SimpleRealEstateApi.Dto;
using SimpleRealEstateApi.Models;

namespace SimpleRealEstateApi.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}