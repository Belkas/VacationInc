using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Orders.Commands.CreateOrder
{
    public class CreateVehicleOrderCommand : IRequest<Unit>
    {
        public int Id;
        public DateTime ReservedFrom;
        public DateTime ReservedTo;
        public string Name;
        public string PhoneNumber;
        public string DesiredCurrency;

        public int VehicleId;
    }

    public class CreateVehicleOrderCommandHandler : IRequestHandler<CreateVehicleOrderCommand, Unit>
    {
        private readonly IApplicationDbContext _context;
        private readonly ICurrencyRepository _currencyRepository;

        public CreateVehicleOrderCommandHandler(IApplicationDbContext context, ICurrencyRepository currencyRepository)
        {
            _context = context;
            _currencyRepository = currencyRepository;
        }

        public async Task<Unit> Handle(CreateVehicleOrderCommand request, CancellationToken cancellationToken)
        {
            var vehicle = _context.Vehicles.FirstOrDefault(x => x.Id == request.VehicleId);

            // todo: exceptions
            if (vehicle == null)
            {
                throw new Exception("Bab");
            }

            // todo : Fix this+
            var conflictingReservationTimesOrders = _context.VehicleOrders.Where(x => x.Vehicle.Id == request.VehicleId)
                .Where(x => 
            (x.ReservedFrom < request.ReservedFrom && request.ReservedFrom < x.ReservedTo) || 
            (x.ReservedFrom < request.ReservedTo && request.ReservedTo < x.ReservedTo));

            if (conflictingReservationTimesOrders.Any())
            {
                throw new Exception($"conflicting with orders ID: {string.Join(", ", conflictingReservationTimesOrders.Select(x => x.Id.ToString()))}");
            }
            
            var value = await _currencyRepository.GetExchangeRate(request.DesiredCurrency);
            var amount = vehicle.DailyPrice * (request.ReservedFrom - request.ReservedTo).Days * value;

            var entity = new VehicleOrder
            {
                Name = request.Name,
                PhoneNumber = request.PhoneNumber,
                ReservedFrom = request.ReservedFrom,
                ReservedTo = request.ReservedTo,
                PaymentCurrency = request.DesiredCurrency,
                PaymentAmount = amount,
                State = OrderStates.Initiated,
                Vehicle = vehicle
            };

            _context.VehicleOrders.Add(entity);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
