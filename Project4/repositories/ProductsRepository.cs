using Project4.model;

namespace Project4.repositories;
using System.Data.SqlClient;

public class ProductsRepository : IProductsRepository
{
    private IConfiguration _configuration;

    public ProductsRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Product checkProductExist(int productId)
    {
        using var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        con.Open();
        using var query = new SqlCommand();
        query.Connection = con;
        query.CommandText = "SELECT IdProduct, Name, Description, Price FROM Product WHERE IdProduct = @IdProduct";
        query.Parameters.AddWithValue("@IdProduct", productId);
        var dr = query.ExecuteReader();

        if (!dr.Read()) return null;

        var receivedProduct = new Product(
            (int)dr["IdProduct"],
            dr["Name"].ToString(),
            dr["Description"].ToString(),
            (decimal)dr["Price"]
        );
        return receivedProduct;
    }
}