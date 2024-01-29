using FindCarrier.Domain;
using FindCarrier.Validators;
using FluentValidation;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using FindCarrier.HttpRequests;

namespace FindCarrier.Commands.Universities
{
    public class CreateUniversity
    {
        public class Command : IRequest<bool>
        {
            public AddOrCreateUniversityRequest University { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.University).SetValidator(new AddOrCreateUniversityRequestValidator());
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
                    .FirstOrDefaultAsync(x => x.WebURL == request.University.WebURL, cancellationToken);

                //if university already exists, don't add the same university twice
                if (existingUniversity != null)
                {
                    //if university already exists, but is deleted, reactivate it instead of creating new one
                    if (existingUniversity.IsDeleted)
                    {
                        existingUniversity.IsDeleted = false;
                        var reactivate = await _context.SaveChangesAsync(cancellationToken);
                        return reactivate > 0;
                    }

                    return false;
                }

                await _context.University.AddAsync(new Domain.Entities.University
                {
                    Name = request.University.Name,
                    Location = request.University.Location,
                    Field = request.University.Field,
                    SchoolType = request.University.SchoolType,
                    LogoURL = request.University.LogoURL,
                    WebURL = request.University.WebURL,
                    Description = request.University.Description,
                    IsDeleted = false
                }, cancellationToken);

                var saveNewUniversity = await _context.SaveChangesAsync(cancellationToken);
                return saveNewUniversity > 0;
            }
        }
    }
}