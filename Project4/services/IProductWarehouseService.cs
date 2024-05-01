using Project4.model;

namespace Project4.services;

public interface IProductWarehouseService
{
    bool checkOrderExist(int orderId);
    int insertProductWarehouse(ProductWarehouse productWarehouse);
}