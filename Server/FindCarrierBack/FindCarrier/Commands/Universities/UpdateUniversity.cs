using FindCarrier.Domain;
using FindCarrier.HttpRequests;
using FindCarrier.Validators;
using FluentValidation;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace FindCarrier.Commands.Universities
{
    public class UpdateUniversity
    {
        public class Command : IRequest<bool>
        {
            public int Id { get; set; }
            public AddOrCreateUniversityRequest University { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.University).SetValidator(new AddOrCreateUniversityRequestValidator());
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
                    .FirstOrDefaultAsync(x => x.Id == request.Id && !x.IsDeleted, cancellationToken);

                if (existingUniversity == null)
                    return false;

                existingUniversity.Name = request.University.Name;
                existingUniversity.Location  = request.University.Location;
                existingUniversity.Field = request.University.Field;
                existingUniversity.SchoolType = request.University.SchoolType;
                existingUniversity.LogoURL = request.University.LogoURL;
                existingUniversity.WebURL = request.University.WebURL;
                existingUniversity.Description = request.University?.Description;

                var updateUniversity = await _context.SaveChangesAsync(cancellationToken);
                return updateUniversity > 0;
            }
        }
    }
}
