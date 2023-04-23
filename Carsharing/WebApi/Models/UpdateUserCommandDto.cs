using Application.Common.Mappings;
using AutoMapper;
using System.Text.Json.Serialization;
using static Application.Cars.UpdateCar;
using static Application.Users.UpdateUser;

namespace WebApi.Models
{
    public class UpdateUserCommandDto : IMapWith<UpdateUserCommand>
    {
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserSurname { get; set; }
        public string? UserRole { get; set; }
        public string? UserEmail { get; set; } = null!;
        public string? Password { get; set; } = null!;
        public int? Level { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserCommandDto, UpdateUserCommand>();
        }
    }
}
