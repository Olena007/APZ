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

namespace Application.Cars
{
    public class UpdateCar
    {
        public class UpdateCarCommand : IRequest
        {
            public Guid? CarId { get; set; }
            public string? Brand { get; set; }
            public string? Model { get; set; }
            public string? LicensePlate { get; set; }
            public int? YearOfIssue { get; set; }
            public bool? IsAvailable { get; set; }
            public string? Image { get; set; }
            public int? Level { get; set; }
        }
        public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand>
        {

            private readonly ICarsharingDbContext _context;

            public UpdateCarCommandHandler(ICarsharingDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Cars
                    .FirstOrDefaultAsync(x => x.CarId == request.CarId);

                if (entity == null)
                    throw new NotFoundException(nameof(Car), request.CarId);

                entity.Brand = request.Brand;
                entity.Model = request.Model;
                entity.LicensePlate = request.LicensePlate;
                entity.YearOfIssue = request.YearOfIssue;
                entity.IsAvailable = request.IsAvailable;
                entity.Image = request.Image;
                entity.Level = request.Level;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
