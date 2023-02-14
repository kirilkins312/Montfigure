namespace SHPTH.Models.Order;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ShoppingCartItem
{
    [Key]
    public int Id { get; set; }

    public Cloth Cloth { get; set; }
    public int Amount { get; set; }


    public string ShoppingCartId { get; set; }
}

