using FindCarrier.Domain.Entities;
using FindCarrier.Domain;
using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FindCarrier.Queries.Universities
{
    public class GetUniversitiesByLocation
    {
        public class Query : IRequest<List<University>>
        {
            public string Location { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Location).NotEmpty();
            }
        }

        public class QueryHandler : IRequestHandler<Query, List<University>>
        {
            private readonly CarrierDbContext _context;
            public QueryHandler(CarrierDbContext context)
            {
                _context = context;
            }

            public async Task<List<University>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.University
                    .Where(x => x.Location.Contains(request.Location))
                    .ToListAsync(cancellationToken);
            }
        }
    }
}