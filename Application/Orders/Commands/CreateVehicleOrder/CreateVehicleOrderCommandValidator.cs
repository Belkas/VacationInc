using Application.Orders.Commands.CreateOrder;
using FluentValidation;

namespace Application.Orders.Commands.CreateVehicleOrder
{
    public class CreateVehicleOrderCommandValidator : AbstractValidator<CreateVehicleOrderCommand>
    {
        public CreateVehicleOrderCommandValidator()
        {
            RuleFor(x => x.ReservedFrom).LessThan(x => x.ReservedTo);
        }
    }
}
