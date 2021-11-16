using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Application.Assets.Queries
{
    public class GetVehicleOrdersQuery : IRequest<List<VehicleOrder>>
    {
    }

    public class GetVehicleOrdersQueryHandler : IRequestHandler<GetVehicleOrdersQuery, List<VehicleOrder>>
    {
        private readonly IApplicationDbContext _context;

        public GetVehicleOrdersQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<VehicleOrder>> Handle(GetVehicleOrdersQuery request, CancellationToken cancellationToken)
        {
            var results = await _context.VehicleOrders.ToListAsync(cancellationToken);
            return results;
        }
    }
}
