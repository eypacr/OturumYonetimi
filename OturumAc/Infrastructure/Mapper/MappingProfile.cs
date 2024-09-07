using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;

namespace OturumAc.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDtoForCreation, IdentityUser>();
            CreateMap<UserDtoForUpdate, IdentityUser>().ReverseMap();
        }
    }
}