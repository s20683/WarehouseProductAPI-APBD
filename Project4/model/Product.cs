using System.ComponentModel.DataAnnotations;

namespace Project4.model;

public class Product
{
    [Required]
    public int IdProduct { get; private set; }
    [Required]
    [MaxLength(200)]
    public string Name { get; private set; }
    [Required]
    [MaxLength(200)]
    public string Description { get; private set; }
    [Required]
    public decimal Price { get; private set; }

    public Product(int idProduct, string name, string description, decimal price)
    {
        IdProduct = idProduct;
        Name = name;
        Description = description;
        Price = price;
    }
}