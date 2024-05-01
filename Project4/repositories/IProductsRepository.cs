using Project4.model;

namespace Project4.repositories;

public interface IProductsRepository
{
    Product checkProductExist(int productId);
}