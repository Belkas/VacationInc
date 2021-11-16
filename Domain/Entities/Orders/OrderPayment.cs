using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class OrderPayment
    {
        public int Id { get; set; }
        public DateTime PaymentTime { get; set; }
        [Column(TypeName = "money")]
        public virtual Order Order { get; set; }
    }
}
