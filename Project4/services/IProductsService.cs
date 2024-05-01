using Project4.model;

namespace Project4.services;

public interface IProductsService
{
    Product checkProductExist(int productId);

}