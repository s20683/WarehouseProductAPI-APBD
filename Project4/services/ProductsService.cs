using Project4.model;
using Project4.repositories;

namespace Project4.services;

public class ProductsService : IProductsService
{
    private IProductsRepository _productsRepository;

    public ProductsService(IProductsRepository productsRepository)
    {
        _productsRepository = productsRepository;
    }

    public Product checkProductExist(int productId)
    {
        return _productsRepository.checkProductExist(productId);
    }
}