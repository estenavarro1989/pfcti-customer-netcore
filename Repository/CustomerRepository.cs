using System.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using NpgsqlTypes;
public class CustomerRepository : ICustomerRepository
{
    private readonly AppDbContext _dbContext;

    public CustomerRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public IEnumerable<Customer> GetCustomerOrderByName()
    {
        List<Customer> customerList = new List<Customer>();
        using (var conn = new NpgsqlConnection(_dbContext.Database.GetConnectionString()))
        {
            conn.Open();
            using (var trans = conn.BeginTransaction())
            {
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
                        var id = reader.GetString(reader.GetOrdinal("id"));
                        Customer customer = new Customer(id)
                        {
                            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                            lastName = reader.GetString(reader.GetOrdinal("last_name")),
                            phone = reader.GetString(reader.GetOrdinal("phone")),
                            birthDate = (!reader.IsDBNull(reader.GetOrdinal("birth_date"))) ? reader.GetDateTime(reader.GetOrdinal("birth_date")) : default(DateTime)
                        };

                        customerList.Add(customer);
                    }
                }
            }
        }

        return customerList;
    }

    public IEnumerable<Customer> GetCustomerOrderById()
    {
        List<Customer> customerList = new List<Customer>();
        using (var conn = new NpgsqlConnection(_dbContext.Database.GetConnectionString()))
        {
            conn.Open();
            using (var trans = conn.BeginTransaction())
            {
                using (var command = new NpgsqlCommand("get_customers_order_by_id", conn))
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
                        var id = reader.GetString(reader.GetOrdinal("id"));
                        Customer customer = new Customer(id)
                        {
                            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                            lastName = reader.GetString(reader.GetOrdinal("last_name")),
                            phone = reader.GetString(reader.GetOrdinal("phone")),
                            birthDate = (!reader.IsDBNull(reader.GetOrdinal("birth_date"))) ? reader.GetDateTime(reader.GetOrdinal("birth_date")) : default(DateTime)
                        };

                        customerList.Add(customer);
                    }
                }
            }
        }

        return customerList;
    }

    public IEnumerable<Customer> GetCustomerOrderByBirthDate()
    {
        List<Customer> customerList = new List<Customer>();
        using (var conn = new NpgsqlConnection(_dbContext.Database.GetConnectionString()))
        {
            conn.Open();
            using (var trans = conn.BeginTransaction())
            {
                using (var command = new NpgsqlCommand("get_customers_order_by_birth_date_desc", conn))
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
                        var id = reader.GetString(reader.GetOrdinal("id"));
                        Customer customer = new Customer(id)
                        {
                            FirstName = reader.GetString(reader.GetOrdinal("first_name")),
                            lastName = reader.GetString(reader.GetOrdinal("last_name")),
                            phone = reader.GetString(reader.GetOrdinal("phone")),
                            birthDate = (!reader.IsDBNull(reader.GetOrdinal("birth_date"))) ? reader.GetDateTime(reader.GetOrdinal("birth_date")) : default(DateTime)
                        };

                        customerList.Add(customer);
                    }
                }
            }
        }

        return customerList;
    }
}