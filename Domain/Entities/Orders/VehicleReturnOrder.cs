namespace Domain.Entities.Orders
{
    public class VehicleReturnOrder : ReturnOrder
    {
        public bool IsDamaged { get; set; }
        public bool IsGasFilled { get; set; }
        public virtual Order Order { get; set; }
    }
}
