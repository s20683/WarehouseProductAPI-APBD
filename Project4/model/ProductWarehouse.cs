using System.ComponentModel.DataAnnotations;

namespace Project4.model;

public class ProductWarehouse
{
    public int IdProductWartehouse { get; private set; }
    [Required]
    public int IdWarehouse { get; private set; }
    [Required]
    public int IdProduct { get; private set; }
    [Required]
    public int IdOrder { get; private set; }
    [Required]
    public int Amount { get; private set; }
    [Required]
    public decimal Price { get; private set; }
    [Required]
    public DateTime CreatedAt { get; private set; }

    public ProductWarehouse(int idWarehouse, int idProduct, int idOrder, int amount, decimal price, DateTime createdAt)
    {
        IdWarehouse = idWarehouse;
        IdProduct = idProduct;
        IdOrder = idOrder;
        Amount = amount;
        Price = price;
        CreatedAt = createdAt;
    }
}