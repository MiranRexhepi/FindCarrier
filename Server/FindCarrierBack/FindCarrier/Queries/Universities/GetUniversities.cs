using FindCarrier.Domain;
using FindCarrier.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace FindCarrier.Queries.Universities
{
    public class GetUniversities
    {
        public class Query : IRequest<List<University>>
        { }

        public class QueryHandler : IRequestHandler<Query, List<University>>
        {
            private readonly CarrierDbContext _context;
            public QueryHandler(CarrierDbContext context)
            {
                _context = context;
            }

            public async Task<List<University>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.University.ToListAsync(cancellationToken);
            }
        }
    }
}
