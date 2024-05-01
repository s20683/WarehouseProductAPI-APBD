using Project4.repositories;

namespace Project4.services;

public class WarehousesService : IWarehousesService
{
    private IWarehousesRepository _warehousesRepository;

    public WarehousesService(IWarehousesRepository warehousesRepository)
    {
        _warehousesRepository = warehousesRepository;
    }

    public bool checkWarehouseExist(int warehouseId)
    {
        return _warehousesRepository.checkWarehouseExist(warehouseId);
    }
}