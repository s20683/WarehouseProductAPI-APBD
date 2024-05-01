using System.Data.SqlClient;
using Project4.model;

namespace Project4.repositories;

public class OrdersRepository : IOrdersRepository
{
    private IConfiguration _configuration;

    public OrdersRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Order checkOrderForProductExist(int productId, int amount, DateTime createdAt)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        using var query = new SqlCommand();
        query.Connection = con;
        query.CommandText = "SELECT IdOrder, IdProduct, Amount, CreatedAt, FulfilledAt FROM Order " +
                            "WHERE IdProduct = @IdProduct AND Amount = @Amount AND CreatedAt < @CreatedAt";
        query.Parameters.AddWithValue("@IdProduct", productId);
        query.Parameters.AddWithValue("@Amount", amount);
        query.Parameters.AddWithValue("@CreatedAt", createdAt);
        var dr = query.ExecuteReader();

        if (!dr.Read()) return null;
        
        var receivedOrder = new Order(
            (int)dr["IdOrder"],
            (int)dr["IdProduct"],
            (int)dr["Amount"],
            (DateTime)dr["CreatedAt"],
            dr["FulfilledAt"] == DBNull.Value ? (DateTime?)null : (DateTime)dr["FulfilledAt"]
            );
        return receivedOrder;
    }
    public int cancelOrder(int orderId)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        using var query = new SqlCommand();
        query.Connection = con;
        query.CommandText = "UPDATE Order SET FulfilledAt=@FulfilledAt WHERE OrderId = @OrderId";
        query.Parameters.AddWithValue("@IdOrderId", orderId);
        query.Parameters.AddWithValue("@FulfilledAt", DateTime.Now);
        var dr = query.ExecuteReader();

        var count = query.ExecuteNonQuery();
        return count;
    }
}