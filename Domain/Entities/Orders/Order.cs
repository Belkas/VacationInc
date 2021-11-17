using Domain.Enums;
using Domain.Exceptions;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    abstract public class Order
    {
        public int Id { get; set; }
        public DateTime ReservedFrom { get; set; }
        public DateTime ReservedTo { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        [Column(TypeName = "money")]
        public decimal PaymentAmount { get; set; }
        public string PaymentCurrency { get; set; }
        public OrderStates State { get; set; }

        public void ChangeStateToPaid()
        {
            if(State != OrderStates.Initiated)
            {
                throw new InvalidOrderStateChangeException(State, OrderStates.Paid);
            }
        }
        public void ChangeStateToExtraFeesAwaitingExtraFees()
        {
            if (State != OrderStates.Paid)
            {
                throw new InvalidOrderStateChangeException(State, OrderStates.AwaitingExtraFees);
            }
        }

        public void ChangeStateToCompleted()
        {
            if (State != OrderStates.Paid || State != OrderStates.AwaitingExtraFees)
            {
                throw new InvalidOrderStateChangeException(State, OrderStates.Paid);
            }
        }

    }
}
