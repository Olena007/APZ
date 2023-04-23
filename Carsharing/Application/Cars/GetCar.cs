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

namespace Application.Cars
{
    public class GetCar
    {
        public class CarVm : IMapWith<Car>
        {
            public Guid? CarId { get; set; }
            public string? Brand { get; set; }
            public string? Model { get; set; }
            public string? LicensePlate { get; set; }
            public int? YearOfIssue { get; set; }
            public bool? IsAvailable { get; set; }
            public string? Image { get; set; }
            public int? Level { get; set; }
            public ICollection<Booking> Bookings { get; set; }

            public void Mapping(Profile profile)
            {
                profile.CreateMap<Car, CarVm>();
            }
        }

        public class GetCarQuery : IRequest<CarVm>
        {
            public Guid CarId { get; set; }
        }
        public class GetCarQueryHandler : IRequestHandler<GetCarQuery, CarVm>
        {

            private readonly ICarsharingDbContext _context;
            private readonly IMapper _mapper;

            public GetCarQueryHandler(ICarsharingDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<CarVm> Handle(GetCarQuery request, CancellationToken cancellationToken)
            {
                var entity = await _context.Cars
                    .Include(x => x.Bookings)
                    .FirstOrDefaultAsync(x => x.CarId == request.CarId);

                if (entity == null)
                    throw new NotFoundException(nameof(Car), request.CarId);

                return _mapper.Map<CarVm>(entity);
            }
        }
    }
}
