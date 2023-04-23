using Application.Common.Exeptions;
using Application.Interfaces;
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
    public class DeleteBooking
    {
        public class DeleteBookingCommand : IRequest
        {
            public Guid Id { get; set; }
        }

        public class DeleteBookingCommandHandler : IRequestHandler<DeleteBookingCommand>
        {

            private readonly ICarsharingDbContext _context;

            public DeleteBookingCommandHandler(ICarsharingDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteBookingCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Bookings
                    .FirstOrDefaultAsync(x => x.BookingId == request.Id);

                if (entity == null)
                    throw new NotFoundException(nameof(Booking), request.Id);

                _context.Bookings.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
