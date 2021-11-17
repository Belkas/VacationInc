using Domain.Enums;
using System;

namespace Domain.Exceptions
{
    public class InvalidOrderStateChangeException : Exception
    {
        public InvalidOrderStateChangeException(OrderStates from, OrderStates to)
           : base($"Order state cannot change from {Enum.GetName(from)} to {Enum.GetName(from)}")
        {
        }
    }
}
