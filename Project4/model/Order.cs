using System.ComponentModel.DataAnnotations;

namespace Project4.model;

public class Order
{
    [Required]
    public int IdOrder { get; private set; }
    [Required]
    public int IdProduct { get; private set; }
    [Required]
    public int Amount { get; private set; }
    [Required]
    public DateTime CreatedAt { get; private set; }
    public DateTime? FulfilledAt { get; private set; }

    public Order(int idOrder, int idProduct, int amount, DateTime createdAt, DateTime? fulfilledAt)
    {
        IdOrder = idOrder;
        IdProduct = idProduct;
        Amount = amount;
        CreatedAt = createdAt;
        FulfilledAt = fulfilledAt;
    }
}