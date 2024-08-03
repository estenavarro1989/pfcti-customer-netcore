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

    public void AddCustomer(Customer customer)
    {
        using (var conn = new NpgsqlConnection(_dbContext.Database.GetConnectionString()))
        {
            conn.Open();
            using (var command = new NpgsqlCommand("create_customer", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new NpgsqlParameter()
                {
                    ParameterName = "p_id",
                    NpgsqlDbType = NpgsqlDbType.Varchar,
                    Direction = ParameterDirection.Input,
                    Value = customer.Id
                });
                command.Parameters.Add(new NpgsqlParameter()
                {
                    ParameterName = "p_first_name",
                    NpgsqlDbType = NpgsqlDbType.Varchar,
                    Direction = ParameterDirection.Input,
                    Value = customer.FirstName
                });
                command.Parameters.Add(new NpgsqlParameter()
                {
                    ParameterName = "p_last_name",
                    NpgsqlDbType = NpgsqlDbType.Varchar,
                    Direction = ParameterDirection.Input,
                    Value = customer.LastName
                });
                command.Parameters.Add(new NpgsqlParameter()
                {
                    ParameterName = "p_phone",
                    NpgsqlDbType = NpgsqlDbType.Varchar,
                    Direction = ParameterDirection.Input,
                    Value = customer.Phone
                });
                command.Parameters.Add(new NpgsqlParameter()
                {
                    ParameterName = "p_birth_date",
                    NpgsqlDbType = NpgsqlDbType.Date,
                    Direction = ParameterDirection.Input,
                    Value = customer.BirthDate
                });
                command.ExecuteNonQuery();
            }
        }
    }

    public void EditCustomer(Customer customer)
    {
        using (var conn = new NpgsqlConnection(_dbContext.Database.GetConnectionString()))
        {
            conn.Open();
            using (var command = new NpgsqlCommand("update_customer", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new NpgsqlParameter()
                {
                    ParameterName = "p_id",
                    NpgsqlDbType = NpgsqlDbType.Varchar,
                    Direction = ParameterDirection.Input,
                    Value = customer.Id
                });
                command.Parameters.Add(new NpgsqlParameter()
                {
                    ParameterName = "p_first_name",
                    NpgsqlDbType = NpgsqlDbType.Varchar,
                    Direction = ParameterDirection.Input,
                    Value = customer.FirstName
                });
                command.Parameters.Add(new NpgsqlParameter()
                {
                    ParameterName = "p_last_name",
                    NpgsqlDbType = NpgsqlDbType.Varchar,
                    Direction = ParameterDirection.Input,
                    Value = customer.LastName
                });
                command.Parameters.Add(new NpgsqlParameter()
                {
                    ParameterName = "p_phone",
                    NpgsqlDbType = NpgsqlDbType.Varchar,
                    Direction = ParameterDirection.Input,
                    Value = customer.Phone
                });
                command.Parameters.Add(new NpgsqlParameter()
                {
                    ParameterName = "p_birth_date",
                    NpgsqlDbType = NpgsqlDbType.Date,
                    Direction = ParameterDirection.Input,
                    Value = customer.BirthDate
                });
                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteCustomer(string id)
    {
        using (var conn = new NpgsqlConnection(_dbContext.Database.GetConnectionString()))
        {
            conn.Open();
            using (var command = new NpgsqlCommand("delete_customer", conn))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new NpgsqlParameter()
                {
                    ParameterName = "p_id",
                    NpgsqlDbType = NpgsqlDbType.Varchar,
                    Direction = ParameterDirection.Input,
                    Value = id
                });
                command.ExecuteNonQuery();
            }
        }
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
                            LastName = reader.GetString(reader.GetOrdinal("last_name")),
                            Phone = reader.GetString(reader.GetOrdinal("phone")),
                            BirthDate = (!reader.IsDBNull(reader.GetOrdinal("birth_date"))) ? reader.GetDateTime(reader.GetOrdinal("birth_date")) : default(DateTime)
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
                            LastName = reader.GetString(reader.GetOrdinal("last_name")),
                            Phone = reader.GetString(reader.GetOrdinal("phone")),
                            BirthDate = (!reader.IsDBNull(reader.GetOrdinal("birth_date"))) ? reader.GetDateTime(reader.GetOrdinal("birth_date")) : default(DateTime)
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
                            LastName = reader.GetString(reader.GetOrdinal("last_name")),
                            Phone = reader.GetString(reader.GetOrdinal("phone")),
                            BirthDate = (!reader.IsDBNull(reader.GetOrdinal("birth_date"))) ? reader.GetDateTime(reader.GetOrdinal("birth_date")) : default(DateTime)
                        };

                        customerList.Add(customer);
                    }
                }
            }
        }

        return customerList;
    }
}