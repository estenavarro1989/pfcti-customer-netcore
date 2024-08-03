public interface ICustomerRepository
{
    IEnumerable<Customer> GetCustomerOrderByName();
    IEnumerable<Customer> GetCustomerOrderById();
    IEnumerable<Customer> GetCustomerOrderByBirthDate();
}