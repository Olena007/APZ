using Application.Common.Exeptions;
using Application.Common.Mappings;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Bookings
{
    public class GetBooking
    {
        public class BookingVm : IMapWith<Booking>
        {
            public Guid? BookingId { get; set; }
            public DateTime? StartBooking { get; set; }
            public DateTime? EndBooking { get; set; }
            public string? Area { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Booking, BookingVm>();
            }
        }

        public class GetBookingQuery : IRequest<BookingVm>
        {
            public Guid BookingId { get; set; }
        }
        public class GetBookingQueryHandler : IRequestHandler<GetBookingQuery, BookingVm>
        {

            private readonly ICarsharingDbContext _context;
            private readonly IMapper _mapper;

            public GetBookingQueryHandler(ICarsharingDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<BookingVm> Handle(GetBookingQuery request, CancellationToken cancellationToken)
            {
                var entity = await _context.Bookings
                    .Include(x => x.Cars)
                    .Include(x => x.Users)
                    .FirstOrDefaultAsync(x => x.BookingId == request.BookingId);

                if (entity == null)
                    throw new NotFoundException(nameof(Booking), request.BookingId);

                return _mapper.Map<BookingVm>(entity);
            }
        }
    }
}
