using AutoMapper;
using Microsoft.AspNetCore.Identity;
using backend.DTOs;
using backend.Models;

namespace backend.Utilities
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ApplicationUser, UserDTO>();

            CreateMap<UserCredentialsDTO, ApplicationUser>();

            CreateProjection<ApplicationUser, UserLoginDTO>();
        }
    }
}
