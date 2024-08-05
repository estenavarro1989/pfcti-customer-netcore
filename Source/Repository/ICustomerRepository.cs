public interface ICustomerRepository
{
    void AddCustomer(Customer customer);
    Customer EditCustomer(string id, Customer customer);
    void DeleteCustomer(string id);
    Customer GetCustomerById(string id);
    IEnumerable<Customer> GetCustomerOrderByName();
    IEnumerable<Customer> GetCustomerOrderById();
    IEnumerable<Customer> GetCustomerOrderByBirthDate();
}