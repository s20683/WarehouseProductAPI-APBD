using Project4.model;
using Project4.repositories;

namespace Project4.services;

public class ProductWarehouseService : IProductWarehouseService
{
    private IProductWarehouseRepository _productWarehouseRepository;

    public ProductWarehouseService(IProductWarehouseRepository productWarehouseRepository)
    {
        _productWarehouseRepository = productWarehouseRepository;
    }

    public bool checkOrderExist(int orderId)
    {
        return _productWarehouseRepository.checkOrderExist(orderId);
    }

    public int insertProductWarehouse(ProductWarehouse productWarehouse)
    {
        return _productWarehouseRepository.insertProductWarehouse(productWarehouse);
    }
}