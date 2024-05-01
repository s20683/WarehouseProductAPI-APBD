using System.Data.SqlClient;

namespace Project4.repositories;

public class WarehousesRepository : IWarehousesRepository
{
    private IConfiguration _configuration;

    public WarehousesRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool checkWarehouseExist(int warehouseId)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        using var query = new SqlCommand();
        query.Connection = con;
        query.CommandText = "SELECT IdWarehouse, Name, Address FROM Warehouse WHERE IdWarehouse = @IdWarehouse";
        query.Parameters.AddWithValue("@IdWarehouse", warehouseId);
        var dr = query.ExecuteReader();

        if (dr.Read())
        {
            return true;
        }
        return false;
    }
}