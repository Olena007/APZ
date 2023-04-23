using Application.Common.Mappings;
using AutoMapper;
using static Application.Bookings.UpdateBooking;

namespace WebApi.Models
{
    public class UpdateBookingCommandDto: IMapWith<UpdateBookingCommand>
    {
        public Guid? BookingId { get; set; }
        public Guid? UserId { get; set; }
        public Guid? CarId { get; set; }
        public DateTime? StartBooking { get; set; }
        public DateTime? EndBooking { get; set; }
        public string? Area { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBookingCommandDto, UpdateBookingCommand>();
        }
    }
}
