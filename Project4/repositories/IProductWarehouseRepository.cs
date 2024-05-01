using Project4.model;

namespace Project4.repositories;

public interface IProductWarehouseRepository
{
    bool checkOrderExist(int orderId);
    int insertProductWarehouse(ProductWarehouse productWarehouse);
}