using Application.Exceptions;
using Application.Orders.Commands.CreateOrder;
using FluentAssertions;
using FluentValidation;
using NUnit.Framework;
using System;
using static ApplicationIntegrationTests.TestsFicture;

namespace ApplicationIntegrationTests.Orders.Commands.CreateVehicleOrder
{
    public class CreateVehicleOrderCommandTest : TestBase
    {

        [Test]
        public void CreateVehicle_ReservationFromLaterThanTo_ShouldFailValidation()
        {
            var command = new CreateVehicleOrderCommand 
            { 
                Name = "Test1",
                PhoneNumber = "+370000000",
                ReservedFrom = new DateTime(2021, 11, 19),
                ReservedTo = new DateTime(2021, 11, 18),
                DesiredCurrency = "USD",
                VehicleId = 1
            };

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }

    }
}
