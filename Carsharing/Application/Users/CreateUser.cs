using Application.Interfaces;
using BCrypt.Net;
using Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.Users
{
    public class CreateUser
    {
        public class CreateUserCommand : IRequest<Guid>
        {
            public string? UserName { get; set; }
            public string? UserSurname { get; set; }
            public string? UserRole { get; set; }
            public string? UserEmail { get; set; } = null!;
            public string? Password { get; set; } = null!;
            public int? Level { get; set; }
        }

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
        {
            private readonly ICarsharingDbContext _context;
            public CreateUserCommandHandler(ICarsharingDbContext context)
            {
                _context = context;
            }
            public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {
                var entity = new User
                {
                    UserId = Guid.NewGuid(),
                    UserName = request.UserName,
                    UserSurname = request.UserSurname,
                    UserRole = request.UserRole,
                    UserEmail = request.UserEmail,
                    Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                    Level = request.Level
                };

                await _context.Users.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return (Guid)entity.UserId;
            }
        }
    }
}
