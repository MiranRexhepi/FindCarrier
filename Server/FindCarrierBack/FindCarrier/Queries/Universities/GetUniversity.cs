using FindCarrier.Domain.Entities;
using FindCarrier.Domain;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace FindCarrier.Queries.Universities
{
    public class GetUniversity
    {
        public class Query : IRequest<University>
        {
            public int Id { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }

        public class QueryHandler : IRequestHandler<Query, University>
        {
            private readonly CarrierDbContext _context;
            public QueryHandler(CarrierDbContext context)
            {
                _context = context;
            }

            public async Task<University> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.University.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            }
        }
    }
}