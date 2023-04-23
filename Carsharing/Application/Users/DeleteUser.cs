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

namespace Application.Users
{
    public class DeleteUser
    {
        public class DeleteUserCommand : IRequest
        {
            public Guid Id { get; set; }
        }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
        {

            private readonly ICarsharingDbContext _context;

            public DeleteUserCommandHandler(ICarsharingDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Users
                    .FirstOrDefaultAsync(x => x.UserId == request.Id);

                if (entity == null)
                    throw new NotFoundException(nameof(User), request.Id);

                _context.Users.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }
}
