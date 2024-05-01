using System.ComponentModel.DataAnnotations;

namespace Project4.model;

public class WarehouseProduct
{
    [Required]
    public int IdProduct { get; private set; }
    [Required]
    public int IdWarehouse { get; private set; }
    [Required]
    public int Amount { get; private set; }
    [Required]
    public DateTime CreatedAt { get; private set; }

    public WarehouseProduct(int idProduct, int idWarehouse, int amount, DateTime createdAt)
    {
        IdProduct = idProduct;
        IdWarehouse = idWarehouse;
        Amount = amount;
        CreatedAt = createdAt;
    }
}