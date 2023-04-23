﻿using Application.Common.Mappings;
using AutoMapper;
using static Application.Cars.CreateCar;

namespace WebApi.Models
{
    public class CreateCarCommandDto: IMapWith<CreateCarCommand>
    {
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public string? LicensePlate { get; set; }
        public int? YearOfIssue { get; set; }
        public bool? IsAvailable { get; set; }
        public string? Image { get; set; }
        public int? Level { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCarCommandDto, CreateCarCommand>();
        }
    }
}
