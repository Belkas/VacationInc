using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace Application.Vehicles.Queries
{
    public class GetVehiclesQuery : IRequest<List<Vehicle>>
    {
    }

    public class GetVehiclesQueryHandler : IRequestHandler<GetVehiclesQuery, List<Vehicle>>
    {
        private readonly IApplicationDbContext _context;

        public GetVehiclesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Vehicle>> Handle(GetVehiclesQuery request, CancellationToken cancellationToken)
        {

            var results = await _context.Vehicles.ToListAsync(cancellationToken);
            return results;
        }
    }
}
