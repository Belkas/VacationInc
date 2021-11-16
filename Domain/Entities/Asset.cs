using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    abstract public class Asset
    {
        public int Id { get; set; }

        [Column(TypeName = "money")]
        public decimal DailyPrice { get; set; }

        public string Name { get; set; }

    }
}
