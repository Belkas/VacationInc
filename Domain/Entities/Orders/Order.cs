using Domain.Enums;
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
    }
}
