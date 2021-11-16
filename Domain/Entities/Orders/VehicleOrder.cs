namespace Domain.Entities
{
    public class VehicleOrder : Order
    {
        // todo : should be asset id instead of vehicle id in database -> figure out how
        public virtual Vehicle Vehicle { get; set; }
    }
}
