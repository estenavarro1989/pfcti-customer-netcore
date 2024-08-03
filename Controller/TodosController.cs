using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly AppDbContext _dbContext;

    public TodosController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpGet]
    public IEnumerable<Customer> GetTodos()
    {
        //return _dbContext.Todos.ToList();


        //using (var dataSource = NpgsqlDataSource.Create(_dbContext.Database.GetConnectionString()))
        using (var conn = new NpgsqlConnection(_dbContext.Database.GetConnectionString()))
        {
            conn.Open();
            using (var trans = conn.BeginTransaction())
            {
                //using (var command = dataSource.CreateCommand("get_customers_order_by_name"))
                using (var command = new NpgsqlCommand("get_customers_order_by_name", conn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new NpgsqlParameter()
                    {
                        ParameterName = "p_result",
                        NpgsqlDbType = NpgsqlDbType.Refcursor,
                        Direction = ParameterDirection.InputOutput,
                        Value = "p_result"
                    });
                    command.ExecuteNonQuery();

                    command.CommandText = "fetch all in \"p_result\"";
                    command.CommandType = CommandType.Text;
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        // Process the record
                        Console.WriteLine(reader.GetString(reader.GetOrdinal("id")));
                    }
                }
            }
        }

        return null;
        //return _dbContext.Todos.FromSqlRaw("get_customers_order_by_name").ToList();

    }
}