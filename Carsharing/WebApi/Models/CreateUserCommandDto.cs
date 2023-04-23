﻿using Application.Common.Mappings;
using AutoMapper;
using static Application.Users.CreateUser;

namespace WebApi.Models
{
    public class CreateUserCommandDto: IMapWith<CreateUserCommand>
    {
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public string? UserRole { get; set; }
        public string? UserEmail { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public int? Level { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserCommandDto, CreateUserCommand>();
        }
    }
}
