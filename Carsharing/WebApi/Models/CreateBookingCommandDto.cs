using Application.Common.Mappings;
using AutoMapper;
using static Application.Bookings.CreateBooking;

namespace WebApi.Models
{
    public class CreateBookingCommandDto: IMapWith<CreateBookingCommand>
    {
        public Guid? UserId { get; set; }
        public Guid? CarId { get; set; }
        public DateTime? StartBooking { get; set; }
        public DateTime? EndBooking { get; set; }
        public string? Area { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookingCommandDto, CreateBookingCommand>();
        }
    }
}
