using Application.Common.Interfaces;
using Application.Exceptions;
using Domain.Entities;
using Domain.Entities.Orders;
using Domain.Enums;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Orders.Commands.CreateOrder
{
    public class ReturnVehicleCommand : IRequest<Unit>
    {
        public bool IsDamaged;
        public bool IsGasFilled;
        public int OrderId;
    }

    public class ReturnVehicleHandler : IRequestHandler<ReturnVehicleCommand, Unit>
    {
        private readonly IApplicationDbContext _context;

        public ReturnVehicleHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(ReturnVehicleCommand request, CancellationToken cancellationToken)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Id == request.OrderId);

            if (order == null)
            {
                throw new NotFoundException(request.OrderId, "Order");
            }

            if (request.IsDamaged || !request.IsGasFilled)
            {
                order.ChangeStateToExtraFeesAwaitingExtraFees();
            }
            else
            {
                order.ChangeStateToCompleted();
            }

            var returnOrder = new VehicleReturnOrder 
            { 
                IsDamaged = request.IsDamaged, 
                IsGasFilled = request.IsGasFilled, 
                ReturnTime = DateTime.Now, 
                Order = order 
            };

            _context.VehicleReturnOrders.Add(returnOrder);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
