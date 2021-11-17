using Application.Common.Interfaces;
using Application.Exceptions;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Orders.Commands.CreateOrder
{
    public class ConfirmVehicleOrderCommand : IRequest<Unit>
    {
        public int OrderId { get; set; }
    }

    public class ConfirmVehicleOrderCommandHandler : IRequestHandler<ConfirmVehicleOrderCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public ConfirmVehicleOrderCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ConfirmVehicleOrderCommand request, CancellationToken cancellationToken)
        {

            var order = _context.VehicleOrders.FirstOrDefault(x => x.Id == request.OrderId);

            if (order == null)
            {
                throw new NotFoundException(request.OrderId, "Order");
            }

            order.ChangeStateToPaid();
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
