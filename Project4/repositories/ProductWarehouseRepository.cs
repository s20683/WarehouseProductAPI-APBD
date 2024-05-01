using System.Data.SqlClient;
using Project4.model;

namespace Project4.repositories;

public class ProductWarehouseRepository : IProductWarehouseRepository
{
    private IConfiguration _configuration;

    public ProductWarehouseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool checkOrderExist(int orderId)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        using var query = new SqlCommand();
        query.Connection = con;
        query.CommandText = "SELECT IdProductWarehouse, IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt FROM Product_Warehouse " +
                            "WHERE IdOrder = @IdOrder";
        query.Parameters.AddWithValue("@IdOrder", orderId);
        var dr = query.ExecuteReader();

        if (dr.Read())
        {
            return true;
        }

        return false;
    }

    public int insertProductWarehouse(ProductWarehouse productWarehouse)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        using var query = new SqlCommand();
        query.Connection = con;
        query.CommandText = "INSERT INTO Product_Warehouse(IdWarehouse, IdProduct, IdOrder, Amount, Price, CreatedAt)" +
                            " VALUES(@IdWarehouse, @IdProduct, @IdOrder, @Amount, @Price, @CreatedAt)";
        query.Parameters.AddWithValue("@IdProductWarehouse", productWarehouse.IdProductWartehouse);
        query.Parameters.AddWithValue("@IdWarehouse", productWarehouse.IdWarehouse);
        query.Parameters.AddWithValue("@IdProduct", productWarehouse.IdProduct);
        query.Parameters.AddWithValue("@IdOrder", productWarehouse.IdOrder);
        query.Parameters.AddWithValue("@Amount", productWarehouse.Amount);
        query.Parameters.AddWithValue("@Price", productWarehouse.Price);
        query.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

        var id = Convert.ToInt32(query.ExecuteScalar());
        return id; 
    }
}