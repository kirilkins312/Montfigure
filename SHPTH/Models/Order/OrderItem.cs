using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHPTH.Models.Order
{
    public class OrderItem
    {
        [Key]
        public int ID { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public int ClothId { get; set; }
        [ForeignKey("ClothId")]
        public  Cloth Cloths { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Orders { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
