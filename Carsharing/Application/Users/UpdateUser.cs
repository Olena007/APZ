using Application.Common.Exeptions;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Users
{
    public class UpdateUser
    {
        public class UpdateUserCommand : IRequest
        {
            public Guid? UserId { get; set; }
            public string? UserName { get; set; }
            public string? UserSurname { get; set; }
            public string? UserRole { get; set; }
            public string? UserEmail { get; set; } = null!;
            public string? Password { get; set; } = null!;
            public int? Level { get; set; }
        }


        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
        {

            private readonly ICarsharingDbContext _context;

            public UpdateUserCommandHandler(ICarsharingDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Users
                    .FirstOrDefaultAsync(x => x.UserId == request.UserId);

                if (entity == null)
                    throw new NotFoundException(nameof(User), request.UserId);

                entity.UserName = request.UserName;
                entity.UserSurname = request.UserSurname;
                entity.UserRole = request.UserRole;
                entity.UserEmail = request.UserEmail;
                entity.Password = request.Password;
                entity.Level = request.Level;

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
