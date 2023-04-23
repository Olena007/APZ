﻿using Application.Common.Exeptions;
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
    public class UpdateBooking
    {
        public class UpdateBookingCommand : IRequest
        {
            public Guid? BookingId { get; set; }
            public Guid? UserId { get; set; }
            public Guid? CarId { get; set; }
            public DateTime? StartBooking { get; set; }
            public DateTime? EndBooking { get; set; }
            public string? Area { get; set; }
        }
        public class UpdateBookingCommandHandler : IRequestHandler<UpdateBookingCommand>
        {

            private readonly ICarsharingDbContext _context;

            public UpdateBookingCommandHandler(ICarsharingDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateBookingCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Bookings
                    .FirstOrDefaultAsync(x => x.BookingId == request.BookingId);

                if (entity == null)
                    throw new NotFoundException(nameof(Booking), request.BookingId);

                entity.UserId = request.UserId;
                entity.CarId = request.CarId;
                entity.StartBooking = request.StartBooking;
                entity.EndBooking = request.EndBooking;
                entity.Area = request.Area;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
