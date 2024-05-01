using System.Data;
using System.Data.SqlClient;

namespace Project4.repositories;

public class ProcedureRepository : IProcedureRepository
{
    private IConfiguration _configuration;

    public ProcedureRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string AddProductToWarehouse(int idProduct, int idWarehouse, int amount, DateTime createdAt)
    {
        using (var con = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]))
        {
            con.Open();
            using (var cmd = new SqlCommand("AddProductToWarehouse", con))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@IdProduct", SqlDbType.Int) { Value = idProduct });
                cmd.Parameters.Add(new SqlParameter("@IdWarehouse", SqlDbType.Int) { Value = idWarehouse });
                cmd.Parameters.Add(new SqlParameter("@Amount", SqlDbType.Int) { Value = amount });
                cmd.Parameters.Add(new SqlParameter("@CreatedAt", SqlDbType.DateTime) { Value = createdAt });

                try
                {
                    cmd.ExecuteNonQuery();
                    return "Ok";
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e.Message);
                    return e.Message;
                }
            }
        }
    }
}