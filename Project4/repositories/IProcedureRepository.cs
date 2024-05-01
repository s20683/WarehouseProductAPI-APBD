namespace Project4.repositories;

public interface IProcedureRepository
{
    string AddProductToWarehouse(int idProduct, int idWarehouse, int amount, DateTime createdAt);
}