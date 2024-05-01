using Project4.repositories;

namespace Project4.services;

public class ProcedureService : IProcedureService
{
    private IProcedureRepository _procedureRepository;

    public ProcedureService(IProcedureRepository procedureRepository)
    {
        _procedureRepository = procedureRepository;
    }

    public string AddProductToWarehouse(int idProduct, int idWarehouse, int amount, DateTime createdAt)
    {
        return _procedureRepository.AddProductToWarehouse(idProduct, idWarehouse, amount, createdAt);
    }
}