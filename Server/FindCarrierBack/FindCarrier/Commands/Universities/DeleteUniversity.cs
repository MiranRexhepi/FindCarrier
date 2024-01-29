using FindCarrier.Domain;
using FluentValidation;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FindCarrier.Commands.Universities
{
    public class DeleteUniversity
    {
        public class Command : IRequest<bool>
        {
            public int Id { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }

        public class CommandHandler : IRequestHandler<Command, bool>
        {
            private readonly CarrierDbContext _context;
            public CommandHandler(CarrierDbContext context)
            {
                _context = context;
            }

            public async Task<bool> Handle(Command request, CancellationToken cancellationToken)
            {
                var existingUniversity = await _context.University
                    .Where(x => x.Id == request.Id)
                    .SingleOrDefaultAsync(cancellationToken);

                if (existingUniversity == null || existingUniversity.IsDeleted)
                    return false;

                existingUniversity.IsDeleted = true;

                var deleteUniversity = await _context.SaveChangesAsync(cancellationToken);
                return deleteUniversity > 0;
            }
        }
    }
}