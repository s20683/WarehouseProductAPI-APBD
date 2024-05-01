namespace Project4.services;

public interface IProcedureService
{
    string AddProductToWarehouse(int idProduct, int idWarehouse, int amount, DateTime createdAt);

}